using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// currProblem = complementary angle
// currProblem2 = supplementary angle

public class AngleValueLabel : MonoBehaviour
{
    [SerializeField] private TMP_Text label;
    [SerializeField] private GameObject constellationParent;

    void Start() {
        SetLabel();
    }

    private void SetLabel() {
        if (name == "MissingValueLabel") {
            label.text = "?";
        }
        else {
            var pName = constellationParent.name;
            if (pName == "Constellation1") {
                label.text = YarnValues.GetValueForYarn("angle").ToString();
            }
            else if (pName == "Constellation2") {
                label.text = YarnValues.GetValue2ForYarn("angle").ToString();
            }
            else { // right angle
                label.text = YarnValues.GetValue3ForYarn("angle").ToString();
            }
        }
    }
}
