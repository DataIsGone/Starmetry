using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    private bool isCloseEnough;

    void Awake() {
        isCloseEnough = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        isCloseEnough = true;
    }

    void OnTriggerExit(Collider other)
    {
        isCloseEnough = false;
    }

    public bool GetProximity() {
        return isCloseEnough;
    }
}
