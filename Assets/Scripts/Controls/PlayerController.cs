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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;
            // Make target marker appear again after clicking
            targetDest.SetActive(true);

            if (Physics.Raycast(ray, out hitPoint) && checkIfClickable(hitPoint)) {
                targetDest.transform.position = hitPoint.point;
                player.SetDestination(hitPoint.point);
            }
        }

        // if (player.velocity != Vector3.zero) {
        //     playerAnimator.SetBool("isWalking", true);
        // } else {
        //     playerAnimator.SetBool("isWalking", false);
        // }
    }

    bool checkIfClickable(RaycastHit hitPoint) {
        if (hitPoint.collider.gameObject.tag == "Unclickable") {
            return false;
        }
        if (hitPoint.collider.gameObject.tag == "Player") {
            return false;
        }
        return true;
    }
}