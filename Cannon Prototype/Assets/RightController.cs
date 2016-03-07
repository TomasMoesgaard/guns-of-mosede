using UnityEngine;
using System.Collections;

public class RightController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider col)
    {

      


        if (SteamVR_Controller.Input(4).GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {

            if (col.tag == "RightTrigger")
            {

                if (col.transform.GetComponentInParent<CrankControl>().Tilt)
                {
                    col.transform.GetComponentInParent<CrankControl>().TiltDown();
                }
                else
                {
                    col.transform.GetComponentInParent<CrankControl>().TurnRight();
                }

            }

            if (col.tag == "LeftTrigger")
            {

                if (col.transform.GetComponentInParent<CrankControl>().Tilt)
                {
                    col.transform.GetComponentInParent<CrankControl>().TiltUp();
                }
                else
                {
                    col.transform.GetComponentInParent<CrankControl>().TurnLeft();
                }

            }
        }

        if (SteamVR_Controller.Input(4).GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {

            if (col.tag == "Handle")
            {

                col.GetComponent<AnimationActivator>().Activate();
            }


            if (col.tag == "Shell")
            {


                    col.GetComponent<Rigidbody>().isKinematic = true;
                    col.GetComponent<Rigidbody>().useGravity = false;
                    col.transform.parent = transform;

            }

        }


        }


}
