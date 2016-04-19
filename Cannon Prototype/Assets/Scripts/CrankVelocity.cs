using UnityEngine;
using System.Collections;

public class CrankVelocity : MonoBehaviour {

    public GameObject ObjectToRotate;

    public GameObject Dial;

    public bool IsAngleDial = false;

    public enum axis
    {
        X,Y,Z
    }

    public axis Axis;

    private HingeJoint hj;

    private AudioSource audioSource;

    private float soundVelocity;

    // Use this for initialization
    void Start () {

        hj = GetComponent<HingeJoint>();

        audioSource = GetComponent<AudioSource>();



    }
	
	// Update is called once per frame
	void Update () {

        switch (Axis)
        {
            case axis.X:

                ObjectToRotate.transform.Rotate(hj.velocity * Time.deltaTime / 100f, 0f, 0f);

                break;

            case axis.Y:

                ObjectToRotate.transform.Rotate(0f, hj.velocity * Time.deltaTime / 100f, 0f);

                break;

            case axis.Z:

                ObjectToRotate.transform.Rotate(0f, 0f, hj.velocity * Time.deltaTime / 100f);

                break;


        }

        if (Dial != null)
        {
            if (IsAngleDial)
            {
                Dial.transform.Rotate(0f, 0f, (hj.velocity * Time.deltaTime / 100f) * -1f);
            }
            else
            {

                Dial.transform.Rotate(0f, 0f, (hj.velocity * Time.deltaTime / 100f) * 2f);
            }
        }

        audioSource.volume = SoundVelocity(hj.velocity);

        if (hj.angle < 2f && hj.angle > 0f)
        {

            audioSource.Play();

        }

        ObjectToRotate.GetComponent<AudioSource>().volume = SoundVelocity(hj.velocity);

    }

    float SoundVelocity(float v)
    {

        float absV = Mathf.Abs(v);

        float mappedV = Utility.MapRange(absV, 0f, 180f, 0f, 1f);


        return Mathf.Clamp01(mappedV);
    }


}
