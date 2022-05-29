using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using TMPro;

public class Collectable : MonoBehaviour
{
    private decimal thisValue;
    public decimal ThisValue {
        get {return thisValue;}
        set {thisValue = value;}
    }
    private Outline outline;
    private GameObject tmp;
    [SerializeField] private Material origMat0;
    [SerializeField] private Material origMat1;
    [SerializeField] private Material transMat;
    private MeshRenderer mr;
    private Collectable collectable;

    void Awake() {
        mr = gameObject.GetComponent<MeshRenderer>();
        outline = gameObject.GetComponent<Outline>();
        tmp = gameObject.transform.parent.GetChild(1).GetChild(0).gameObject;
        collectable = gameObject.GetComponent<Collectable>();
        tmp.SetActive(false);
    }

    private void SetDisplayValue() {
        tmp.GetComponent<TMPro.TextMeshProUGUI>().text = ThisValue.ToString();
    }

    private void OnMouseOver() {
        if (collectable != null && collectable.enabled) {
            SetDisplayValue();
            outline.enabled = true;
            tmp.SetActive(true);
        }
        else {
            outline.enabled = false;
            tmp.SetActive(false);
        }
    }

    private void OnMouseExit() {
        if (collectable != null && collectable.enabled) {
            if (PlayerInventory.GetValue() == GetCollectableValue()) {
                outline.enabled = true;
                tmp.SetActive(true);
            }
            else {
                outline.enabled = false;
                tmp.SetActive(false);
            }
        }
        else {
            outline.enabled = false;
            tmp.SetActive(false);
        }
    }

    private void OnMouseDown() {
        if (collectable != null && collectable.enabled) {
            if (PlayerInventory.GetValue() != PlayerInventory.GetBaseValue()) {
                PutBackCollectable();
            } else {
                SelectCollectable();
            }
            PlayerInventory.ChangeWheelStatus();
        }
    }

    private void SelectCollectable() {
        mr.materials[0].color = Color.clear;
        mr.materials[1].color = Color.clear;
        PlayerInventory.SetValue(ThisValue);
    }

    private void PutBackCollectable() {
        mr.materials[0].color = Color.white;
        mr.materials[1].color = Color.white;
        PlayerInventory.SetValue(PlayerInventory.GetBaseValue());
    }

    public decimal GetCollectableValue() {
        return ThisValue;
    }

}
