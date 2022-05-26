using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class StoryData : MonoBehaviour
{
    public int topicsUnlocked;
    //public GameObject yarnValues;
    private YarnValues problems;
    private const string SCENE_1 = "Level1";
    private const string SCENE_2 = "Level2";
    private const string SCENE_3 = "Level3";

    public static string currString;

    void Awake() {
        topicsUnlocked = 12; // TODO: TEST -- CHANGE LATER
    }

    void Start() {
        currString = SceneManager.GetActiveScene().name;
        var yarnValues = GameObject.Find("StoryDataManager");
        problems = yarnValues.GetComponent<YarnValues>();
        GenerateLevelProblems();
    }

    [YarnFunction("scene_name")]
    public static string GetSceneName() {
        return currString;
    }

    public static void RefreshSceneName() {
        currString = SceneManager.GetActiveScene().name;
    }

    public void UnlockTopic(int num) {
        topicsUnlocked += num;
    }

    public int GetNumTopicsUnlocked() {
        return topicsUnlocked;
    }

    private void GenerateLevelProblems() {
        switch (currString) {
            case SCENE_1:
                problems.AssignCurrProblem("angle");
                break;
            case SCENE_2:
                problems.AssignCurrProblem("area/circ");
                break;
            case SCENE_3:
                problems.AssignCurrProblem("vol");
                break;
            default:
                Debug.Log("An applicable scene was not found.");
                return;
        }
    }
}
