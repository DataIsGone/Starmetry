using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryData : MonoBehaviour
{
    public int topicsUnlocked;

    void Awake() {
        topicsUnlocked = 3;
    }

    public void UnlockTopic() {
        topicsUnlocked++;
    }

    // public int GetNumTopicsUnlocked() {
    //     return topicsUnlocked;
    // }
}
