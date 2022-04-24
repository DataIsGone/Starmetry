using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefTopicLoader : MonoBehaviour
{
    //public List<RefTopicItem> items;
    public Dictionary<int, RefTopicItem> items;

    void Awake() {
        items = new Dictionary<int, RefTopicItem>();
        RefTopicItemDictionary thisDictionary = JsonUtility.FromJson<RefTopicItemDictionary>(JSONFileReader.LoadJsonAsResource("Topics/_RefTopicItemDictionary.json"));
        foreach (string dictionaryItem in thisDictionary.items) {
            LoadItem(dictionaryItem);
        }
    }

    public void LoadItem(string path) {
        string loadedTopic = JSONFileReader.LoadJsonAsResource(path);
        RefTopicItem thisTopic = JsonUtility.FromJson<RefTopicItem>(loadedTopic);
        if (items.ContainsKey(thisTopic.topicID)) {
            Debug.LogWarning("Item " + thisTopic.topicName + "'s Key already exists");
        } else {
            items.Add(thisTopic.topicID, thisTopic);   
        }
    }

    public Dictionary<int, RefTopicItem> GetDictionary() {
        Debug.Log(items);
        return items;
    }
}
