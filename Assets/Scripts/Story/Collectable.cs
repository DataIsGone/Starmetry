using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public decimal value;
    private Outline outline;
    private GameObject tmp;

    void Start() {
        value = 999M; // TODO: TEST -- REMOVE LATER
        outline = gameObject.GetComponent<Outline>();
        outline.enabled = false;

        tmp = gameObject.transform.GetChild(0).GetChild(0).gameObject;
        SetDisplayValue();
        tmp.SetActive(false);
    }

    private void SetDisplayValue() {
        tmp.GetComponent<TMPro.TextMeshProUGUI>().text = value.ToString();
    }

    private void OnMouseOver() {
        outline.enabled = true;
        tmp.SetActive(true);
    }

    private void OnMouseExit() {
        outline.enabled = false;
        tmp.SetActive(false);
    }

    private void OnMouseDown() {
        // select this wheel
        Debug.Log("Value: " + value);

        // if the user currently DOES have a value from a collectable

        // if the user currently does not have a value
        SelectCollectable();
    }

    private void SelectCollectable() {
        // use invisible material on selected item
        // turn on outline on invisible object
        // set user as holding value (can only hold one value at a time)
        Debug.Log("Collectable selected");
    }

    private void PutBackCollectable() {
        // change from invisible material back to original one
        // turn off persistent outline
        // set the user's value as either 0 or the new value they're picking up
    }

    public decimal GetCollectableValue() {
        return value;
    }

}
