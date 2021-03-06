using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSystem : MonoBehaviour
{
    public GameObject[] collectables;

    void Start() {
        SetValues();
    }

    private void SetValues() {
        var value = (float)YarnValues.GetValue2ForYarn("answer");
        for (int i = 0; i < collectables.Length; i++) {
            var wheelObject = collectables[i].transform.GetChild(0).gameObject;
            wheelObject.GetComponent<Collectable>().ThisValue = SetupValue(value);
        }
        collectables[Random.Range(0, collectables.Length)].transform.GetChild(0).gameObject.GetComponent<Collectable>().ThisValue = (decimal)value;
    }

    private decimal SetupValue(float value) {
        // for Level 3 Wheel Problem only
        if (Random.Range(-1f, 1f) < 0) {
            value = Mathf.Abs((float)System.Math.Round((float)value - Random.Range(1f, 50f), 2));
        } else {
            value = Mathf.Abs((float)System.Math.Round((float)value + Random.Range(1f, 50f), 2));
        }
        return (decimal)value;
    }
}
