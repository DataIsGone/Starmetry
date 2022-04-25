using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailWindow : MonoBehaviour
{
    [SerializeField]
    private GameObject scroll;

    [SerializeField]
    private RefTopicLoader loader;

    // [SerializeField]
    // private GameObject topicDetail;
    // ON CLICK

        // turn off panel options object
        // turn on detail window
        // fill detail window

        // create back button:
            // turn on panel options object
            // turn off detail window

    public void ActivateTopicWindow(int id) {
        Debug.Log(id);
        RefTopicItem thisTopic = loader.items[id];
        Debug.Log(thisTopic.topicName);
        ShowDetailWindow();
        //FillWindow();
    }
    
    private void ShowDetailWindow() {
        gameObject.SetActive(true);
        scroll.SetActive(false);
    }

    private void FillWindow() {

    }

    public void GoBack() {
        scroll.SetActive(true);
        gameObject.SetActive(false);
    }

}
