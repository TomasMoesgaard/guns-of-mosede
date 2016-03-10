using UnityEngine;
using System.Collections;

public class LookManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

     //   Cursor.lockState = CursorLockMode.Locked;

     //   Cursor.visible = true;

    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;

       // SteamVR_Controller.Input(1).GetPressDown(SteamVR_Controller.ButtonMask.Trigger)

        if (SteamVR_Controller.Input(RightController.RIGHT_INDEX).GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {


            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {

                if (hit.collider.tag == "RightTrigger")
                {

                    if (hit.transform.GetComponentInParent<CrankControl>().Tilt)
                    {
                        hit.transform.GetComponentInParent<CrankControl>().TiltDown();
                    }
                    else
                    {
                        hit.transform.GetComponentInParent<CrankControl>().TurnRight();
                    }

                }

                if (hit.collider.tag == "LeftTrigger")
                {

                    if (hit.transform.GetComponentInParent<CrankControl>().Tilt)
                    {
                        hit.transform.GetComponentInParent<CrankControl>().TiltUp();
                    }
                    else
                    {
                        hit.transform.GetComponentInParent<CrankControl>().TurnLeft();
                    }

                }
                /*
                if (hit.collider.tag == "Shell")
                {
                    hit.collider.GetComponent<Rigidbody>().isKinematic = true;
                    hit.collider.GetComponent<Rigidbody>().useGravity = false;
                    hit.collider.transform.parent = transform;
                }
                */
            }

        }

        if (SteamVR_Controller.Input(RightController.RIGHT_INDEX).GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            RaycastHit hit2;
            if (Physics.Raycast(transform.position, transform.forward, out hit2))
            {

            //    Debug.Log(hit2.collider.tag);


                if(hit2.collider.tag == "Handle")
                {

                   // Debug.Log("Got here!");

                    hit2.collider.GetComponent<AnimationActivator>().Activate();

                }

            }

        }
    }
}