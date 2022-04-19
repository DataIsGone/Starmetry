using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectAreaProblemGenerator : MathProblem
{
    protected decimal length;
    protected decimal width;

    void Start() {
        createRectAreaProblem();
    }

    public List<decimal> createRectAreaProblem() {
        List<decimal> areaProblem = createProblem();

        generateAreaPieces();
        areaProblem[0] = calculateArea();
    
        areaProblem.Add(length);
        areaProblem.Add(width);

        // foreach (decimal item in areaProblem) {
        //     Debug.Log(item);
        // }

        return areaProblem;
    }

    private void generateAreaPieces() {
        decimal[] randomNums = new decimal[2];
        for (int i = 0; i < 2; i++) {
            randomNums[i] = Random.Range(1, 15);
        }

        length = randomNums[0];
        width = randomNums[1];
    }

    private decimal calculateArea() {
        return length * width;
    }
}
