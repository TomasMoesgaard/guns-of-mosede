using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class RadioDialControl : MonoBehaviour {

    public HingeJoint Volume;

    private float lastVolume;

    public HingeJoint Distortion;

    private float lastDistortion;

    public HingeJoint Pitch;

    private float lastPitch;

    public HingeJoint Flange;

    private float lastFlange;

    public HingeJoint Static1;

    private float lastStatic1;

    public HingeJoint Static2;

    private float lastStatic2;

    public AudioSource StaticAudio1;

    public AudioSource StaticAudio2;

    public float DestructionValue = 100f; 

    public AudioMixer mixer;

    public ParticleSystem Sparks;



    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(Volume.angle != lastVolume)
        {

            SetVolume(Utility.MapRange(Volume.angle, Volume.limits.max, Volume.limits.min, -40f, 5f));

            lastVolume = Volume.angle;
        }

        if (Distortion.angle != lastDistortion)
        {

            SetDistortion(Utility.MapRange(Distortion.angle, Distortion.limits.max, Distortion.limits.min, 0f, .8f));

            lastDistortion = Distortion.angle;
        }


        if (Pitch.angle != lastPitch)
        {

            SetPitch(Utility.MapRange(Pitch.angle, Pitch.limits.max, Pitch.limits.min, 0.5f, 2f));

            lastPitch = Pitch.angle;
        }

        if (Flange.angle != lastFlange)
        {

            SetFlange(Utility.MapRange(Flange.angle, Flange.limits.max, Flange.limits.min, 0f, 1f));

            lastFlange = Flange.angle;
        }

        if(Static1.angle != lastStatic1)
        {

            StaticAudio1.volume =Mathf.Abs(Utility.MapRange(Mathf.Abs(180 - Static1.angle), 0, 180, 0, 0.1f));

        }

        if (Static2.angle != lastStatic2)
        {

            StaticAudio2.volume = Mathf.Abs(Utility.MapRange(Mathf.Abs(180 - Static2.angle), 0, 180, 0, 0.1f));

           // Debug.Log(Static2.angle);

        }

    }

    void OnCollisionEnter(Collision col)
    {

        if(col.relativeVelocity.magnitude * col.rigidbody.mass > DestructionValue)
        {

            Destroy(GetComponent<AudioSource>());

            Sparks.Play();

            Sparks.gameObject.GetComponent<AudioSource>().Play();

            Destroy(StaticAudio1.gameObject);
            Destroy(StaticAudio2.gameObject);

            Destroy(this);

        }

    }

    void SetVolume(float v)
    {

        mixer.SetFloat("volume", v);

    }

    void SetDistortion(float d)
    {

        mixer.SetFloat("distortion", d);

    }

    void SetFlange(float f)
    {

      //  Debug.Log(f);

        mixer.SetFloat("wetFlange", f);

        mixer.SetFloat("dryFlange", Utility.MapRange(f, 0f, 1f, 1f, 0f));

    }

    void SetPitch(float p)
    {

        mixer.SetFloat("pitch", p);

    }
}
