using UnityEngine;
using System.Collections;

public class ShellLoad : MonoBehaviour {


    public static bool CANNON_LOADED = false;

    public Animator ca;

    private Shell loadedShell;

	// Use this for initialization
	void Start () {

       // ca = GameObject.FindGameObjectWithTag("Animator").GetComponent<CannonAnimation>();


    }
	
	// Update is called once per frame
	void Update () {

        GetComponent<CapsuleCollider>().enabled = HatchControl.HATCH_OPEN;
	
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Shell" && !col.GetComponent<Shell>().HaveBeenFired && !CANNON_LOADED)
        {

            loadedShell = col.GetComponent<Shell>();

            col.GetComponent<Shell>().Load(transform);

            CANNON_LOADED = true;

            ca.SetTrigger("Shell");

        }


    }

    public void Eject()
    {

        if (loadedShell != null)
        {

            loadedShell.Eject();


            loadedShell = null;

        }



    }



}
