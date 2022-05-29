using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputSystem : MonoBehaviour
{
    [SerializeField] private GameObject displayStrGameObject;
    private string thisStrChar;
    private string playerInput;
    private bool firstOpened;
    private const string BLANK_ANSWER = "---";

    void Awake() {
        playerInput = BLANK_ANSWER;
    }

    void Start() {
        firstOpened = true;
        displayStrGameObject.GetComponent<TextMeshProUGUI>().text = BLANK_ANSWER;
        DisplayInput();
    }

    void Update() {
        if (firstOpened) {
            firstOpened = false;
            ClearInput();
        }
        DisplayInput();
    }

    public void DisplayInput() {
        displayStrGameObject.GetComponent<TextMeshProUGUI>().text = playerInput;
    }

    public string GetInput() {
        return playerInput;
    }

    public void Click(string buttonValue) {
        if (playerInput == BLANK_ANSWER) {
            playerInput = "";
        }
        playerInput += buttonValue;
    }

    public void ClearInput() {
        playerInput = BLANK_ANSWER;
    }
    
    public void SubmitInput() {
        if (ValidateInput()) {
            var problem = StoryData.GetSceneName();
            MathAnswerSystem.CompareInput(decimal.Parse(GetInput()), ConfirmProblem());
        }
        // need feedback for invalid submission
        firstOpened = true;
    }

    private bool ValidateInput() {
        return !(playerInput == BLANK_ANSWER);
    }

    private int ConfirmProblem() {
        var levelName = StoryData.GetSceneName();
        var str = "Level";
        return int.Parse(levelName.Replace(str, ""));
    }
}
