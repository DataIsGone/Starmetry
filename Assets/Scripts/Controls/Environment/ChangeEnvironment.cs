using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEnvironment : MonoBehaviour
{
    public static GameObject envObject;
    const string ENV = "Land";

    void Start() {
        envObject = GameObject.Find(ENV);
    }

    public static void DisableMovement() {
        envObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        
    }

    public static void EnableMovement() {
        envObject.layer = LayerMask.NameToLayer("Default");
    }
}
