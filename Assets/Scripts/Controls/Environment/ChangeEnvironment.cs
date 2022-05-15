using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEnvironment : MonoBehaviour
{
    public static GameObject envObject;
    public static GameObject bridgeObject;
    public static GameObject rampObject;

    const string ENV = "Land";
    const string RAMP = "Ramp";
    const string BRIDGE = "Bridge";

    void Start() {
        envObject = GameObject.Find(ENV).gameObject;
        rampObject = GameObject.Find(RAMP).gameObject;
        bridgeObject = GameObject.Find(BRIDGE).gameObject;
    }

    public static void DisableMovement() {
        envObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        rampObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        bridgeObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        
    }

    public static void EnableMovement() {
        envObject.layer = LayerMask.NameToLayer("Default");
        rampObject.layer = LayerMask.NameToLayer("Default");
        bridgeObject.layer = LayerMask.NameToLayer("Default");
    }
}
