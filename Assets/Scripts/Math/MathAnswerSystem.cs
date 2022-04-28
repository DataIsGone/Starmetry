using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class MathAnswerSystem : MonoBehaviour
{
    private static decimal playerAnswer;

    [YarnFunction("compare")]
    public static bool CompareInputYarn() {
        return playerAnswer == GetCurrAnswer();
    }

    private static decimal GetCurrAnswer() {
        //decimal answer = gameObject.GetComponent<YarnValues>().GetValueForYarn("answer");
        return YarnValues.GetValueForYarn("answer");
    }

    // private void SetPlayerAnswer(decimal thisAnswer) {
    //     playerAnswer = thisAnswer;
    // }

    public static void CompareInput(decimal thisAnswer) {
        playerAnswer = thisAnswer;
    }
}
