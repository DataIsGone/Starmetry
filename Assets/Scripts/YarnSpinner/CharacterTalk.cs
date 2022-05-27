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
    static protected GameObject continueButton;
    static protected Image continueButtonBG;
    static protected Sprite continueButtonSprite;
    static protected TMPro.TextMeshProUGUI continueText;

    void Awake() {
        dialogue = GameObject.Find("Main Dialogue Bubble");
        dialogueBGGO = dialogue.transform.GetChild(0).gameObject;
        dialogueBG = dialogueBGGO.GetComponent<Image>();
        continueButton = GameObject.Find("Dialogue Continue Button");
        continueButtonBG = continueButton.GetComponent<Image>();
        continueButtonSprite = continueButtonBG.sprite;
        continueText = continueButton.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        dialogueText = dialogueBGGO.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        defaultWindow = dialogueBG.sprite;
        defaultFont = Resources.Load<TMPro.TMP_FontAsset>("Fonts/Bitty SDF");
    }

    public static Image GetImage() {
        return dialogueBG;
    }

    public static Image GetContImage() {
        return continueButtonBG;
    }

    public static Sprite GetContSprite() {
        return continueButtonSprite;
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

    public static TMPro.TextMeshProUGUI GetContTMP() {
        return continueText;
    }
}
