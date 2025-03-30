using UnityEngine;

public class Curve : MonoBehaviour
{
    public Vector3[] points;

    public void Reset()
    {
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = Vector3.zero;
        }
    }
	
    // Return a point on the curve based on t (0 = start of curve, 1 = end of curve).
    public Vector3 GetPoint(float t)
    {
        return transform.TransformPoint(MathHelp.GetCurvePoint(points, t));
    }
}