using UnityEngine;
using System.Collections;

public class PosterLights : MonoBehaviour {

    public Light Spot;

    public Light Point;

    private float SpotStartValue;

    private float PointStartValue;

    public Camera EyeCamera;

    // Use this for initialization
    void Start () {

        SpotStartValue = Spot.intensity;

        PointStartValue = Point.intensity;


	}
	
	// Update is called once per frame
	void Update () {

        if (ArrowScript.TUTORIAL_ON) {

            BrightenLight(Spot, SpotStartValue);

            if (ArrowScript.TUTORIAL_STATE == 0)
            {

                if (GetComponent<Renderer>().IsVisibleFrom(EyeCamera))
                {

                    // DimLight(Spot);
                    DimLight(Point);

                }
                else
                {
                    //  BrightenLight(Spot, SpotStartValue);
                    BrightenLight(Point, PointStartValue);
                }
            }
            else
            {
                DimLight(Point);
            }
        }
        else
        {


            DimLight(Spot);
            DimLight(Point);

        }

	}


    void DimLight(Light l)
    {

        if(l.intensity > 0f)
        {
            l.intensity -= 1f * Time.deltaTime;
        }

    }

    void BrightenLight(Light l, float s)
    {
        if (l.intensity < s)
        {
            l.intensity += 1f * Time.deltaTime;
        }


    }
}
