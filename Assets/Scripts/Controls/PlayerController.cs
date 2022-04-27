using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController: MonoBehaviour
{

    public Camera cam;
    public UnityEngine.AI.NavMeshAgent player;
    // public Animator playerAnimator;
    public GameObject targetDest;

    public GameObject refUI;

    [SerializeField]
    private GameObject refSystem;

    public GameObject env;

    public AskMe sidekick;

    private Ray ray;
    private RaycastHit hitPoint;

    void Awake() {
        refUI.SetActive(false);
    }

    void Start() {
        gameObject.AddComponent<AskMe>();
    }

    void Update()
    {


        // if (player.velocity != Vector3.zero) {
        //     playerAnimator.SetBool("isWalking", true);
        // } else {
        //     playerAnimator.SetBool("isWalking", false);
        // }
        determineClick();
    }

    private void determineClick() {
        if (Input.GetMouseButtonDown(0)) {
            ray = cam.ScreenPointToRay(Input.mousePosition);

            // && checkIfClickable(hitPoint)
            if (Physics.Raycast(ray, out hitPoint)) {
                switch(hitPoint.collider.gameObject.tag) {
                    case "Player":
                        // do nothing
                        break;
                    case "Sidekick":
                        toggleSidekick();
                        break;
                    case "UI":
                        // do nothing?
                        break;
                    case "NPC":
                        // do nothing for now?
                        break;
                    default:
                        moveCharacter();
                        break;
                }
            }
        }
    }

    private void moveCharacter() {
        targetDest.transform.position = hitPoint.point;
        targetDest.SetActive(true); // Make target marker appear again after clicking
        player.SetDestination(hitPoint.point);
    }

    private void toggleSidekick() {
        sidekick.toggleMovementOff(env);

        // determine UI
        if (refSystem.activeSelf) {
            DialogSize(1);
        } else {
            DialogSize(0);
        }
        refUI.SetActive(true);
    }

    private void DialogSize(int option) {
        // option + 2 due to Answer section being Child 0 and Player Ref Bubble being Child 1
        refUI.transform.GetChild(option+2).gameObject.SetActive(true);
    }
}