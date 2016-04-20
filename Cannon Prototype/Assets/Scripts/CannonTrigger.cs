using UnityEngine;
using System.Collections;

public class CannonTrigger : MonoBehaviour {

    private ConfigurableJoint joint;

    private Vector3 startPosistion;

    public FireController fc;

    public Transform Hammer;

	// Use this for initialization
	void Start () {

     //   startPosistion = transform.localPosition;

      //  joint = GetComponent<ConfigurableJoint>();

	}
	
	// Update is called once per frame
	void Update () {
	
        if(Vector3.Distance(transform.position, Hammer.position) > 0.1f)
        {

            fc.FireCannon();

        }

	}

}
