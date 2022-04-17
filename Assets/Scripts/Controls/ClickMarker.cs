using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMarker : MonoBehaviour
{

    public GameObject player;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= 1.0f) {
            transform.gameObject.SetActive(false);
        }

        //if (player.velocity != Vector3.zero) {
        //     playerAnimator.SetBool("isWalking", true);
            // transform.gameObject.SetActive(true);
        // } else {
        //     playerAnimator.SetBool("isWalking", false);
        //}
    }
}
