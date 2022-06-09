using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public Toggle fullScreenTog;

    public List<ResItem> resolutions = new List<ResItem>();
    private int selectedRes;
    public TMP_Text resLabel;

    public AudioMixer mixer;

    public TMP_Text masterLabel, musicLabel, sfxLabel;
    public Slider masterSlider, musicSlider, sfxSlider;

    void Start()
    {
        fullScreenTog.isOn = Screen.fullScreen;
        bool foundRes = false;
        for (int i = 0; i < resolutions.Count; i++) {
            if (Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical) {
                foundRes = true;
                selectedRes = i;
                UpdateResLabel();
            }
        }

        if (!foundRes) {
            ResItem newRes = new ResItem();
            newRes.horizontal = Screen.width;
            newRes.vertical = Screen.height;
            resolutions.Add(newRes);
            selectedRes = resolutions.Count - 1;
            UpdateResLabel();
        }
        
        float vol = 0f;
        mixer.GetFloat("MasterVol", out vol);
        masterSlider.value = vol;
        mixer.GetFloat("MusicVol", out vol);
        musicSlider.value = vol;
        mixer.GetFloat("SFXVol", out vol);
        sfxSlider.value = vol;
    }

    public void ResLeft() {
        selectedRes--;
        if (selectedRes < 0) {selectedRes = resolutions.Count - 1;}
        UpdateResLabel();
    }

    public void ResRight() {
        selectedRes++;
        if (selectedRes > resolutions.Count - 1) {selectedRes = 0;}
        UpdateResLabel();
    }

    public void UpdateResLabel() {
        resLabel.text = resolutions[selectedRes].horizontal.ToString() + " x " + resolutions[selectedRes].vertical.ToString();
    }

    public void ApplyGraphics() {
        Screen.SetResolution(resolutions[selectedRes].horizontal, resolutions[selectedRes].vertical, fullScreenTog.isOn);
    }

    public void SetMasterVol() {
        masterLabel.text = Mathf.RoundToInt(masterSlider.value + 80).ToString();
        mixer.SetFloat("MasterVol", masterSlider.value);

        PlayerPrefs.SetFloat("MasterVol", masterSlider.value);
    }

    public void SetMusicVol() {
        musicLabel.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();
        mixer.SetFloat("MusicVol", musicSlider.value);

        PlayerPrefs.SetFloat("MusicVol", masterSlider.value);
    }

    public void SetSFXVol() {
        sfxLabel.text = Mathf.RoundToInt(sfxSlider.value + 80).ToString();
        mixer.SetFloat("SFXVol", sfxSlider.value);

        PlayerPrefs.SetFloat("SFXVol", masterSlider.value);
    }
}

[System.Serializable]
public class ResItem {
    public int horizontal, vertical;
}
