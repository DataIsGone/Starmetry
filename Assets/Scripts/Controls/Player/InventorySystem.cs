using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For the purposes of CS 406, this will only be used with Level 3
// I'm writing the system like this incase I want to add more to the game in the future
public class InventorySystem : MonoBehaviour
{
    public GameObject[] collectables;
    public decimal[] collectableValues;

    void Start()
    {
        collectables = GameObject.FindGameObjectsWithTag("Collectable");
        collectableValues = new decimal[collectables.Length];
        SetupValues();
    }

    private void SetValues() {
        var i = 0;
        foreach (decimal value in collectableValues) {
            collectables[i].GetComponent<Collectable>().value = value;
            i++;
        }
        Debug.Log(collectables[0].GetComponent<Collectable>().value);
    }

    private void SetupValues() {
        var origAnswer = YarnValues.GetValue2ForYarn("answer");
        Debug.Log("Inventory System | " + origAnswer);
    }



    // private void SaveValue() {

    // }


}
