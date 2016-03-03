using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour {

    public ParticleSystem Blast;



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
            ShellLoad.CANNON_LOADED = false;

            Debug.Log(HitCheck());
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




}
