using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SceneEvents : MonoBehaviour
{
    static public CameraController mainCam;
    [SerializeField] private GameObject wheelModel;
    static public GameObject player;
    static public bool cutsceneFinished;
    static public Transform dummy;
    public static float speed;
    public static WheelSpin wheelSpinCutscene;
    public static FollowBall followBallCutscene;
    public static BackToPlayer backToPlayerCutscene;

    void Awake() {
        wheelModel.SetActive(true);
        player = GameObject.Find("Player");
        mainCam = Camera.main.GetComponent<CameraController>();
        speed = 5f;

        wheelSpinCutscene = gameObject.GetComponent<WheelSpin>();
        followBallCutscene = gameObject.GetComponent<FollowBall>();
        backToPlayerCutscene = gameObject.GetComponent<BackToPlayer>();

        cutsceneFinished = false;
    }

    void Start() {
        dummy = GameObject.Find("CamDummy").transform;

        wheelSpinCutscene.enabled = false;
        followBallCutscene.enabled = false;
        backToPlayerCutscene.enabled = false;
    }

    [YarnCommand("l3_complete")]
    static IEnumerator L3CompleteCam() {
        mainCam.target = dummy;
        wheelSpinCutscene.enabled = true;

        yield return new WaitForSeconds(5);

        if (WheelSpin.cutscene1) {
            wheelSpinCutscene.enabled = false;
            followBallCutscene.enabled = true;

            yield return new WaitForSeconds(5);

            if (FollowBall.cutscene2) {
                followBallCutscene.enabled = false;
                backToPlayerCutscene.enabled = true;
                cutsceneFinished = true;
            }
        }
        yield return new WaitUntil(() => cutsceneFinished);
    }
}
