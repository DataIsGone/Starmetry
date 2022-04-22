using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AskMe : MonoBehaviour
{

    const string ENV_NAME = "GroundTest";
    int ignoreRaycast;
    int defaultLayer;
    //GameObject env;

    // public GameObject refUI;

    // void Start() {
    //     disableRefMenu();
    // }

    // public void activateRefMenu() {
    //     refUI.SetActive(true);
    // }

    // public void disableRefMenu() {
    //     refUI.SetActive(false);
    // }

    //void Awake() {
        //env = GameObject.Find(ENV_NAME);
        // ignoreRaycast = LayerMask.NameToLayer("Ignore Raycast");
        // defaultLayer = LayerMask.NameToLayer("Default");
    //}

    void Start() {
        //toggleMovementOff();
        ignoreRaycast = LayerMask.NameToLayer("Ignore Raycast");
        defaultLayer = LayerMask.NameToLayer("Default");
    }

    public void toggleMovementOff(GameObject env) {
        env.layer = ignoreRaycast;
    }

    public void toggleMovementOn(GameObject env) {
        env.layer = defaultLayer;
    }
}
