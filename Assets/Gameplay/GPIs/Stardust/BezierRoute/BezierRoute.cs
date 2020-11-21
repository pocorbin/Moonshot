using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierRoute : MonoBehaviour
{
    private List<Vector3> controlPoints = new List<Vector3>();
    private Vector2 gizmosPosition;

    private int curveCount = 0;
    private int layerOrder = 0;
    private int SEGMENT_COUNT = 10;

    private List<Vector3> waypoints = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    void DrawCurve()
    {
        curveCount = (int)controlPoints.Count / 3;
        for (int j = 0; j < curveCount; j++)
        {
            for (int i = 1; i <= SEGMENT_COUNT; i++)
            {
                float t = i / (float)SEGMENT_COUNT;
                int nodeIndex = j * 3;
                Vector3 pixel = CalculateCubicBezierPoint(t, controlPoints[nodeIndex], controlPoints[nodeIndex + 1], controlPoints[nodeIndex + 2], controlPoints[nodeIndex + 3]);
                waypoints.Add(pixel);
            }

        }
    }
    Vector3 CalculateCubicBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 p = uuu * p0;
        p += 3 * uu * t * p1;
        p += 3 * u * tt * p2;
        p += ttt * p3;

        return p;
    }

    public List<Vector3> GetWayPoints(List<Vector3> pControlPoints) //Should be a list of 4 points
    {
        controlPoints = pControlPoints;
        if(waypoints.Count == 0)
        {
            DrawCurve();
        }
        return waypoints;
    }
    private void OnDrawGizmos()
    {
        /*if(controlPoints.Length == 4 && controlPoints[0] != null && controlPoints[1] != null && controlPoints[2] != null && controlPoints[3] != null)
        {
            for (float t = 0; t <= 1; t += 0.05f)
            {
                gizmosPosition = Mathf.Pow(1 - t, 3) * controlPoints[0].position +
                    3 * Mathf.Pow(1 - t, 2) * t * controlPoints[1].position +
                    3 * (1 - 2) * Mathf.Pow(t, 2) * controlPoints[2].position +
                    Mathf.Pow(t, 3) * controlPoints[3].position;
                Gizmos.DrawSphere(gizmosPosition, 0.25f);
            }

            Gizmos.DrawLine(new Vector2(controlPoints[0].position.x, controlPoints[0].position.y),
                new Vector2(controlPoints[1].position.x, controlPoints[1].position.y));
            Gizmos.DrawLine(new Vector2(controlPoints[2].position.x, controlPoints[2].position.y),
                new Vector2(controlPoints[3].position.x, controlPoints[3].position.y));
        }*/
    }
}
