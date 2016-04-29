using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CannonTilting : MonoBehaviour {

    public float Angle;

    public Text TiltText;

    public static float RANGE_DIFFERENCE = 0;

    public static float RANGE = 0;

    private float MuzzleVelocity = 180f;

    private float range;

    // Use this for initialization
    void Start () {
	
	}

    /*
    The motion of an object moving near the surface of the earth can be described using the equations:

    (1): x = xo + vxo·t

    (2): y = yo + vyo·t - 0.5·g·t2

The calculator solves these two simultaneous equations to obtain a description of the ballistic trajectory.The horizontal and vertical components of initial velocity are determined from:

    vxo = vo·cos θ

    vyo = vo·sin θ

Then the calculator computes the time to reach the maximum height by finding the time at which vertical velocity becomes zero:

    vy = vyo - g·t

    trise = vyo / g

Maximum height is obtained by substitution of this time into equation (2).

    h = yo + vyo·t - 0.5·g·t2

Next, the time to fall from the maximum height is computed by solving equation(2) for an object dropped from the maximum height with zero initial velocity.

    0 = h - 0.5·g·t2

   tfall = √(2·h/g)

The total flight time of the projectile is then:

    tflight = trise + tfall

From this, equation (1) gives the maximum range:

    range = vxo·tflight

    */
    	
	// Update is called once per frame
	void Update () {

        Angle = (transform.localEulerAngles.x - 360f) * -1f;

        if(Angle == 360)
        {
            Angle = 0;
        }

        //  TiltText.text = "Tilt: " + Angle.ToString("F2");

      //  range = Mathf.Pow(MuzzleVelocity, 2) * Mathf.Sin(Mathf.Deg2Rad*(2*Angle));

        range = RangeCalculation(1f, MuzzleVelocity, Angle);

        // Debug.Log(Angle);

         // Debug.Log(range);

        RANGE = range;

        RANGE_DIFFERENCE = Mathf.Abs(range - CannonTurning.DISTANCE_TO_TARGET);

       // TiltText.text = "Distance from target: " + RANGE_DIFFERENCE.ToString("F2");

      //  TiltText.text = Angle.ToString("F2");

    }


    public void TiltUp()
    {

       if(Angle < 45f)
        transform.Rotate(-1f * Time.deltaTime, 0f, 0f,  Space.Self);
        // Wheel.transform.RotateAround(Wheel.transform.position, Vector3.right, 10f * Time.deltaTime);
    }

    public void TiltDown()
    {
       if (Angle > 1f)
            transform.Rotate(1f * Time.deltaTime, 0f, 0f,  Space.Self);
        //heel.transform.Rotate(Wheel.transform.forward, -10f);
        //  Wheel.transform.RotateAround(Wheel.transform.position, Vector3.right, -10f * Time.deltaTime);
    }

    float RangeCalculation(float h, float v0, float a)
    {

        float vxo = v0 * Mathf.Cos(Mathf.Deg2Rad * a);

        float vyo = v0 * Mathf.Sin(Mathf.Deg2Rad * a);

        float trise = vyo / 9.8f;

        float maxh = (float)(h + vyo * trise - 0.5 * 9.8f * Mathf.Pow(trise, 2));
      
        float tfall = Mathf.Sqrt(2f * maxh / 9.8f);

        float tflight = trise + tfall;

        float range = vxo * tflight;

        return range;

    }

}
