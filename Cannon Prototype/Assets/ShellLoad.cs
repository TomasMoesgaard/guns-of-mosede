using UnityEngine;
using System.Collections;

public class ShellLoad : MonoBehaviour {


    public static bool CANNON_LOADED = false;

	// Use this for initialization
	void Start () {
	
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

        }


    }

}
