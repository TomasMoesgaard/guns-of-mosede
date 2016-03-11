using UnityEngine;
using System.Collections;

public class AnimationActivator : MonoBehaviour {

    public string[] Trigger;

    public string[] ActiveState;

    private CannonAnimation ca;

	// Use this for initialization
	void Start () {

        ca = GetComponentInParent<CannonAnimation>();

        //ca = GameObject.FindGameObjectWithTag("Cannon");

	}
	
	// Update is called once per frame
	void Update () {

       // Debug.Log(ca.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).fullPathHash);


	}

    public void Activate()
    {

        ca.Animate(Trigger[0]);

        /*
        if (ActiveState.Length == 1)
        {
            if (ca.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(ActiveState[0]))
            {
                ca.GetComponent<CannonAnimation>().Animate(Trigger[0]);
            }
        }
        else if(ActiveState.Length == 2)
        {
            if (ca.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(ActiveState[0]) || ca.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(ActiveState[1]))
            {
                ca.GetComponent<CannonAnimation>().Animate(Trigger[0]);
            }
        }
        else
        {
         //   Debug.Log("Got here!");
            if (ca.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(ActiveState[0]) || ca.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(ActiveState[1]) || ca.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(ActiveState[2]))
            {
                ca.GetComponent<CannonAnimation>().Animate(Trigger[0]);
            }

        }
        /*
        if(Trigger.Length == 2)
        {
            string s = Trigger[0];
            Trigger[0] = Trigger[1];
            Trigger[1] = s;
        }
        */
    }

}
