using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SignalFader : MonoBehaviour
{
    public Animator signalAnim;

    void Start()
    {
        signalAnim.enabled = false;    
    }

    [YarnCommand("start_signal")]
    public void ShowSignal() {
        signalAnim.enabled = true;
    }

    [YarnCommand("end_signal")]
    public void RemoveSignal() {
        signalAnim.SetTrigger("RemoveSignal");
    }

}
