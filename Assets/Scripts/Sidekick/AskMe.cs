using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class AskMe : MonoBehaviour
{
    int ignoreRaycast;
    int defaultLayer;

    public GameObject env;
    
    public GameObject scroll;

    public GameObject dialogueView;
    public GameObject dialogueText;

    private Vector4 origTextMargin;
    private Vector4 smTextMargin;
    private Vector3 origWindowPos;
    private Vector3 smWindowPos;
    private Vector2 smSizeDelta;
    private Vector2 origSizeDelta;
    private RectTransform dialogueViewRect;
    private TMPro.TextMeshProUGUI dialogueTextTMP;

    private const float SM_POS_X = 115f;
    private const float SM_WIDTH = 110f;
    private const float SM_MARGIN_LR = 130f;

    private const string REF_DIALOGUE_P = "ReferenceDialogueCanvas";

    private static bool clickedGoals, clickedRef, clickedClose;
    private static bool playerAnswered;
    public static GameObject answerMode;

    void Start() {
        var answerModeParent = GameObject.Find(REF_DIALOGUE_P);
        answerMode = answerModeParent.transform.Find("Player Ref Bubble").gameObject;

        dialogueViewRect = dialogueView.GetComponent<RectTransform>();
        dialogueTextTMP = dialogueText.GetComponent<TMPro.TextMeshProUGUI>();

        origWindowPos = dialogueView.transform.position;
        smWindowPos = new Vector3(origWindowPos.x + SM_POS_X, origWindowPos.y, origWindowPos.z);
        //smWindowPos = new Vector3((origWindowPos.x + (origWindowPos.x * 0.3f)), origWindowPos.y, origWindowPos.z);

        origTextMargin = dialogueTextTMP.margin;
        smTextMargin = new Vector4(origTextMargin.x + SM_MARGIN_LR, origTextMargin.y, origTextMargin.z - SM_MARGIN_LR, origTextMargin.w);

        origSizeDelta = dialogueViewRect.sizeDelta;
        smSizeDelta = new Vector2(origSizeDelta[0] - SM_WIDTH, origSizeDelta[1]);

        ignoreRaycast = LayerMask.NameToLayer("Ignore Raycast");
        defaultLayer = LayerMask.NameToLayer("Default");
    }

    public void ToggleMovementOff(GameObject env) {
        env.layer = ignoreRaycast;
    }

    public void ToggleMovementOn(GameObject env) {
        env.layer = defaultLayer;
    }

    public void StopAsking(GameObject env) {
        clickedClose = true;
        answerMode.SetActive(false);
        ToggleMovementOn(env);
    }

    public void OpenScrollWindow() {
        SmDialogueSize();
        playerAnswered = true;
        clickedRef = true;
        scroll.SetActive(true);
    }

    public void CloseScrollWindow() {
        clickedClose = true;
        OrigDialogueSize();
        scroll.SetActive(false);
    }

    public void SmDialogueSize() {
        dialogueView.transform.position = smWindowPos;
        dialogueViewRect.sizeDelta = smSizeDelta;
        dialogueTextTMP.margin = smTextMargin;
    }

    public void OrigDialogueSize() {
        dialogueView.transform.position = origWindowPos;
        dialogueViewRect.sizeDelta = origSizeDelta;
        dialogueTextTMP.margin = origTextMargin;
    }

    [YarnFunction("goals")]
    public static bool RemindGoals() {
        answerMode.SetActive(false);
        return clickedGoals;
    }

    public void RemindGoalsHelper() {
        clickedGoals = true;
        playerAnswered = true;
    }

    [YarnFunction("ref")]
    public static bool OpenRef() {
        answerMode.SetActive(false);
        Debug.Log(clickedRef);
        return clickedRef;
    }

    [YarnFunction("close")]
    public static bool Nevermind() {
        playerAnswered = true;
        return clickedClose;
    }

    private static void StartAnswer() {
        playerAnswered = false;
        clickedGoals = false;
        clickedRef = false;
        clickedClose = false;
        answerMode.SetActive(true);
    }

    [YarnCommand("ref_answering")]
    static IEnumerator RefAnswering() {
        Debug.Log("Ref Answer mode started");
        StartAnswer();
        yield return new WaitUntil(() => playerAnswered);
        Debug.Log("Finished RefAnswering()");
    }
}
