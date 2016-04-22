using UnityEngine;
using System.Collections;
using NewtonVR;

public class LeverReset : MonoBehaviour {

    private NVRLever lever;

	// Use this for initialization
	void Start () {

        lever = GetComponent<NVRLever>();

	}
	
	// Update is called once per frame
	void Update () {

        if (lever.LeverEngaged)
        {

            SteamVR_LoadLevel.Begin("1");

        }

	}
}
