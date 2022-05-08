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
    private Collectable collectable;

    void Awake() {
        outline = gameObject.GetComponent<Outline>();
        tmp = gameObject.transform.GetChild(0).GetChild(0).gameObject;
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
        gameObject.GetComponent<MeshRenderer>().material = transMat;
        PlayerInventory.SetValue(ThisValue);
    }

    private void PutBackCollectable() {
        gameObject.GetComponent<MeshRenderer>().material = origMat;
        PlayerInventory.SetValue(PlayerInventory.GetBaseValue());
    }

    public decimal GetCollectableValue() {
        return ThisValue;
    }

}
