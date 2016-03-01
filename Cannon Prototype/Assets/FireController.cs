using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour {

    public ParticleSystem Blast;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {




	
	}

    public void FireCannon()
    {

        if (ShellLoad.CANNON_LOADED)
        {
            Blast.Play();
            ShellLoad.CANNON_LOADED = false;
        }

       
    } 




}
