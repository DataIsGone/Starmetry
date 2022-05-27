using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanBall : MonoBehaviour
{
    static private GameObject position4;
    static private Vector3 v3P4;
    static public bool cutscene4;

    void Awake() {
        position4 = GameObject.Find("CamPosBox");

        v3P4 = position4.transform.position;
        cutscene4 = false;
    }

    void Update()
    {
        SceneEvents.dummy.position = Vector3.Lerp(SceneEvents.dummy.position, v3P4, SceneEvents.speed * Time.deltaTime);
        if (SceneEvents.dummy.position == v3P4) {cutscene4 = true;}
    }
}
