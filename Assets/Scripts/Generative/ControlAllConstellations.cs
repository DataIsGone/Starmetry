using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ControlAllConstellations : MonoBehaviour
{
    [SerializeField] private GameObject[] canvases;
    [SerializeField] private GameObject answerMode;

    [YarnCommand("shift_constellations")]
    IEnumerator ShiftConstellations(int constellation) {
        TurnOffAllLabels();
        var time = 0f;
        var duration = 5f;
        Vector3 targetPosition = GetConstellationPosition(constellation);
        while (time < duration) {
            transform.position = Vector3.Lerp(transform.position, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        ShowLabels(constellation);
        transform.position = targetPosition;
    }

    private Vector3 GetConstellationPosition(int constellation) {
        var newY = -1f;
        if (constellation == 1) {
            newY = 0f;
        }
        else if (constellation == 2) {
            newY = 20f;
        }
        else {  // 3
            newY = 45f;
        }
        return new Vector3(transform.position.x, newY, transform.position.z);
    }
    
    private void ShowLabels(int constellation) {
        canvases[constellation-1].SetActive(true);
    }

    public void TurnOffAllLabels() {
        foreach (GameObject canvas in canvases) {
            canvas.SetActive(false);
        }
    }

    [YarnCommand("finish_constellation")]
    public void FinishConstellation(int constellation) {
        var thisChild = transform.GetChild(constellation - 1).gameObject;
        thisChild.SetActive(false);
    }
}
