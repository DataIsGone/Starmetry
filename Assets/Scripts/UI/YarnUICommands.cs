using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnUICommands : MonoBehaviour
{
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
    [SerializeField] private GameObject contBut;
    [SerializeField] private GameObject answerMode;

    // [YarnCommand("toggle_answer")]
    // public void ToggleAnswerMode(bool mode = true) {
    //     // Debug.Log("contBut: " + contBut.activeSelf);
    //     // Debug.Log("ToggleAnswerMode: " + mode);
    //     contBut.SetActive(!mode);
    //     // Debug.Log("contBut: " + contBut.activeSelf);
    //     answerMode.SetActive(mode);
    // }

    // [YarnCommand("answer_on")]
    // public static void StartAnswerMode() {
    //     Debug.Log("Answer Mode On");
    //     contBut.SetActive(false);

    // }

    // [YarnCommand("answer_off")]
    // public static void StopAnswerMode() {
    //     Debug.Log("Answer Mode Off");
    // }

}
