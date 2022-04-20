using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircumferenceProblemGenerator : MathProblem
{
    decimal radius;
    const decimal pi = 3.14M;

    // Start is called before the first frame update
    void Start()
    {
        createCircProblem();
    }

    public List<decimal> createCircProblem() {
        List<decimal> circProblem = createProblem();

        generateCircPieces();
        circProblem[0] = calculateCirc();
        circProblem.Add(radius);

        return circProblem;
    }

    private void generateCircPieces() {
        radius = Random.Range(1, 15);
    }

    private decimal calculateCirc() {
        return 2 * pi * radius;
    }
}
