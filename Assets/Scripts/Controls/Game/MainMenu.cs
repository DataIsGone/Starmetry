using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public const string LEVEL = "Level3";
    public GameObject optionsScreen;
    [SerializeField] LevelTransition fade;

    public void StartGame() {
        fade.FadeToLevel(1);
    }   

    public void OpenOptions() {
        optionsScreen.SetActive(true);
    } 

    public void CloseOptions() {
        optionsScreen.SetActive(false);
    }

    public void QuitGame() {
        Application.Quit();
        Debug.Log("Quitting");
    }

}
