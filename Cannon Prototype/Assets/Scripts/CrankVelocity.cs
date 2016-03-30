using UnityEngine;
using System.Collections;

public class CrankVelocity : MonoBehaviour {

    public GameObject ObjectToRotate;

    public enum axis
    {
        X,Y,Z
    }

    public axis Axis;

    private HingeJoint hj;
   
    // Use this for initialization
    void Start () {

        hj = GetComponent<HingeJoint>();


    }
	
	// Update is called once per frame
	void Update () {

        switch (Axis)
        {
            case axis.X:

                ObjectToRotate.transform.Rotate(hj.velocity* Time.deltaTime / 100f, 0f, 0f);

                break;

            case axis.Y:

                ObjectToRotate.transform.Rotate(0f, hj.velocity * Time.deltaTime / 100f, 0f);

                break;

            case axis.Z:

                ObjectToRotate.transform.Rotate(0f, 0f, hj.velocity * Time.deltaTime / 100f);

                break;


        }

    }
}
