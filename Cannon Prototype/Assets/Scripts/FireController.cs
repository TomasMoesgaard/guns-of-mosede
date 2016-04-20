using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FireController : MonoBehaviour {

    public ParticleSystem[] Blast;

    public AudioSource Sound;

    public Text text;

    public GameObject HitObject;

    public ShellLoad SL;

    public TargetRandomizer TR;

    private int shotsFired = 0;

    public Text[] texts;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {




	
	}

    public void FireCannon()
    {
       

        if (ShellLoad.CANNON_LOADED && HatchControl.HATCH_LOCKED)
        {

            foreach(ParticleSystem p in Blast)
            {
                p.Play();
            }

            Sound.Play();

            ShellLoad.CANNON_LOADED = false;

            SL.loadedShell.FireShell();

            HitMessage();

           // HitObject.transform.localPosition = new Vector3(CannonTilting.RANGE, 0f, 0f);

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

    void HitMessage()
    {


        if (HitCheck())
        {

            texts[shotsFired].text = "Pletskud";

        }
        else
        {

            texts[shotsFired].text = "Ramte " + CannonTilting.RANGE_DIFFERENCE.ToString("F1") + " M forbi målet";

        }

        shotsFired++;

    }




}
