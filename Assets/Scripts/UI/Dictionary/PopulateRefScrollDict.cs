using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateRefScrollDict : RefTopicLoader
{

    //[SerializeField]
    public GameObject itemTemplate;
    
    [SerializeField]
    private RefTopicLoader loader;
    
    [SerializeField]
    private StoryData data;

    [SerializeField]
    private DetailWindow detailWindow;

    void Start() {  // Update?
        FillList();
    }

    private void FillList() {
        for (int i = 0; i < data.topicsUnlocked; i++) {
            int id = i;
            GameObject item = Instantiate(itemTemplate);
            item.SetActive(true);
            item.GetComponent<Button>().onClick.AddListener(delegate{detailWindow.ActivateTopicWindow(id);});
            changeText(item, loader.items[i].topicName);
            item.transform.SetParent(gameObject.transform, false);
        }
    }

    // private void ClearList() {
    // }

    private void changeText(GameObject item, string newText) {
        item.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = newText;
    }
}