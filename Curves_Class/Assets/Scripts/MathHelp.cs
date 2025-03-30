using Vector3 = UnityEngine.Vector3;

public static class MathHelp
{
    public static Vector3 GetCurvePoint(Vector3[] points, float t)
    {
        // Create an array for the first iteration of interpolations.
        Vector3[] lerps1 = new Vector3[points.Length - 1];

        // Interpolate all the points in given list and store them in a list.
        for (int i = 0; i < points.Length - 1; i++)
        {
            lerps1[i] = Vector3.Lerp(points[i], points[i + 1], t);
        }
		
        // Create an array for the second iteration of interpolations.
        Vector3[] lerps2 = new Vector3[lerps1.Length - 1];
		
        // Keep interpolating until the curves end is reached.
        int numberOfLerps = lerps2.Length;
        while (numberOfLerps >= 2)
        {
            // Interpolate the previous set of interpolated points.
            for (int i = 0; i < lerps1.Length - 1; i++)
            {
                lerps2[i] = Vector3.Lerp(lerps1[i], lerps1[i + 1], t);
            }
            // Replace lerp1 list with lerps2 for the next iteration.
            lerps1 = lerps2;
			
            numberOfLerps--;
        }
		
        // Interpolate the final two interpolations to get point on the curve.
        return Vector3.Lerp(lerps1[0], lerps1[1], t);
    }
}