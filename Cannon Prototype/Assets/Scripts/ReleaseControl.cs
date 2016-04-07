using UnityEngine;
using System.Collections;

public class ReleaseControl : MonoBehaviour {

    public HatchControl hc;

    public HingeJoint joint;

	// Use this for initialization
	void Start () {

     //   joint = GetComponent<HingeJoint>();

	}
	
	// Update is called once per frame
	void Update () {

     //  Debug.Log("Release: " + joint.angle);

        if(Mathf.Abs(joint.angle) > 14f)
        {

            hc.Unlock();

        }

	}
}
