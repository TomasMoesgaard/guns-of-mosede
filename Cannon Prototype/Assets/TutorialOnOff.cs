using UnityEngine;
using System.Collections;
using NewtonVR;

public class TutorialOnOff : MonoBehaviour {

    private bool activated = false;

    private NVRLever lever;

	// Use this for initialization
	void Start () {

        lever = GetComponent<NVRLever>();

	}
	
	// Update is called once per frame
	void Update () {

        if (!activated && lever.LeverEngaged)
        {
            activated = true;

            ArrowScript.TUTORIAL_ON = !ArrowScript.TUTORIAL_ON;
        }

        if(activated && !lever.LeverEngaged)
        {
            activated = false;
        }

	}
}
