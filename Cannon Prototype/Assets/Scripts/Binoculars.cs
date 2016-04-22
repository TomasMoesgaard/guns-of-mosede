using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using NewtonVR;

public class Binoculars : MonoBehaviour {

    private float startFOV;

    public Camera mainCamera;

    private Renderer renderer;

    private VignetteAndChromaticAberration vig;

    private GameObject controller;

	// Use this for initialization
	void Start () {

      //  mainCamera = Camera.main;

        startFOV = mainCamera.fieldOfView;

        renderer = GetComponent<Renderer>();

        vig = mainCamera.GetComponent<VignetteAndChromaticAberration>();

        vig.enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider col)
    {

        if (col.tag == "Face")
        {

            ZoomIn();

        }

    }

    void OnTriggerExit(Collider col)
    {

        if (col.tag == "Face")
        {


            ZoomOut();

        }

    }


    void ZoomIn()
    {

        controller = GetComponent<NVRInteractableItem>().AttachedHand.gameObject;

        mainCamera.fieldOfView = 30f;

        mainCamera.gameObject.GetComponent<VignetteAndChromaticAberration>().enabled = true;

        gameObject.layer = 8;

        controller.GetComponentInChildren<Renderer>().gameObject.layer = 8;

     //   renderer.enabled = false;

    }

    void ZoomOut()
    {

        mainCamera.fieldOfView = startFOV;

        mainCamera.gameObject.GetComponent<VignetteAndChromaticAberration>().enabled = false;

        gameObject.layer = 0;

        controller.GetComponentInChildren<Renderer>().gameObject.layer = 0;
        //  renderer.enabled = true;
    }


}
