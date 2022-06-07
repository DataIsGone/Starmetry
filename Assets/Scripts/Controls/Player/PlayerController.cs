using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController: MonoBehaviour
{

    public Camera cam;
    public UnityEngine.AI.NavMeshAgent player;
    public Animator playerAnimator;
    public Animator sidekickAnimator;
    public GameObject targetDest;
    public GameObject refUI;
    [SerializeField] private GameObject refSystem;
    public AskMe sidekick;
    private Ray ray;
    private RaycastHit hitPoint;
    [SerializeField] private GameObject env;
    public SpriteRenderer playerSpriteRenderer;
    public SpriteRenderer sidekickSpriteRenderer;
    //public Animator flipAnim;

    void Awake() {
        refUI.SetActive(false);
    }

    void Update()
    {
        SetCurrSprite();
        DetermineClick();
    }

    private void DetermineClick() {
        if (Input.GetMouseButtonDown(0)) {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitPoint)) {
                Debug.Log(hitPoint.collider.gameObject.tag); // TODO: REMOVE
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
                        StopPlayer();
                        break;
                    case "NPC":
                        // do nothing for now?
                        StopPlayer();
                        break;
                    case "Collectable":
                        // invoke collectable
                        break;
                    default:
                        MovePlayer();
                        break;
                }
            }
        }
    }

    private void MovePlayer() {
        FlipSprite();
        targetDest.transform.position = hitPoint.point;
        targetDest.SetActive(true); // Make target marker appear again after clicking
        player.SetDestination(hitPoint.point);
    }

    private void FlipSprite() {
        if (ray.direction.x > 0) {
            playerSpriteRenderer.flipX = true;
            sidekickSpriteRenderer.flipX = true;
            //flipAnim.SetTrigger("Flip");
        }
        else {
            playerSpriteRenderer.flipX = false;
            sidekickSpriteRenderer.flipX = false;
        }
    }

    private void SetCurrSprite() {
        if (player.velocity != Vector3.zero) {
            SetMovingSprite();
        } else {
            SetIdlingSprite();
        }
    }

    private void SetMovingSprite() {
        playerAnimator.SetBool("isMoving", true);
        sidekickAnimator.SetBool("playerMoving", true);
    }

    private void SetIdlingSprite() {
        playerAnimator.SetBool("isMoving", false);
        sidekickAnimator.SetBool("playerMoving", false);
    }

    public void StopPlayer() {
        targetDest.SetActive(false);
        hitPoint.point = player.transform.position;
        player.SetDestination(hitPoint.point);
    }

    private void ToggleSidekick() {
        ChangeEnvironment.DisableMovement();
        StopPlayer();

        // determine UI
        if (refSystem.activeSelf) {
            sidekick.SmDialogueSize();
        } else {
            sidekick.OrigDialogueSize();
        }
    }
}