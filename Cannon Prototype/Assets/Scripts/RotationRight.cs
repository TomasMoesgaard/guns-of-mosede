using UnityEngine;
using System.Collections;

public class RotationRight : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(0f, 0f, 100f * Time.deltaTime, Space.Self);

    }
}
