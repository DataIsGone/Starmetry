using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    static private Animator irrigationAnimator;
    static private GameObject position2;
    static private Vector3 v3P2;
    static public bool cutscene2;

    void Awake() {
        position2 = GameObject.Find("CamPosBox");
        irrigationAnimator = GameObject.Find("Irrigation Box").GetComponent<Animator>();

        v3P2 = position2.transform.position;
        cutscene2 = false;
    }

    void Start() {
        RotateBox();
    }

    void Update()
    {
        SceneEvents.dummy.position = Vector3.Lerp(SceneEvents.dummy.position, v3P2, SceneEvents.speed * Time.deltaTime);
        if (SceneEvents.dummy.position == v3P2) {cutscene2 = true;}
    }

    public static void RotateBox() {
        irrigationAnimator.Play("box_rotate");
    }
}
