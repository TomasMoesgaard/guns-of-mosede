using UnityEngine;
using System.Collections;

public class CannonAnimation : MonoBehaviour {

    private Animator anim;

    public static int STATE = 0;

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
        switch (s)
        {
            case "Insert":

                if(STATE == 0)
                {
                    anim.SetTrigger(s);
                    STATE = 1;
                }

                break;

            case "Hatch":

                if (STATE == 1)
                {
                    anim.SetTrigger(s);
                    STATE = 2;
                }

                if(STATE == 0)
                {
                    anim.SetTrigger(s);
                    STATE = -1;
                }

                if (STATE == 3)
                {
                    anim.SetTrigger(s);
                    StartCoroutine(Wait());
                }

                break;

            case "Fire":
                if (STATE == 2)
                {
                    anim.SetTrigger(s);
                }
                break;

            case "Release":
                if (STATE == 2)
                {
                    anim.SetTrigger(s);
                    STATE = 3;
                }
                if (STATE == -1)
                {
                    anim.SetTrigger(s);
                    STATE = 3;
                }

                break;


        }

        Debug.Log(STATE);

        // Debug.Log("PLays");
        /*
        anim.ResetTrigger("Insert");
        anim.ResetTrigger("Fire");
        anim.ResetTrigger("Close");
        anim.ResetTrigger("Open");
        anim.ResetTrigger("Extract");
        anim.ResetTrigger("Release");
        */

        /*
        if (s == "Insert")
        {
            anim.ResetTrigger("Fire");
            anim.ResetTrigger("Close");
            anim.ResetTrigger("Open");
            anim.ResetTrigger("Extract");
            anim.ResetTrigger("Release");
        }

        if (s == "Release")
        {
            anim.ResetTrigger("Open");
        }

        if (s == "Close")
        {
            anim.ResetTrigger("Fire");
        }

        if (s == "Open")
        {
            anim.ResetTrigger("Close");
        }

        anim.SetTrigger(s);
        */
    }

    public void ReleaseShell()
    {
        if(GetComponentInChildren<Shell>() != null)
        GetComponentInChildren<Shell>().Eject();

    }

    public void ResetTriggers()
    {
      //  anim.ResetTrigger("Insert");
        anim.ResetTrigger("Fire");
        anim.ResetTrigger("Close");
        anim.ResetTrigger("Open");
        anim.ResetTrigger("Release");
    }

    IEnumerator Wait()
    {
        STATE = 5;

        yield return new WaitForSeconds(2);

        STATE = 0;
    }


}
