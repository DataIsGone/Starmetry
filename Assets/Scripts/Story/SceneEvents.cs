using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SceneEvents : MonoBehaviour
{
    [SerializeField] private Animator irrigationAnimator;
    [SerializeField] private Animator wheelAnimator;
    [SerializeField] private GameObject wheelModel;

    void Awake() {
        //animBox.enabled = false;
        wheelModel.SetActive(false);
    }

    void Start()
    {

    }

    // ---------- LEVEL 1

    // ---------- LEVEL 2

    // ---------- LEVEL 3

    [YarnCommand("place_wheel")]
    public void PlaceWheel() {
        wheelModel.SetActive(false);
    }

    [YarnCommand("rotate_wheel")]
    public void RotateWheel() {
        wheelAnimator.Play("wheel_rotate");
    }

    [YarnCommand("rotate_box")]
    public void RotateBox() {
        irrigationAnimator.Play("box_rotate");
    }
}
