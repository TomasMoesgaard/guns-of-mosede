using UnityEngine;
using System.Collections;
using NewtonVR;

public class ShellLoad : MonoBehaviour {


    public static bool CANNON_LOADED = false;

    public Animator ca;

    public Shell loadedShell;

	// Use this for initialization
	void Start () {

       // ca = GameObject.FindGameObjectWithTag("Animator").GetComponent<CannonAnimation>();


    }
	
	// Update is called once per frame
	void Update () {

	
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Shell" && loadedShell == null && HatchControl.HATCH_FULLY_OPEN)
        {

            loadedShell = col.GetComponent<Shell>();

            col.GetComponent<Shell>().LoadShell(transform);

            CANNON_LOADED = true;

            ca.SetTrigger("Shell");

            if (loadedShell.GetComponent<NVRInteractableItem>().AttachedHand != null)
            {

                loadedShell.GetComponent<NVRInteractableItem>().AttachedHand.EndInteraction(loadedShell.GetComponent<NVRInteractableItem>());

            }
           // GetComponent<CapsuleCollider>().enabled = false;

        }


    }

    public void Eject()
    {

        if (loadedShell != null)
        {
            CANNON_LOADED = false;

            loadedShell.UnloadShell();

            ca.SetTrigger("Shell");


            loadedShell = null;
        }



    }



}
