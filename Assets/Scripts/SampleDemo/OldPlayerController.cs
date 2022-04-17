using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed, jumpForce;
    private Vector2 moveInput;

    public LayerMask whatIsGround;
    public Transform groundPoint;
    private bool isGrounded;
    // Start is called before the first frame update

    public Animator anim;

    public SpriteRenderer sr;

    private bool moveBackwards;

    public Animator flipAnim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();

        rb.velocity = new Vector3(moveInput.x * moveSpeed, rb.velocity.y, moveInput.y * moveSpeed);

        anim.SetFloat("moveSpeed", rb.velocity.magnitude);

        RaycastHit hit;
        if (Physics.Raycast(groundPoint.position, Vector3.down, out hit, .3f, whatIsGround)) {
            isGrounded = true;
        }
        else {
            isGrounded = false;
        }

        if (Input.GetButtonDown("Jump") && isGrounded) {
            rb.velocity += new Vector3(0f, jumpForce, 0f);
        }

        anim.SetBool("onGround", isGrounded);

        if( !sr.flipX && moveInput.x < 0) {
            sr.flipX = true;
            flipAnim.SetTrigger("Flip");
        }
        else if (sr.flipX && moveInput.x > 0) {
            sr.flipX = false;
            flipAnim.SetTrigger("Flip");
        }

        if (!moveBackwards && moveInput.y > 0) {
            moveBackwards = true;
            flipAnim.SetTrigger("Flip");
        } else if (moveBackwards && moveInput.y < 0) {
            moveBackwards = false;
            flipAnim.SetTrigger("Flip");
        }
        anim.SetBool("movingBackwards", moveBackwards);

    }
}
