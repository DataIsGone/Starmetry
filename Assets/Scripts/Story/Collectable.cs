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
    [SerializeField] private Material origMat0;
    [SerializeField] private Material origMat1;
    [SerializeField] private Material transMat;
    //private Material[] materials;
    private MeshRenderer mr;
    private Collectable collectable;

    void Awake() {
        mr = gameObject.GetComponent<MeshRenderer>();
        //materials = mr.materials;
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
        //gameObject.GetComponent<MeshRenderer>().material = transMat;
        mr.materials[0] = transMat;
        mr.materials[1] = transMat;
        PlayerInventory.SetValue(ThisValue);
    }

    private void PutBackCollectable() {
        mr.materials[0] = origMat0;
        mr.materials[1] = origMat1;
        PlayerInventory.SetValue(PlayerInventory.GetBaseValue());
    }

    public decimal GetCollectableValue() {
        return ThisValue;
    }

}
