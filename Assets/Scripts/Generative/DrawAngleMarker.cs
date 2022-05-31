using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawAngleMarker : MonoBehaviour
{
    public LineRenderer angleMarker1;
    public LineRenderer angleMarker2;
    //public LineRenderer halfCircleRenderer;

    void Start()
    {
        Vector3[] positions = new Vector3[3] {new Vector3(-1, 0, 0), new Vector3(0, 2, 0), new Vector3(2, 1, 0)};
        DrawMarker(positions);
    }

    void DrawMarker(Vector3[] vertexPositions)
    {
        angleMarker1.positionCount = 3;
        angleMarker1.SetPositions(vertexPositions);

        angleMarker2.positionCount = 3;
        angleMarker2.SetPositions(vertexPositions);
    }
}
