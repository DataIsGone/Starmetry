using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L3Intro : MonoBehaviour
{
    static private GameObject position0;
    static private Vector3 v3P0;
    static public bool cutscene0;

    void Awake() {
        position0 = GameObject.Find("Player");

        v3P0 = position0.transform.position;
        cutscene0 = false;
    }

    void Update()
    {
        SceneEvents.dummy.position = Vector3.Lerp(SceneEvents.dummy.position, v3P0, SceneEvents.speed * Time.deltaTime);
        if (SceneEvents.dummy.position == v3P0) {cutscene0 = true;}
    }
}
