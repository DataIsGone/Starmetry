using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToPlayer : MonoBehaviour
{
    static private GameObject position3;
    static private Vector3 v3P3;

    void Awake() {
        position3 = GameObject.Find("Player");
        //Debug.Log(SceneEvents.player);

        v3P3 = position3.transform.position;
    }

    void Update()
    {
        SceneEvents.dummy.position = Vector3.Lerp(SceneEvents.dummy.position, v3P3, SceneEvents.speed * Time.deltaTime);
    }
}