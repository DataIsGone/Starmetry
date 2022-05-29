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
        if (problem == 2 && StoryData.GetSceneName() == StoryData.GetSceneConst(2)) {
            playerAnswer = PlayerInventory.GetValue();
        }
        else {
            answerMode.SetActive(false);
        }

        playerAnswered = true;
        return playerAnswer == GetCurrAnswer(problem);
    }

    public static decimal GetCurrAnswer(int problem) {
        if (problem == 1) {
            return YarnValues.GetValueForYarn("answer");
        } 
        else if (problem == 2) {
            // return problem 2 answer
            return YarnValues.GetValue2ForYarn("answer");
        }
        else {
            return YarnValues.GetValue3ForYarn("answer");
        }
    }

    public static void CompareInput(decimal thisAnswer, int problem) {
        playerAnswer = thisAnswer;
        // only currProblem & currProblem3 needs input from Answer Mode, not currProblem2
        // if (problem == 1) {CompareInputYarn(1);}
        // //CompareInputYarn(1);
        // else if (problem == 3) {CompareInputYarn(3);}
        CompareInputYarn(problem);
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
