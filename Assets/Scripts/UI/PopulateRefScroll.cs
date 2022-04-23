using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateRefScroll : JSONReader
{

    [SerializeField]
    public GameObject itemTemplate;

    [SerializeField]
    private JSONReader jsonData;
    public PlayerList playerList;
    //private JSONReader.Player player;

    private List<GameObject> items;

    void Awake() {
        playerList = jsonData.readFromJSON();
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
        foreach (Player player in playerList.player) {
            GameObject item = Instantiate(itemTemplate) as GameObject;
            item.SetActive(true);

            changeText(item, player.name);

            item.transform.SetParent(gameObject.transform, false);
        }
    }

    private void changeText(GameObject item, string name) {
        item.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = name;
    }

}
