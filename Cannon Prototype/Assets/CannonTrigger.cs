using UnityEngine;
using System.Collections;

public class CannonTrigger : MonoBehaviour {

    private ConfigurableJoint joint;

    private Vector3 startPosisiton;

    public FireController fc;

	// Use this for initialization
	void Start () {

        startPosisiton = transform.localPosition;

        joint = GetComponent<ConfigurableJoint>();

	}
	
	// Update is called once per frame
	void Update () {
	
        if(transform.localPosition.z < transform.localPosition.z - joint.linearLimit.limit + 0.005f)
        {

            fc.FireCannon();

        }

	}

}
