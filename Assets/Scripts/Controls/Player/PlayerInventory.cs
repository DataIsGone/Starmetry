using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static decimal currPlayerValue;
    
    void Start()
    {
        currPlayerValue = 0M;
    }

    public static void SetValue(decimal value) {
        currPlayerValue = value;
    }

    public static decimal GetValue() {
        return currPlayerValue;
    }
}
