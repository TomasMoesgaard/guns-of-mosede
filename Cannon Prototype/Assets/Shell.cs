using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour {

    public bool HaveBeenFired = false;

    private bool loaded = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.K) && !loaded)
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
            transform.parent = null;
        }

	}

    public void Eject()
    {

        if (ShellLoad.CANNON_LOADED)
        {
            ShellLoad.CANNON_LOADED = false;

            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
            transform.parent = null;

            GetComponent<Renderer>().enabled = true;

            loaded = false;

        }
        else
        {
            HaveBeenFired = true;

            Renderer[] renderers = GetComponentsInChildren<Renderer>();

            foreach (Renderer r in renderers)
            {
                if(r.transform.tag == "Payload")
                {
                   r.GetComponent<Renderer>().enabled = false;
                }
            }

            GetComponent<ParticleSystem>().Play();

            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
            transform.parent = null;

            GetComponent<Renderer>().enabled = true;

            loaded = false;
        }



    }

    public void Load(Transform rec)
    {

        loaded = true;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;

        transform.parent = rec;

        transform.position = rec.position;
        transform.rotation = rec.rotation;

        GetComponent<Renderer>().enabled = false;

    }

}
