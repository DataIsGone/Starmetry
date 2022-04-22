using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AskMe : MonoBehaviour
{

    const string ENV_NAME = "GroundTest";
    int ignoreRaycast;
    int defaultLayer;

    public GameObject env;
    public GameObject refUI;
    public GameObject scroll;

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
        scroll.SetActive(true);
    }

    public void closeScrollWindow() {
        scroll.SetActive(false);
    }

}
