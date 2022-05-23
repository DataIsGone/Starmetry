using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class BronicornAnimated : MonoBehaviour
{
    static private Animator spriteAnimator;

    void Awake() {
        spriteAnimator = gameObject.GetComponent<Animator>();
    }

    [YarnCommand("bro_talk")]
    public static void BroTalk() {
        spriteAnimator.SetBool("talking", true);
    }

    [YarnCommand("bro_shutup")]
    public static void BroShutUp() {
        spriteAnimator.SetBool("talking", false);
    }
}