using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GraphicsOptions : MonoBehaviour
{
    public Toggle fullScreenTog;

    public List<ResItem> resolutions = new List<ResItem>();
    private int selectedRes;
    public TMP_Text resLabel;

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
        
    }

    void Update()
    {
        
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
}

[System.Serializable]
public class ResItem {
    public int horizontal, vertical;
}
