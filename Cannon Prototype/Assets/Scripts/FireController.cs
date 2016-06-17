using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FireController : MonoBehaviour {

    public ParticleSystem[] Blast;

    public AudioSource Sound;

    public AudioSource DistantSound;

    public AudioSource BingSound;

    public Renderer BoardColor;

    [ColorUsageAttribute(true, true, 0f, 8f, 0.125f, 3f)]
    public Color Blue;
    [ColorUsageAttribute(true, true, 0f, 8f, 0.125f, 3f)]
    public Color Green;
    [ColorUsageAttribute(true, true, 0f, 8f, 0.125f, 3f)]
    public Color Red;

    public Text text;

    public GameObject HitObject;
    public GameObject TargetObject;

    public ShellLoad SL;

    public TargetRandomizer TR;

    private int shotsFired = 0;

    public Text[] texts;

	// Use this for initialization
	void Start () {

        BoardColor.material.EnableKeyword("_EmissionColor");

        BoardColor.material.SetColor("_EmissionColor", Blue);

    }
	
	// Update is called once per frame
	void Update () {


        HitObject.transform.position = transform.GetChild(0).transform.right * CannonTilting.RANGE;


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


            StartCoroutine(DelayedHit());
        }

       
    } 

    public bool HitCheck()
    {
        bool hit = false;

        if (Vector3.Distance(HitObject.transform.position, TargetObject.transform.position) < 100)
        {

                hit = true;

            BoardColor.material.SetColor("_EmissionColor", Green);

        }
        else
        {
            BoardColor.material.SetColor("_EmissionColor", Red);
        }

        //Debug.Log("Distance: " + CannonTilting.RANGE_DIFFERENCE + "  Angle: " + CannonTurning.ANGLE_TO_TARGET);

        return hit;

    }

    IEnumerator DelayedHit()
    {

        DistantSound.PlayDelayed(2);

        yield return new WaitForSeconds(DistantSound.clip.length);

        BingSound.Play();

        if (shotsFired < 3)
        {

            if (LanguageManager.CurrentLanguage == LanguageManager.Language.Danish)
            {
                HitMessageDK();
            }
            else
            {
                HitMessageEN();
            }

        }


    }


    void HitMessageDK()
    {
        texts[0].GetComponentInParent<AudioSource>().Play();

        

        if (HitCheck())
        {

            texts[shotsFired].text = "Pletskud";

        }
        else
        {

            texts[shotsFired].text = "Ramte " + Vector3.Distance(HitObject.transform.position, TargetObject.transform.position).ToString("F1") + " M forbi";

        }

        shotsFired++;

    }

    void HitMessageEN()
    {
        texts[0].GetComponentInParent<AudioSource>().Play();



        if (HitCheck())
        {

            texts[shotsFired].text = "Direct hit";

        }
        else
        {

            texts[shotsFired].text = "Missed by " + Vector3.Distance(HitObject.transform.position, TargetObject.transform.position).ToString("F1") + " M";

        }

        shotsFired++;

    }


}
