using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SceneEvents : MonoBehaviour
{
    [SerializeField] private Animator irrigationAnimator;
    //public GameObject box;
    // Start is called before the first frame update
    void Awake() {
        //animBox.enabled = false;
    }

    void Start()
    {
        
    }

    // ---------- LEVEL 1

    // ---------- LEVEL 2

    // ---------- LEVEL 3

    [YarnCommand("rotate_wheel")]
    public static void RotateWheel() {

    }

    [YarnCommand("rotate_box")]
    public void RotateBox() {
        //animBox.enabled = true;
        irrigationAnimator.Play("box_rotate");
    }
}
