using UnityEngine;
using System.Collections;

public class TurnTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Turn(float v)
    {

        transform.Rotate(0f, v * Time.deltaTime / 100f, 0f);

    }

}
