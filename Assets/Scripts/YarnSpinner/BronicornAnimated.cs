using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class BronicornAnimated : CharacterTalk
{
    static private Animator spriteAnimator;
    static private Sprite broWindow;
    static private Sprite broContButton;
    static private Color broWindowColor;
    static private TMPro.TMP_FontAsset broFont;

    void Awake() {
        spriteAnimator = gameObject.GetComponent<Animator>();
        broWindow = Resources.Load<Sprite>("UI/bronicorn_dialogue_window");
        broContButton = Resources.Load<Sprite>("UI/bronicorn_dialogue_continue");
        broFont = Resources.Load<TMPro.TMP_FontAsset>("Fonts/ThaleahFat SDF");
        broWindowColor = new Color(1f, 1f, 1f, 1f);
    }

    [YarnCommand("bro_talk")]
    public static void BroTalk() {
        FormatBroWindow();
        FormatBroContinue();
        spriteAnimator.SetBool("talking", true);
    }

    [YarnCommand("bro_shutup")]
    public static void BroShutUp() {
        spriteAnimator.SetBool("talking", false);
    }

    private static void FormatBroWindow() {
        GetImage().sprite = broWindow;
        GetImage().color = broWindowColor;
        GetTMP().color = Color.black;
        GetTMP().font = broFont;
        GetTMP().fontSize = 60;
    }

    private static void FormatBroContinue() {
        GetContImage().sprite = broContButton;
        GetContTMP().font = broFont;
        GetContTMP().fontSize = 45;
    }
}