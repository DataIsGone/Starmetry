using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawAngleMarker : MonoBehaviour
{
    public LineRenderer lineRenderer;
    //public LineRenderer halfCircleRenderer;

    void Start()
    {
        //DrawHalfCircle(100, 1);
        Vector3[] positions = new Vector3[3] { new Vector3(0, 0, 0), new Vector3(-1, 1, 0), new Vector3(1, 1, 0) };
        DrawTriangle(positions);
    }

    // void DrawHalfCircle(int steps, float radius) {
    //     halfCircleRenderer.positionCount = steps;

    //     for (int currStep = 0; currStep < steps; currStep++) {
    //         float circumferenceProgress = (float)currStep/steps;
    //         float currRadian = circumferenceProgress * 0.5f * Mathf.PI;
    //         float xScaled = Mathf.Cos(currRadian);
    //         float yScaled = Mathf.Sin(currRadian);
    //         float x = xScaled * radius;
    //         float y = yScaled * radius;

    //         Vector3 currPos = new Vector3(x, y, 0);
    //         halfCircleRenderer.SetPosition(currStep, currPos);
    //     }
    // }

    //  void Start()
    // {
    //     Vector3[] positions = new Vector3[3] { new Vector3(0, 0, 0), new Vector3(-1, 1, 0), new Vector3(1, 1, 0) };
    //     DrawTriangle(positions);
    // }

    void DrawTriangle(Vector3[] vertexPositions)
    {
        
        lineRenderer.positionCount = 3;
        lineRenderer.SetPositions(vertexPositions);
    }
}
