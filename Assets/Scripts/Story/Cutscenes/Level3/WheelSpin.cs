using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSpin : MonoBehaviour
{
    static private Animator wheelAnimator;
    static private GameObject position1;
    static private Vector3 v3P1;
    static public bool cutscene1;
    static private GameObject splash;

    void Awake() {
        splash = GameObject.Find("Water Particle System");

        position1 = GameObject.Find("CamPosWheel");
        wheelAnimator = GameObject.Find("WheelCombo").GetComponent<Animator>();

        v3P1 = position1.transform.position;
        cutscene1 = false;
    }

    void Start() {
        RotateWheel();
        splash.SetActive(false);
    }

    void Update()
    {
        SceneEvents.dummy.position = Vector3.Lerp(SceneEvents.dummy.position, v3P1, SceneEvents.speed * Time.deltaTime);
        if (SceneEvents.dummy.position == v3P1) {cutscene1 = true;}
    }

    static public void RotateWheel() {
        wheelAnimator.Play("wheel_rotate");
        splash.SetActive(true);
    }
}
