using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleProblemGenerator : MathProblem
{
    const decimal supp_base = 180M;
    const decimal comp_base = 90M;
    decimal subtractAngle;

    public List<decimal> CreateCompAngleProblem() {
        return CreateAngleProblem("comp");
    }

    public List<decimal> CreateSuppAngleProblem() {
        return CreateAngleProblem("supp");
    }

    public List<decimal> CreateRightAngleProblem() {
        return CreateAngleProblem("right");
    }

    private List<decimal> CreateAngleProblem(string probType) {
        List<decimal> angleProblem = CreateProblem();

        GenerateAnglePieces(probType);
        angleProblem[0] = CalculateAngle(probType); // answer
        angleProblem.Add(subtractAngle);

        return angleProblem;
    }

    private void GenerateAnglePieces(string probType) {
        if (probType == "supp") {
            subtractAngle = Random.Range(1, 179);
        }
        else if (probType == "comp") {
            subtractAngle = Random.Range(1, 89); 
        }
        else {  // right angle problem
            subtractAngle = 90M / 2M;
        }   
    }

    private decimal CalculateAngle(string probType) {
        if (probType == "supp") {
            return supp_base - subtractAngle;
        }
        else if (probType == "comp") {
            return comp_base - subtractAngle;
        }
        else {  // right angle problem
            return 90M / 2M;
        }
    }
}
