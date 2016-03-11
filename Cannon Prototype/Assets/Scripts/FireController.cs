using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FireController : MonoBehaviour {

    public ParticleSystem Blast;

    public AudioSource Sound;

    public Text text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {




	
	}

    public void FireCannon()
    {

        if (ShellLoad.CANNON_LOADED)
        {
            Blast.Play();
            Sound.Play();

            ShellLoad.CANNON_LOADED = false;

            StartCoroutine(HitMessage());

        }

       
    } 

    public bool HitCheck()
    {
        bool hit = false;

        if (Mathf.Abs(CannonTurning.ANGLE_TO_TARGET) < 2)
        {

            if(Mathf.Abs(CannonTilting.RANGE_DIFFERENCE) < 50)
            {
                hit = true;
            }

        }

        Debug.Log("Distance: " + CannonTilting.RANGE_DIFFERENCE + "  Angle: " + CannonTurning.ANGLE_TO_TARGET);

        return hit;

    }

    IEnumerator HitMessage()
    {

        if (HitCheck())
        {

            text.text = "HIT";

        }
        else
        {
            text.text = "MISS";
        }

        yield return new WaitForSeconds(3);

        text.text = "";


    }




}
