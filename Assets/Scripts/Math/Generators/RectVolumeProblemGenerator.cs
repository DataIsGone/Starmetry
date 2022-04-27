using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectVolumeProblemGenerator : MathProblem
{
    protected decimal length;
    protected decimal width;
    protected decimal height;
    
    public List<decimal> CreateRectVolProblem() {
        List<decimal> volumeProblem = CreateProblem();

        GenerateVolumePieces();
        volumeProblem[0] = CalculateVolume();
    
        volumeProblem.Add(length);
        volumeProblem.Add(width);
        volumeProblem.Add(height);

        return volumeProblem;
    }

    private void GenerateVolumePieces() {
        decimal[] randomNums = new decimal[3];
        for (int i = 0; i < 3; i++) {
            randomNums[i] = Random.Range(1, 15);
        }

        length = randomNums[0];
        width = randomNums[1];
        height = randomNums[2];
    }

    private decimal CalculateVolume() {
        return length * width * height;
    }
}
