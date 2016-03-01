using UnityEngine;
using System.Collections;

public class CrankControl : MonoBehaviour {

    public GameObject Wheel;

    public GameObject ObjectToControl;

    public bool Tilt = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void TurnLeft()
    {
        Wheel.transform.Rotate(0f, 0f, -100f * Time.deltaTime, Space.Self);
        // Wheel.transform.RotateAround(Wheel.transform.position, Vector3.right, 10f * Time.deltaTime);
        ObjectToControl.GetComponent<CannonTurning>().TurnLeft();
    }

   public void TurnRight()
    {

        Wheel.transform.Rotate(0f, 0f, 100f * Time.deltaTime, Space.Self);
        ObjectToControl.GetComponent<CannonTurning>().TurnRight();
        //heel.transform.Rotate(Wheel.transform.forward, -10f);
        //  Wheel.transform.RotateAround(Wheel.transform.position, Vector3.right, -10f * Time.deltaTime);
    }

    public void TiltUp()
    {
        Wheel.transform.Rotate(0f, 0f, -100f * Time.deltaTime, Space.Self);
        ObjectToControl.GetComponent<CannonTilting>().TiltUp();
    }

    public void TiltDown()
    {
        Wheel.transform.Rotate(0f, 0f, 100f * Time.deltaTime, Space.Self);
        ObjectToControl.GetComponent<CannonTilting>().TiltDown();
    }
}
