using UnityEngine;
using System.Collections;

public class TurnArrow : MonoBehaviour {


    public enum Rotation { Right, Left};

    public Rotation Direction;

    private float visibilityCounter = 0;

    private Material mat;

    private float offset = 0f;

	// Use this for initialization
	void Start () {

        mat = GetComponent<Renderer>().material;
	
	}
	
	// Update is called once per frame
	void Update () {

        offset -= 1 * Time.deltaTime;

        mat.mainTextureOffset = new Vector2( offset, 0f);


        visibilityCounter -= 0.5f;

        if(visibilityCounter < 0)
        {
            visibilityCounter = 0;
        }

        if(visibilityCounter > 5f)
        {
            visibilityCounter = 5f;
        }

        if(visibilityCounter > 1f)
        {
            GetComponent<Renderer>().enabled = true;
        }
        else
        {
           // GetComponent<Renderer>().enabled = false;
        }


    }

    public void Rotate()
    {
        visibilityCounter += 1f;

        if (Direction == Rotation.Right)
        {

            transform.Rotate(0f, 0f, -100f * Time.deltaTime, Space.Self);

        }
        else {

            transform.Rotate(0f, 0f, 100f * Time.deltaTime, Space.Self);

        }
    }

    void OnTriggerExit(Collider col)
    {

        if(col.tag == "Controller")
        {

            GetComponent<Renderer>().enabled = false;

        }


    }
    void OnTriggerStay(Collider col)
    {

        if (col.tag == "Controller")
        {

            GetComponent<Renderer>().enabled = true;

        }

    }

}
