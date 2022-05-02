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
    [SerializeField] private GameObject refSystem;
    public AskMe sidekick;
    private Ray ray;
    private RaycastHit hitPoint;
    [SerializeField] private GameObject env;

    void Awake() {
        refUI.SetActive(false);
    }

    void Start() {
        
    }

    void Update()
    {


        // if (player.velocity != Vector3.zero) {
        //     playerAnimator.SetBool("isWalking", true);
        // } else {
        //     playerAnimator.SetBool("isWalking", false);
        // }
        DetermineClick();
    }

    private void DetermineClick() {
        if (Input.GetMouseButtonDown(0)) {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitPoint)) {
                switch(hitPoint.collider.gameObject.tag) {
                    case "Player":
                    case "Unclickable":
                        // do nothing
                        break;
                    case "Sidekick":
                        ToggleSidekick();
                        break;
                    case "UI":
                        // do nothing?
                        break;
                    case "NPC":
                        // do nothing for now?
                        StopPlayer();
                        break;
                    default:
                        MovePlayer();
                        break;
                }
            }
        }
    }

    private void MovePlayer() {
        targetDest.transform.position = hitPoint.point;
        targetDest.SetActive(true); // Make target marker appear again after clicking
        player.SetDestination(hitPoint.point);
    }

    public void StopPlayer() {
        targetDest.SetActive(false);
        hitPoint.point = player.transform.position;
        player.SetDestination(hitPoint.point);
    }

    private void ToggleSidekick() {
        sidekick.ToggleMovementOff(env);

        // determine UI
        if (refSystem.activeSelf) {
            sidekick.SmDialogueSize();
        } else {
            sidekick.OrigDialogueSize();
        }
        //refUI.SetActive(true);
    }
}