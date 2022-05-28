using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizeConstellations : MonoBehaviour
{
    [SerializeField] private Transform[] points1;
    [SerializeField] private Transform[] points2;
    [SerializeField] private LineController line1;
    [SerializeField] private LineController line2;

    private void Start() {
        line1.SetUpLine(points1);
        line2.SetUpLine(points2);
    }
}
