using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindAllGameObjects : MonoBehaviour
{
    public const int NUM_CHARS = 2;

    //[SerializeField] GameObject[] unclickableGameObjects;
    [SerializeField] GameObject[] envGameObjects;
    [SerializeField] GameObject[] charGameObjects;

    void Awake() {
        //unclickableGameObjects = GameObject.FindGameObjectsWithTag("Unclickable");
        charGameObjects = new GameObject[NUM_CHARS];
        // charGOs[0] = ;
        // charGOs[1] = ;
    }

    void Start() {
        envGameObjects = GameObject.FindGameObjectsWithTag("Environment");
        charGameObjects[0] = GameObject.Find("Player");
        charGameObjects[1] = GameObject.Find("Sidekick");
    }
}
