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

        if (Input.GetKey(KeyCode.K))
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

                if (hit.collider.tag == "Shell")
                {
                    hit.collider.GetComponent<Rigidbody>().isKinematic = true;
                    hit.collider.GetComponent<Rigidbody>().useGravity = false;
                    hit.collider.transform.parent = transform;
                }

            }

        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            RaycastHit hit2;
            if (Physics.Raycast(transform.position, transform.forward, out hit2))
            {
                if (hit2.collider.tag == "Hatch")
                {

                    hit2.collider.GetComponent<HatchControl>().ActivateHatch();

                }


                if (hit2.collider.tag == "Fire")
                {

                    hit2.collider.GetComponent<FireController>().FireCannon();

                }

            }

        }
    }
}