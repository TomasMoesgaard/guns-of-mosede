using UnityEngine;
using System.Collections;

public class CrankVelocity : MonoBehaviour {

    public GameObject pillar;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        pillar.GetComponent<TurnTest>().Turn(GetComponent<HingeJoint>().velocity);

        Debug.Log(GetComponent<HingeJoint>().velocity);




    }
}
