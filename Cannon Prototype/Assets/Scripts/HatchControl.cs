using UnityEngine;
using System.Collections;

public class HatchControl : MonoBehaviour {

    public static bool HATCH_OPEN = true;

    public static bool HATCH_LOCKED = false;

    public Collider ShellReceptical;

    private HingeJoint joint;

    private FixedJoint fJoint;

    public ShellLoad sl;

	// Use this for initialization
	void Start () {

        joint = GetComponent<HingeJoint>();
	
	}
	
	// Update is called once per frame
	void Update () {
        if(joint.angle > -5)
        {

            HATCH_OPEN = true;

            sl.Eject();

        }

        if(HATCH_OPEN && joint.angle < -89)
        {

            Lock();


        }


	}

    public void Lock()
    {

        HATCH_OPEN = false;

        HATCH_LOCKED = true;

        fJoint = gameObject.AddComponent<FixedJoint>();


    }

    public void Unlock()
    {

        if (HATCH_LOCKED)
        {

            GameObject.Destroy(fJoint);

            GetComponent<Rigidbody>().AddRelativeForce(0, 0, -20);

            HATCH_LOCKED = false;

        }
    }

    /*

    public void ActivateHatch()
    {
        if (HatchOpen)
        {
            GetComponent<Animator>().SetTrigger("Close");
           // HatchOpen = false;
            StartCoroutine(disableCollider());
        }
        else
        {
            GetComponent<Animator>().SetTrigger("Open");
            //HatchOpen = true;
            StartCoroutine(disableCollider());

            if (ShellReceptical.gameObject.GetComponentInChildren<Shell>() != null)
            {
                ShellReceptical.gameObject.GetComponentInChildren<Shell>().Eject();
            }

        }


    }

    IEnumerator disableCollider()
    {


        GetComponent<Collider>().enabled = false;

        yield return new WaitForFixedUpdate();

        yield return new WaitUntil(() => GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 0.98);

        GetComponent<Collider>().enabled = true;

        HatchOpen = !HatchOpen;
    }
    */
}
