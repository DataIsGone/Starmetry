using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateRefScroll : JSONReader
{

    [SerializeField]
    public GameObject itemTemplate;

    [SerializeField]
    private JSONReader jsonData;
    public RefItemList refItemList;
    private List<GameObject> items;

    void Awake() {
        refItemList = jsonData.readFromJSON();
        items = new List<GameObject>();
    }
    
    void Start()
    {
        formList();
    }

    public void formList() {
        clearList();
        fillList();
    }

    private void clearList() {
        if (items.Count > 0) {
            foreach (GameObject item in items) {
                Destroy(item.gameObject);
            }
            items.Clear();
        }
    }

    private void fillList() {
        foreach (RefItem refItem in refItemList.refItems) {
            GameObject item = Instantiate(itemTemplate) as GameObject;
            item.SetActive(true);

            changeText(item, refItem.topic);

            item.transform.SetParent(gameObject.transform, false);
        }
    }

    protected void changeText(GameObject item, string newText) {
        item.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = newText;
    }


}