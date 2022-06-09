using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSounds : MonoBehaviour
{
    public AudioSource riverSound;

    void Start() {
        riverSound.volume = 0.05f;
    }

    private void OnTriggerEnter(Collider other) {
        riverSound.volume = 0.2f;
    }
}
