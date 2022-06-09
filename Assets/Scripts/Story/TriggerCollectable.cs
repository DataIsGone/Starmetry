using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCollectable : MonoBehaviour
{
    private Collectable collectable;
    private Outline outline;

    void Awake() {
        collectable = GetComponent<Collectable>();
        collectable.enabled = false;

        outline = GetComponent<Outline>();
        outline.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        collectable.enabled = true;
        outline.enabled = true;
    }

    void OnTriggerExit(Collider other)
    {
        collectable.enabled = false;
        outline.enabled = false;
    }
}
