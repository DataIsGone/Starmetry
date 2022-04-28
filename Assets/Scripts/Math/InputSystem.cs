using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    [SerializeField] private GameObject displayStrGameObject;
    private string thisStrChar;
    private string playerInput;

    private const string BLANK_ANSWER = "---";

    void Awake() {
        playerInput = BLANK_ANSWER;
    }

    void Start() {
        displayStrGameObject.GetComponent<TMPro.TextMeshProUGUI>().text = BLANK_ANSWER;
        DisplayInput();
    }

    void Update() {
        DisplayInput();
    }

    public void DisplayInput() {
        displayStrGameObject.GetComponent<TMPro.TextMeshProUGUI>().text = playerInput;
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
            // send to answer system
            MathAnswerSystem.CompareInput(decimal.Parse(GetInput()));
        }
        // need feedback for invalid submission
    }

    private bool ValidateInput() {
        return !(playerInput == BLANK_ANSWER);
    }

}
