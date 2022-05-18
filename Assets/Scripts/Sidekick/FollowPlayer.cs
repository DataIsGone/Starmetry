using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float speed;
    float distance;
    public float minDistance = 1.75f;

    void FixedUpdate()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance > 5.0f) {
            resetPosition();
        }
        else if (distance >= minDistance) {
            var step = speed * Time.fixedDeltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }
    }

    void resetPosition() {
        var playerPos = player.transform.position;
        var reset = new Vector3(playerPos.x - minDistance, playerPos.y, playerPos.z);
        transform.position = reset;
    }
}
