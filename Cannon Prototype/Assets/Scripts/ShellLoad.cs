using UnityEngine;
using System.Collections;

public class ShellLoad : MonoBehaviour {


    public static bool CANNON_LOADED = false;

    public CannonAnimation ca;

	// Use this for initialization
	void Start () {

       // ca = GameObject.FindGameObjectWithTag("Animator").GetComponent<CannonAnimation>();


    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Shell" && !col.GetComponent<Shell>().HaveBeenFired && !CANNON_LOADED)
        {

            col.GetComponent<Shell>().Load(transform);

            CANNON_LOADED = true;

            ca.Animate("Insert");

        }


    }



}
