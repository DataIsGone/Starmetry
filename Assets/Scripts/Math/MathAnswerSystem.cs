using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class MathAnswerSystem : MonoBehaviour
{
    public static GameObject answerMode;
    private static decimal playerAnswer;
    private static bool playerAnswered;
    const string ASP = "DialogueCanvas";

    void Start() {
        var answerModeParent = GameObject.Find(ASP);
        answerMode = answerModeParent.transform.Find("Answer Mode").gameObject;
    }

    [YarnFunction("compare")]
    public static bool CompareInputYarn() {
        answerMode.SetActive(false);
        playerAnswered = true;
        return playerAnswer == GetCurrAnswer();
    }

    private static decimal GetCurrAnswer() {
        return YarnValues.GetValueForYarn("answer");
    }

    public static void CompareInput(decimal thisAnswer) {
        playerAnswer = thisAnswer;
        CompareInputYarn();
    }

    public static void StartAnswer() {
        playerAnswered = false;
        answerMode.SetActive(true);
    }

    [YarnCommand("player_answering")]
    static IEnumerator PlayerAnswering() {
        Debug.Log("Answer mode started");
        StartAnswer();
        yield return new WaitUntil(() => playerAnswered); // player has submitted answer
        Debug.Log("Finished");
    }
}
