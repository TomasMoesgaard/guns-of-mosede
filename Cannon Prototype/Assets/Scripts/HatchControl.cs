using UnityEngine;
using System.Collections;

public class HatchControl : MonoBehaviour {

    public static bool HATCH_OPEN = true;

    public static bool HATCH_FULLY_OPEN = true;

    public static bool HATCH_LOCKED = false;

    public static bool SHELL_CONTAINED = false;

    public Collider ShellReceptical;

    private HingeJoint joint;

    private FixedJoint fJoint;

    public ShellLoad sl;

    private AudioSource sound;

	// Use this for initialization
	void Start () {

        sound = GetComponent<AudioSource>();

        joint = GetComponent<HingeJoint>();
	
	}
	
	// Update is called once per frame
	void Update () {

     //   Debug.Log("Hatch: " + joint.angle);
        

        if (joint.angle > -89)
        {
            HATCH_OPEN = true;
        }


        if (joint.angle > -5)
        {

            HATCH_FULLY_OPEN = true;

            if (SHELL_CONTAINED)
            {

                sl.Eject();

                SHELL_CONTAINED = false;
            }
    
        }
        else
        {
            HATCH_FULLY_OPEN = false;
        }


        if(HATCH_OPEN && joint.angle < -89)
        {

            Lock();

            if(sl.loadedShell != null)
            {
                SHELL_CONTAINED = true;
            }

        }


	}

    public void Lock()
    {

        HATCH_OPEN = false;

        HATCH_LOCKED = true;

        fJoint = gameObject.AddComponent<FixedJoint>();

        fJoint.connectedBody = transform.parent.GetComponent<Rigidbody>();

        sound.Play();

    }

    public void Unlock()
    {

        if (HATCH_LOCKED)
        {

            GameObject.Destroy(fJoint);

            GetComponent<Rigidbody>().AddRelativeForce(0, 0, -20);

            HATCH_LOCKED = false;

            sound.Play();
        }
    }
}
