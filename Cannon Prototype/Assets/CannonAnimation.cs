using UnityEngine;
using System.Collections;

public class CannonAnimation : MonoBehaviour {

    private Animator anim;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();


	}
	
	// Update is called once per frame
	void Update () {

        //anim.SetTrigger("Insert");

	
	}

    public void Animate(string s)
    {
       // Debug.Log("PLays");
        anim.SetTrigger(s);

    }

    public void ReleaseShell()
    {

        GetComponentInChildren<Shell>().Eject();

    }



}
