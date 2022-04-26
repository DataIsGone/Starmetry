using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AskMe : MonoBehaviour
{
    int ignoreRaycast;
    int defaultLayer;

    public GameObject env;
    public GameObject refUI;
    public GameObject scroll;

    [SerializeField]
    private GameObject refDialogue;

    [SerializeField]
    private GameObject refDialogueSm;

    void Start() {
        ignoreRaycast = LayerMask.NameToLayer("Ignore Raycast");
        defaultLayer = LayerMask.NameToLayer("Default");
    }

    public void toggleMovementOff(GameObject env) {
        env.layer = ignoreRaycast;
    }

    public void toggleMovementOn(GameObject env) {
        env.layer = defaultLayer;
    }

    public void stopAsking(GameObject env) {
        refUI.SetActive(false);
        toggleMovementOn(env);
    }

    public void openScrollWindow() {
        refDialogue.SetActive(false);
        refDialogueSm.SetActive(true);
        scroll.SetActive(true);
    }

    public void closeScrollWindow() {
        refDialogueSm.SetActive(false);
        refDialogue.SetActive(true);
        scroll.SetActive(false);
    }

}
