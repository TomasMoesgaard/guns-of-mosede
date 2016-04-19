using UnityEngine;
using System.Collections;

public class CompasTurn : MonoBehaviour {

    public Transform north;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.LookAt(new Vector3(transform.position.x, transform.position.y, 50f));

	}
}
