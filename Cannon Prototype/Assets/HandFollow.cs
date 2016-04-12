using UnityEngine;
using System.Collections;
using Leap.Unity;

public class HandFollow : MonoBehaviour {

    public CapsuleHand hand;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        if(hand.isActiveAndEnabled)
        transform.position = hand.PalmPosition();



	}
}
