using UnityEngine;
using System.Collections;


public static class Utility
{
    public static float CalculateAngle(Vector3 from, Vector3 to)
    {
        return Quaternion.FromToRotation(Vector3.right, to - from).eulerAngles.z;
    }

   public static float SignedAngleBetween(Vector3 a, Vector3 b, Vector3 n)
    {
        // angle in [0,180]
        float angle = Vector3.Angle(a, b);
        float sign = Mathf.Sign(Vector3.Dot(n, Vector3.Cross(a, b)));

        // angle in [-179,180]
        float signed_angle = angle * sign;

        // angle in [0,360] (not used but included here for completeness)
        float angle360 = 360 -( (signed_angle + 180) % 360);

        return angle360;
    }

    public static float MapRange(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

    public static float CalculateCanonTilt(float d)
    {

        return 0.5f * (Mathf.Asin((9.8f * d) / Mathf.Pow(180f, 2f)) * Mathf.Rad2Deg);

    }

    public static void ResetGame()
    {


    }
}
