using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnValues : MonoBehaviour
{
    [SerializeField] private GameObject mathManager;

    private static List<decimal> currProblem;
    private static List<decimal> currProblem2;

    void Start()
    {
        // TODO: TEST, REMOVE
        currProblem = mathManager.GetComponent<RectAreaProblemGenerator>().CreateRectAreaProblem();
    }

    private void AssignCurrProblem(string probType) {
        switch (probType) {
            case "angle":
                currProblem = mathManager.GetComponent<AngleProblemGenerator>().CreateCompAngleProblem();
                currProblem2 = mathManager.GetComponent<AngleProblemGenerator>().CreateSuppAngleProblem();
                break;
            case "area":
                currProblem = mathManager.GetComponent<RectAreaProblemGenerator>().CreateRectAreaProblem();
                break;
            case "circ":
                currProblem = mathManager.GetComponent<CircumferenceProblemGenerator>().CreateCircProblem();
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
}
