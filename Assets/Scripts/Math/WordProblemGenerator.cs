using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordProblemGenerator : MonoBehaviour
{
    public string answer;
    public string option1;
    public string option2;

    public List<string> createProblem() {
        // List<decimal> problemPieces = new List<decimal>();
        // problemPieces.Add(answer);
        // return problemPieces;

        List<string> answerOptions = new List<string>();
        answerOptions.Add(answer);
    }
}
