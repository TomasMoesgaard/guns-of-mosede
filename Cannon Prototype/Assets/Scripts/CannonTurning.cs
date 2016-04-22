using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CannonTurning : MonoBehaviour {

    public float Angle;

    public Text AngleText;

    public static float ANGLE_TO_TARGET = 0f;

    public static float DISTANCE_TO_TARGET = 0F;

    private Transform target;

    public Transform North;

	// Use this for initialization
	void Start () {

        target = GameObject.FindGameObjectWithTag("Target").transform;

	}
	
	// Update is called once per frame
	void Update () {

        Vector3 targetDir = target.position - transform.position;
        
        Vector3 northDir = North.position - transform.position;

        Angle = Utility.SignedAngleBetween(-transform.right, northDir, transform.up);

        ANGLE_TO_TARGET = Vector3.Angle(new Vector3(transform.right.x, 0, transform.right.z), new Vector3(targetDir.x, 0, targetDir.z));

        DISTANCE_TO_TARGET = Vector3.Distance(transform.position, target.position);

       // AngleText.text = Angle.ToString("F2");

    }

    public void TurnLeft()
    {
        transform.Rotate(0f, -3f * Time.deltaTime, 0f, Space.World);
        // Wheel.transform.RotateAround(Wheel.transform.position, Vector3.right, 10f * Time.deltaTime);
    }

    public void TurnRight()
    {

        transform.Rotate(0f, 3f * Time.deltaTime, 0f, Space.World);
        //heel.transform.Rotate(Wheel.transform.forward, -10f);
        //  Wheel.transform.RotateAround(Wheel.transform.position, Vector3.right, -10f * Time.deltaTime);
    }
}
