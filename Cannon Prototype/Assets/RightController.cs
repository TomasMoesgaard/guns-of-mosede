using UnityEngine;
using System.Collections;

public class RightController : MonoBehaviour {

    public static int RIGHT_INDEX;

    private int index;

    // Use this for initialization
    void Start () {

        index = (int)GetComponent<SteamVR_TrackedObject>().index;

        RIGHT_INDEX = index;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider col)
    {

        


        if (SteamVR_Controller.Input(index).GetPress(SteamVR_Controller.ButtonMask.Trigger))
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

        if (SteamVR_Controller.Input(index).GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
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

        if (SteamVR_Controller.Input(index).GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
        {

            if(GetComponentInChildren<Shell>() != null)
            {
                GetComponentInChildren<Shell>().LetGo();
            }

        }


        }


}
