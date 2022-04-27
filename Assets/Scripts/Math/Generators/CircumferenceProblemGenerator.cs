using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircumferenceProblemGenerator : MathProblem
{
    decimal radius;
    const decimal pi = 3.14M;

    public List<decimal> CreateCircProblem() {
        List<decimal> circProblem = CreateProblem();

        GenerateCircPieces();
        circProblem[0] = CalculateCirc();
        circProblem.Add(radius);

        return circProblem;
    }

    private void GenerateCircPieces() {
        radius = Random.Range(1, 15);
    }

    private decimal CalculateCirc() {
        return 2 * pi * radius;
    }
}
