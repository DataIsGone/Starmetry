using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectAreaProblemGenerator : MathProblem
{
    protected decimal length;
    protected decimal width;

    public List<decimal> CreateRectAreaProblem() {
        List<decimal> areaProblem = CreateProblem();

        GenerateAreaPieces();
        areaProblem[0] = CalculateArea();
    
        areaProblem.Add(length);
        areaProblem.Add(width);

        return areaProblem;
    }

    private void GenerateAreaPieces() {
        decimal[] randomNums = new decimal[2];
        for (int i = 0; i < 2; i++) {
            randomNums[i] = Random.Range(1, 15);
        }

        length = randomNums[0];
        width = randomNums[1];
    }

    private decimal CalculateArea() {
        return length * width;
    }
}
