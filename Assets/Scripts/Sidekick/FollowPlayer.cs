using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float speed;
    float distance;
    public float minDistance = 1.75f;

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance >= minDistance) {
            var step = speed * Time.fixedDeltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }
        // float interpolation = speed * Time.deltaTime;

        // Vector3 position = this.transform.position;
        // position.x = Mathf.Lerp(this.transform.position.x, player.transform.position.x, interpolation);
        // position.y = Mathf.Lerp(this.transform.position.y, player.transform.position.y, interpolation);
        // position.z = Mathf.Lerp(this.transform.position.z, player.transform.position.z, interpolation);

        // this.transform.position = position;
    }

    void resetPosition() {
        var playerPos = player.transform.position;
        var reset = new Vector3(playerPos.x - minDistance, playerPos.y, playerPos.z);
        transform.position = reset;
    }
}
