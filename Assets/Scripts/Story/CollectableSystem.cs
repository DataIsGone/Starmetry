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
            collectables[i].GetComponent<Collectable>().ThisValue = SetupValue(value);
        }
        collectables[Random.Range(0, collectables.Length)].GetComponent<Collectable>().ThisValue = (decimal)value;
    }

    private decimal SetupValue(float value) {
        // for Level 3 Wheel Problem only
        if (Random.Range(-1f, 1f) < 0) {
            value = (float)value - Random.Range(1f, 50f);
        } else {
            value = (float)value + Random.Range(1f, 50f);
        }
        return (decimal)value;
    }

    private decimal[] CreateValueOptions() {
        var valueOptions = new decimal[collectables.Length];
        return valueOptions;
    }
}
