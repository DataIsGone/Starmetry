using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For the purposes of CS 406, this will only be used with Level 3
// I'm writing the system like this incase I want to add more to the game in the future
public class InventorySystem : MonoBehaviour
{
    // Start is called before the first frame update

    public List<int> inventoryValues;

    void Start()
    {
        inventoryValues = new List<int>();    
    }

    public void GetValue() {

    }

    private void SaveValue() {

    }


}
