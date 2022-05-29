using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnValues : MonoBehaviour
{
    public GameObject mathManager;
    public static List<decimal> currProblem;
    public static List<decimal> currProblem2;
    public static List<decimal> currProblem3;

    public void AssignCurrProblem(string probType) {
        switch (probType) {
            case "angle":
                var angleGen = mathManager.GetComponent<AngleProblemGenerator>();
                currProblem = angleGen.CreateCompAngleProblem();
                currProblem2 = angleGen.CreateSuppAngleProblem();
                currProblem3 = angleGen.CreateRightAngleProblem();
                break;
            case "area/circ":
                currProblem = mathManager.GetComponent<RectAreaProblemGenerator>().CreateRectAreaProblem();
                currProblem2 = mathManager.GetComponent<CircumferenceProblemGenerator>().CreateCircProblem();
                break;
            case "vol":
                currProblem = mathManager.GetComponent<RectVolumeProblemGenerator>().CreateRectVolProblem();
                currProblem2 = mathManager.GetComponent<CylinderVolumeProblemGenerator>().CreateCylinderVolProblem();
                break;
            default:
                Debug.Log("Unable to assign a problem to this area.");
                break;
        }
    }

    [YarnFunction("get_piece")]
    public static decimal GetValueForYarn(string item) {
        switch (item) {
            case "answer":
                return currProblem[0];
            case "length":
                return currProblem[1];
            case "width":
                return currProblem[2];
            case "radius":
                return currProblem[1];
            case "cynHeight":
                return currProblem[2];
            case "rectHeight":
                return currProblem[3];
            case "angle":
                return currProblem[1];
            default:
                Debug.Log("Could not find requested item at currProblem[" + item + "]. Using 0 instead.");
                return 0M;
        }
    }

    [YarnFunction("get_piece2")]
    public static decimal GetValue2ForYarn(string item) {
        switch (item) {
            case "answer":
                return currProblem2[0];
            case "length":
                return currProblem2[1];
            case "width":
                return currProblem2[2];
            case "radius":
                return currProblem2[1];
            case "cynHeight":
                return currProblem2[2];
            case "rectHeight":
                return currProblem2[3];
            case "angle":
                return currProblem2[1];
            default:
                Debug.Log("Could not find requested item at currProblem2[" + item + "]. Using 0 instead.");
                return 0M;
        }
    }

    [YarnFunction("get_piece3")]
    public static decimal GetValue3ForYarn(string item) {
        switch (item) {
            case "answer":
                return currProblem3[0];
            case "angle":
                return currProblem3[1];
            default:
                Debug.Log("Could not find requested item at currProblem3[" + item + "]. Using 0 instead.");
                return 0M;
        }
    }

}
