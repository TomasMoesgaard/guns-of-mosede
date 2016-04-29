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

    private float velocity;

    // Use this for initialization
    void Start () {

        hj = GetComponent<HingeJoint>();

        audioSource = GetComponent<AudioSource>();



    }
	
	// Update is called once per frame
	void Update () {

        velocity = hj.velocity;

        /*
        if(Axis == axis.X)
        {
            if (ObjectToRotate.transform.localRotation.x > 360 && velocity > 0f)
            {
                velocity = 0f;
            }

            if (ObjectToRotate.transform.localRotation.x < 270 && velocity < 0f)
            {
                velocity = 0f;
            }
        }
        */

        switch (Axis)
        {
            case axis.X:

                ObjectToRotate.transform.Rotate(velocity * Time.deltaTime / 100f, 0f, 0f);

                break;

            case axis.Y:

                ObjectToRotate.transform.Rotate(0f, velocity * Time.deltaTime / 100f, 0f);

                break;

            case axis.Z:

                ObjectToRotate.transform.Rotate(0f, 0f, velocity * Time.deltaTime / 100f);

                break;
        }

        if (Dial != null)
        {
            if (IsAngleDial)
            {
                Dial.transform.Rotate(0f, 0f, (velocity * Time.deltaTime / 100f) * -1f);
            }
            else
            {
                Dial.transform.Rotate(0f, 0f, (velocity * Time.deltaTime / 100f) * 4f);
            }
        }

        audioSource.volume = SoundVelocity(velocity);

        if (hj.angle < 2f && hj.angle > 0f)
        {

            audioSource.Play();

        }

        ObjectToRotate.GetComponent<AudioSource>().volume = SoundVelocity(velocity);

    }

    float SoundVelocity(float v)
    {

        float absV = Mathf.Abs(v);

        float mappedV = Utility.MapRange(absV, 0f, 360f, 0f, 0.2f);


        return Mathf.Clamp(mappedV, 0f, 0.2f);
    }


}
