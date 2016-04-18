using UnityEngine;
using System.Collections;
using Leap.Unity;

public class HandFollow : MonoBehaviour {

    public GameObject hand;

    public float handOffset = 0.05f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = hand.transform.position;
        transform.rotation = hand.transform.rotation;


	}
}
