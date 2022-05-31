using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ResetStar : MonoBehaviour
{
    // private Vector3 startPos;

    // void Start()
    // {
    //     startPos = new Vector3(3.6f, 20f, 5.5f);
    // }
    [YarnCommand("star_on")]
    public void ActivateStar(int constellation) {
        ResetThisStar(constellation);
        gameObject.SetActive(true);
    }

    private void ResetThisStar(int constellation) {
        gameObject.SetActive(false);
        transform.position = GetPosition(constellation);
    }

    private Vector3 GetPosition(int constellation) {
        if (constellation == 1) {
            return new Vector3(3.6f, 20f, 5.5f);
        }
        else if (constellation == 2) {
            return new Vector3(1f, 10f, 0f);
        }
        else {  // 3
            return new Vector3(3.6f, 20f, 5.5f);
        }
    }
}
