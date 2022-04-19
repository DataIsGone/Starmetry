using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathProblem : MonoBehaviour
{
    decimal answer;

    public List<decimal> createProblem() {
        List<decimal> problemPieces = new List<decimal>();
        problemPieces.Add(answer);
        return problemPieces;
    }
}
