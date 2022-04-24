using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Credit: https://www.youtube.com/watch?v=XbdnG__wzZ8
public class JSONReader : MonoBehaviour
{
    public TextAsset textJSON;

    [System.Serializable]
    public class RefItem {
        public string topic;
        public string text;
    }

    [System.Serializable]
    public class RefItemList {
        public RefItem[] refItems;
    }

    public RefItemList thisRefList = new RefItemList();

    public RefItemList readFromJSON() {
        thisRefList = JsonUtility.FromJson<RefItemList>(textJSON.text);
        return thisRefList;
    }

}
