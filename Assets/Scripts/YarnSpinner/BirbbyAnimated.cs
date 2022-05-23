using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class BirbbyAnimated : MonoBehaviour
{
    static private Animator spriteAnimator;

    void Awake() {
        spriteAnimator = gameObject.GetComponent<Animator>();
    }

    [YarnCommand("birbby_talk")]
    public static void BirbbyTalk() {
        spriteAnimator.SetBool("talking", true);
    }

    [YarnCommand("birbby_shutup")]
    public static void BirbbyShutUp() {
        spriteAnimator.SetBool("talking", false);
    }
}
