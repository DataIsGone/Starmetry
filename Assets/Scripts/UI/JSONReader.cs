using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Credit: https://www.youtube.com/watch?v=XbdnG__wzZ8
public class JSONReader : MonoBehaviour
{
    public TextAsset textJSON;

    [System.Serializable]
    public class Player {
        public string name;
        public int health;
        public int mana;
    }

    [System.Serializable]
    public class PlayerList {
        public Player[] player;
    }

    public PlayerList myPlayerList = new PlayerList();

    public PlayerList readFromJSON() {
        myPlayerList = JsonUtility.FromJson<PlayerList>(textJSON.text);
        return myPlayerList;
    }

}
