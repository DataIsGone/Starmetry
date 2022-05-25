using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class CharacterTalk : MonoBehaviour
{
    //static protected Animator spriteAnimator;
    static protected GameObject dialogue;
    static protected GameObject dialogueBGGO;
    static protected Image dialogueBG;
    static protected TMPro.TextMeshProUGUI dialogueText;
    static protected Sprite defaultWindow;
    static protected TMPro.TMP_FontAsset defaultFont;
    // static protected Color defaultColor;

    void Awake() {
        dialogue = GameObject.Find("Main Dialogue Bubble");
        dialogueBGGO = dialogue.transform.GetChild(0).gameObject;
        dialogueBG = dialogueBGGO.GetComponent<Image>();
        dialogueText = dialogueBGGO.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        defaultWindow = dialogueBG.sprite;
        defaultFont = Resources.Load<TMPro.TMP_FontAsset>("Fonts/Bitty SDF");
        // defaultColor = Color(1f, 1f, 1f, 0.87f);
    }

    public static Image GetImage() {
        return dialogueBG;
    }

    public static Sprite GetDefaultWindow() {
        return defaultWindow;
    }

    public static TMPro.TextMeshProUGUI GetTMP() {
        return dialogueText;
    }

    public static TMPro.TMP_FontAsset GetFont() {
        return defaultFont;
    }

    // public static Color GetSpriteColor() {
    //     return defaultColor;
    // }


    
}
