using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PlayerInventory : MonoBehaviour
{
    public static decimal currPlayerValue;
    public static bool hasWheel;
    private const decimal BASE_VALUE = 0M;
    
    void Start()
    {
        currPlayerValue = 0M;
        hasWheel = false;
    }

    public static void SetValue(decimal value) {
        currPlayerValue = value;
    }

    [YarnFunction("player_wheel_value")]
    public static decimal GetValue() {
        return currPlayerValue;
    }

    public static decimal GetBaseValue() {
        return BASE_VALUE;
    }

    [YarnFunction("check_has_wheel")]
    public static bool GetWheelStatus() {
        return hasWheel;
    }

    [YarnFunction("flip_wheel")]
    public static bool ChangeWheelStatus() {
        hasWheel = !hasWheel;
        return hasWheel;
    }
}
