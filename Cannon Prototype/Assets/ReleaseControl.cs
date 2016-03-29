using UnityEngine;
using System.Collections;

public class ReleaseControl : MonoBehaviour {

    public HatchControl hc;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(GetComponent<HingeJoint>().angle > 14f)
        {

            hc.Unlock();

        }

	}
}
