using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private decimal thisValue;
    public decimal ThisValue {
        get {return thisValue;}
        set {thisValue = value;}
    }
    private Outline outline;
    private GameObject tmp;
    [SerializeField] private Material origMat;
    [SerializeField] private Material transMat;

    void Start() {
        Debug.Log(ThisValue);
        outline = gameObject.GetComponent<Outline>();
        outline.enabled = false;

        tmp = gameObject.transform.GetChild(0).GetChild(0).gameObject;
        tmp.SetActive(false);
    }

    private void SetDisplayValue() {
        tmp.GetComponent<TMPro.TextMeshProUGUI>().text = ThisValue.ToString();
    }

    private void OnMouseOver() {
        SetDisplayValue();
        outline.enabled = true;
        tmp.SetActive(true);
    }

    private void OnMouseExit() {
        if (PlayerInventory.GetValue() == PlayerInventory.GetBaseValue()) {
            outline.enabled = false;
            tmp.SetActive(false);
        }
    }

    private void OnMouseDown() {
        if (PlayerInventory.GetValue() != PlayerInventory.GetBaseValue()) {
            PutBackCollectable();
        } else {
            SelectCollectable();
        }
    }

    private void SelectCollectable() {
        // use invisible material on selected item
        // turn on outline on invisible object
        // set user as holding value (can only hold one value at a time)
        gameObject.GetComponent<MeshRenderer>().material = transMat;
        PlayerInventory.SetValue(ThisValue);
        Debug.Log("Collectable selected: " + PlayerInventory.GetValue());
    }

    private void PutBackCollectable() {
        // change from invisible material back to original one
        // turn off persistent outline
        // set the user's value as either 0 or the new value they're picking up
        gameObject.GetComponent<MeshRenderer>().material = origMat;
        PlayerInventory.SetValue(PlayerInventory.GetBaseValue());
        Debug.Log("Collectable returned: " + PlayerInventory.GetValue());
    }

    public decimal GetCollectableValue() {
        return ThisValue;
    }

}
