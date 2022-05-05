using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryData : MonoBehaviour
{
    public int topicsUnlocked;
    //public GameObject yarnValues;
    private YarnValues problems;
    private const string SCENE_1 = "Level1";
    private const string SCENE_2 = "Level2";
    private const string SCENE_3 = "Level3";

    void Awake() {
        topicsUnlocked = 3; // TODO: TEST -- CHANGE LATER
    }

    void Start() {
        var yarnValues = GameObject.Find("StoryDataManager");
        problems = yarnValues.GetComponent<YarnValues>();
        GenerateLevelProblems();
    }

    public void UnlockTopic(int num) {
        topicsUnlocked += num;
    }

    public int GetNumTopicsUnlocked() {
        return topicsUnlocked;
    }

    private void GenerateLevelProblems() {
        var sceneName = SceneManager.GetActiveScene().name;
        switch (sceneName) {
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
