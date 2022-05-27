using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class BirbbyAnimated : CharacterTalk
{
    static private Animator spriteAnimator;
    static private Color birbbyWindowColor;

    void Awake() {
        spriteAnimator = gameObject.GetComponent<Animator>();
        birbbyWindowColor = new Color(1f, 1f, 1f, 0.87f);
    }

    [YarnCommand("birbby_talk")]
    public static void BirbbyTalk() {
        FormatDefaultWindow();
        FormatDefaultContinue();
        spriteAnimator.SetBool("talking", true);
    }

    [YarnCommand("birbby_shutup")]
    public static void BirbbyShutUp() {
        spriteAnimator.SetBool("talking", false);
    }

    private static void FormatDefaultWindow() {
        GetImage().sprite = GetDefaultWindow();
        GetImage().color = birbbyWindowColor;
        GetTMP().color = Color.white;
        GetTMP().font = GetFont();
        GetTMP().fontSize = 96;
    }

    private static void FormatDefaultContinue() {
        GetContImage().sprite = GetContSprite();
        GetContTMP().font = GetFont();
        GetContTMP().fontSize = 80;
    }
}
