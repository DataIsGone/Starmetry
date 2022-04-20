using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleProblemGenerator : MathProblem
{
    const decimal supp_base = 180M;
    const decimal comp_base = 90M;
    decimal subtractAngle;

    public List<decimal> createCompAngleProblem() {
        return createAngleProblem("comp");
    }

    public List<decimal> createSuppAngleProblem() {
        return createAngleProblem("supp");
    }

    private List<decimal> createAngleProblem(string probType) {
        List<decimal> angleProblem = createProblem();

        generateAnglePieces(probType);
        angleProblem[0] = calculateAngle(probType);
        angleProblem.Add(subtractAngle);

        return angleProblem;
    }

    private void generateAnglePieces(string probType) {
        if (probType == "supp") {
            subtractAngle = Random.Range(1, 179);
        }
        else {
            subtractAngle = Random.Range(1, 89); 
        }
    }

    private decimal calculateAngle(string probType) {
        if (probType == "supp") {
            return supp_base - subtractAngle;
        }
        else {
            return comp_base - subtractAngle;
        }
    }
}
