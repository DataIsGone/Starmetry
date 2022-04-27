using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderVolumeProblemGenerator : MathProblem
{
    decimal radius;
    decimal height;

    const decimal pi = 3.14M;

    public List<decimal> CreateCylinderVolProblem() {
        List<decimal> volumeProblem = CreateProblem();

        GenerateVolumePieces();
        volumeProblem[0] = CalculateVolume();
    
        volumeProblem.Add(radius);
        volumeProblem.Add(height);

        return volumeProblem;
    }

    private void GenerateVolumePieces() {
        decimal[] randomNums = new decimal[2];
        for (int i = 0; i < 2; i++) {
            randomNums[i] = Random.Range(1, 15);
        }

        radius = randomNums[0];
        height = randomNums[1];
    }

    private decimal CalculateVolume() {
        return pi * (decimal)Mathf.Pow((float)radius, 2f) * height;
    }
}
