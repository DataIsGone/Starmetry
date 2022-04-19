using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectVolumeProblemGenerator : MathProblem
{
    protected decimal length;
    protected decimal width;
    protected decimal height;

    void Start() {
        createRectVolProblem();
    }

    public List<decimal> createRectVolProblem() {
        List<decimal> volumeProblem = createProblem();

        generateVolumePieces();
        volumeProblem[0] = calculateVolume();
    
        volumeProblem.Add(length);
        volumeProblem.Add(width);
        volumeProblem.Add(height);

        // foreach (decimal item in volumeProblem) {
        //     Debug.Log(item);
        // }

        return volumeProblem;
    }

    private void generateVolumePieces() {
        decimal[] randomNums = new decimal[3];
        for (int i = 0; i < 3; i++) {
            randomNums[i] = Random.Range(1, 15);
        }

        length = randomNums[0];
        width = randomNums[1];
        height = randomNums[2];
    }

    private decimal calculateVolume() {
        return length * width * height;
    }
}
