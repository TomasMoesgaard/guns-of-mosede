using UnityEngine;
using System.Collections;

public class Smoke : MonoBehaviour {

    private ParticleSystem ps;

	// Use this for initialization
	void Start () {

        ps = GetComponentInChildren<ParticleSystem>();


    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider col)
    {

        if(col.tag == "Face")
        {

            if (ps.isStopped)
            {
                ps.Play();
            }

        }

    }

    void OnTriggerExit(Collider col)
    {

        if (col.tag == "Face")
        {


                ps.Stop();


        }

    }

}
