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
    public static bool CompareInputYarn(int problem) {
        if (problem == 1) {
            answerMode.SetActive(false);
        } else {
            //SetValue("$");
            // find game component holding item value
            // playerAnswer == item value;
        }
        playerAnswered = true;
        return playerAnswer == GetCurrAnswer(problem);
    }

    private static decimal GetCurrAnswer(int problem) {
        if (problem == 1) {
            return YarnValues.GetValueForYarn("answer");
        } else {
            // return problem 2 answer
            return YarnValues.GetValue2ForYarn("answer");
        }
    }

    public static void CompareInput(decimal thisAnswer) {
        playerAnswer = thisAnswer;
        CompareInputYarn(1);    // only currProblem needs input from Answer Mode, not currProblem2
    }

    public static void StartAnswer() {
        playerAnswered = false;
        answerMode.SetActive(true);
    }

    [YarnCommand("math_answering")]
    static IEnumerator PlayerAnswering() {
        Debug.Log("Math Answer mode started");
        StartAnswer();
        yield return new WaitUntil(() => playerAnswered); // player has submitted answer
        Debug.Log("Finished PlayerAnswering()");
    }
}
