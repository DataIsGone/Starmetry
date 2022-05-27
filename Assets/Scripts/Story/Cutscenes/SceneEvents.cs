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
    public static L3Intro introL3Cutscene;
    public static PanBall introL3Cutscene2;
    public static WheelSpin wheelSpinCutscene;
    public static FollowBall followBallCutscene;
    public static BackToPlayer backToPlayerCutscene;

    public static bool catalystL3;

    void Awake() {
        catalystL3 = false;

        player = GameObject.Find("Player");
        mainCam = Camera.main.GetComponent<CameraController>();
        speed = 5f;

        introL3Cutscene = gameObject.GetComponent<L3Intro>();
        introL3Cutscene2 = gameObject.GetComponent<PanBall>();
        wheelSpinCutscene = gameObject.GetComponent<WheelSpin>();
        followBallCutscene = gameObject.GetComponent<FollowBall>();
        backToPlayerCutscene = gameObject.GetComponent<BackToPlayer>();

        cutsceneFinished = false;
    }

    void Start() {
        dummy = GameObject.Find("CamDummy").transform;
        ResetCutscene();
    }

    [YarnCommand("l3_catalyst")]
    static bool CheckWheel() {
        return catalystL3;
    }

    [YarnCommand("l3_beginning")]
    static IEnumerator L3BeginningCam() {
        ResetCutscene();
        mainCam.target = dummy;
        introL3Cutscene2.enabled = true;

        toBallIntro:
            yield return new WaitForSeconds(2);
            Debug.Log("hit 0");

        Debug.Log(PanBall.cutscene4);
        if (PanBall.cutscene4) {
            Debug.Log("hit 1");
            introL3Cutscene2.enabled = false;
            introL3Cutscene.enabled = true;

            toPlayerIntro:
                yield return new WaitForSeconds(2);

            if (L3Intro.cutscene0) {
                Debug.Log("hit 2");
                introL3Cutscene.enabled = false;
                backToPlayerCutscene.enabled = true;
                mainCam.target = player.transform;
                cutsceneFinished = true;
            } else {
                goto toPlayerIntro;
            }
        } else {
            goto toBallIntro;
        }

        yield return new WaitUntil(() => cutsceneFinished);
    }

    [YarnCommand("l3_complete")]
    static IEnumerator L3CompleteCam() {
        ResetCutscene();
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

    static private void ResetCutscene() {
        cutsceneFinished = false;
        introL3Cutscene.enabled = false;
        introL3Cutscene2.enabled = false;
        wheelSpinCutscene.enabled = false;
        followBallCutscene.enabled = false;
        backToPlayerCutscene.enabled = false;
    }
}
