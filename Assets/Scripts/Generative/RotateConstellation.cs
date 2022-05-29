using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class RotateConstellation : MonoBehaviour
{
    private float speed = 0.01f;
    private float timeCount = 0.01f;
    private Quaternion newRotation;

    void Start() {
        newRotation = new Quaternion(transform.rotation.x, transform.rotation.y, 90.0f, transform.rotation.w);
        this.enabled = false;
    }

    void Update() {
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, (timeCount * speed));
    }

    [YarnCommand("rotate_line")]
    public void RotateLine() {
        this.enabled = true;
    }
}
