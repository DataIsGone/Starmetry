using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlaceItem : MonoBehaviour
{
    public GameObject itemToPlace;
    private MeshRenderer mr;

    void Awake() {
        mr = gameObject.GetComponent<MeshRenderer>();
        itemToPlace.SetActive(false);
    }

    public void PlaceThisItem() {
        itemToPlace.SetActive(true);
        SetL3Catalyst();
    }

    public static void SetL3Catalyst() {
        SceneEvents.catalystL3 = true;  // this script is only used in Level 3 for now
    }

    private void OnMouseOver() {
        mr.material.color = Color.yellow;
    }

    private void OnMouseExit() {
        mr.material.color = Color.white;
    }

    private void OnMouseDown() {
        PlaceThisItem();
    }

}
