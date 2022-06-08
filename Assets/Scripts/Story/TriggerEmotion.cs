using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class TriggerEmotion : MonoBehaviour
{
    Animator emotion;

    void Start() {
        emotion = GetComponent<Animator>();
    }

    [YarnCommand("emo_ellipse")]
    public void PlayEllipse() {
        emotion.SetTrigger("ellipse");
    }

    [YarnCommand("emo_default")]
    public void ResetToDefault() {
        emotion.SetTrigger("default");
    }

}
