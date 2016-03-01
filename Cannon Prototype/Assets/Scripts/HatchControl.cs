using UnityEngine;
using System.Collections;

public class HatchControl : MonoBehaviour {

    public bool HatchOpen = false;

    public Collider ShellReceptical;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        ShellReceptical.enabled = HatchOpen;


	}

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

}
