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
        RefTopicItem thisTopic = loader.items[id];
        ShowDetailWindow();
        FillWindow(id);
    }
    
    private void ShowDetailWindow() {
        gameObject.SetActive(true);
        scroll.SetActive(false);
    }

    private void FillWindow(int id) {
        // Fill Title
        GameObject topicTitle = gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        topicTitle.GetComponent<TMPro.TextMeshProUGUI>().text = loader.items[id].topicName;

        // Fill Text
        GameObject topicText = gameObject.transform.GetChild(0).GetChild(1).GetChild(0).gameObject;
        topicText.GetComponent<TMPro.TextMeshProUGUI>().text = loader.items[id].topicText;
    }

    public void GoBack() {
        scroll.SetActive(true);
        gameObject.SetActive(false);
    }

}
