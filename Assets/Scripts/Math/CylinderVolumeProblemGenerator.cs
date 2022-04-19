using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderVolumeProblemGenerator : MathProblem
{
    decimal radius;
    decimal height;

    const decimal pi = 3.14M;

    void Start() {
        createCylinderVolProblem();
    }

    public List<decimal> createCylinderVolProblem() {
        List<decimal> volumeProblem = createProblem();

        generateVolumePieces();
        volumeProblem[0] = calculateVolume();
    
        volumeProblem.Add(radius);
        volumeProblem.Add(height);

        // foreach (decimal item in volumeProblem) {
        //     Debug.Log(item);
        // }

        return volumeProblem;
    }

    private void generateVolumePieces() {
        decimal[] randomNums = new decimal[2];
        for (int i = 0; i < 2; i++) {
            randomNums[i] = Random.Range(1, 15);
        }

        radius = randomNums[0];
        height = randomNums[1];
    }

    private decimal calculateVolume() {
        return pi * (decimal)Mathf.Pow((float)radius, 2f) * height;
    }
}
