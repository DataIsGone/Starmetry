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

    public GameObject env;

    public AskMe sidekick;

    void Awake() {
        refUI.SetActive(false);
    }

    void Start() {
        gameObject.AddComponent<AskMe>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;
            
            // Make target marker appear again after clicking
            targetDest.SetActive(true);

            // && checkIfClickable(hitPoint)
            if (Physics.Raycast(ray, out hitPoint)) {
                // check for click on sidekick
                if (hitPoint.collider.gameObject.tag == "Sidekick") {
                    sidekick.toggleMovementOff(env);
                    refUI.SetActive(true);
                } else {
                    targetDest.transform.position = hitPoint.point;
                    player.SetDestination(hitPoint.point);
                }
            }
        }

        // if (player.velocity != Vector3.zero) {
        //     playerAnimator.SetBool("isWalking", true);
        // } else {
        //     playerAnimator.SetBool("isWalking", false);
        // }
    }

    // REMOVE
    // private bool checkIfClickable(RaycastHit hitPoint) {
    //     if (hitPoint.collider.gameObject.tag == "Unclickable") {
    //         return false;
    //     }
    //     if (hitPoint.collider.gameObject.tag == "Player") {
    //         return false;
    //     }
    //     return true;
    // }

}