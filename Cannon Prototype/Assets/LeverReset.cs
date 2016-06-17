using UnityEngine;
using System.Collections;
using NewtonVR;

public class LeverReset : MonoBehaviour {


    public WebcamScript webcam;

    private NVRLever lever;

	// Use this for initialization
	void Start () {

        lever = GetComponent<NVRLever>();

	}
	
	// Update is called once per frame
	void Update () {

        if (lever.LeverEngaged)
        {
            webcam.StopWebcam();

            SteamVR_LoadLevel.Begin("1");

        }

        if (Input.GetKeyDown(KeyCode.R))
        {

            webcam.StopWebcam();

            SteamVR_LoadLevel.Begin("1");

        }

    }
}
