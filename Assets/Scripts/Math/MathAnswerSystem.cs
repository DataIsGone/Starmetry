using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathAnswerSystem : MonoBehaviour
{
    [SerializeField] private GameObject mathManager;
    private List<decimal> currProblem;

    private decimal GetInput() {
        return 0M;
    }

    private bool CompareInput() {
        return true;
    }


}
