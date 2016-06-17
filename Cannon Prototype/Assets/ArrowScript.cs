using UnityEngine;
using System.Collections;
using NewtonVR;

public class ArrowScript : MonoBehaviour {

    public GameObject AmmoArrow;

    public GameObject InsertArrow;

    public GameObject HatchArrow;

    public GameObject SmallWheelArrow;

    public GameObject BigWheelArrow;

    public GameObject TriggerArrow;

    public GameObject HatchReleaseArrow;

    public GameObject HatchOpenArrow;

    public Transform CannonPositon;

    public static int TUTORIAL_STATE = 0;

    public static bool TUTORIAL_ON = true;

    private bool justOpened = false;

    private bool fired = false;

    private bool holdingShell = false;

    private bool holdingWheel = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.U))
        {
            TUTORIAL_ON = !TUTORIAL_ON;
        }


        if (TUTORIAL_ON)
        {

            holdingShell = false;

            holdingWheel = false;

            GameObject[] controllers = GameObject.FindGameObjectsWithTag("Controller");

            foreach(GameObject c in controllers)
            {
                if (c.GetComponent<NVRHand>().SHELL_IN_HAND)
                {
                    holdingShell = true;
                }
                if (c.GetComponent<NVRHand>().WHEEL_IN_HAND)
                {
                    holdingWheel = true;
                }
            }

        }


        //TUTORIAL_STATE starts on 0

        //if the tutorial is turned on, after having been turned off, then go to state 0
        if(TUTORIAL_STATE == -1 && TUTORIAL_ON)
        {
            TUTORIAL_STATE = 0;
        }

        //if the player grabs a shell go to state 1
        if (TUTORIAL_STATE == 0 && holdingShell)
        {
            TUTORIAL_STATE = 1;

         //   Debug.Log("Runs 1");
        }

        //if the state is 0 or 1 and the hatch is not fully open go to state 6
        if (TUTORIAL_STATE == 0 && !HatchControl.HATCH_FULLY_OPEN)
        {
            TUTORIAL_STATE = 6;

         //   Debug.Log("Runs 2");
        }

        if (TUTORIAL_STATE == 1 && !HatchControl.HATCH_FULLY_OPEN)
        {
            TUTORIAL_STATE = 6;

         //   Debug.Log("Runs 3");
        }

        //if the player inserts the shell go to state 2
        if (TUTORIAL_STATE == 1 && ShellLoad.CANNON_LOADED)
        {
            TUTORIAL_STATE = 2;

         //   Debug.Log("Runs 4");
        }

        //if the player lets go of the shell, back to state 0
        if (TUTORIAL_STATE == 1 && !holdingShell && !ShellLoad.CANNON_LOADED)
        {
            TUTORIAL_STATE = 0;

         //   Debug.Log("Runs 5");
        }

        //if the player closes the hatch go to state 3
        if (TUTORIAL_STATE == 2 && HatchControl.HATCH_LOCKED && HatchControl.SHELL_CONTAINED)
        {
            TUTORIAL_STATE = 3;

         //   Debug.Log("Runs 6");
        }

        //if the player prematurely opens the hatch to to state 2
        if(TUTORIAL_STATE == 3 && !HatchControl.HATCH_LOCKED)
        {
            TUTORIAL_STATE = 2;

        //    Debug.Log("Runs 7");

            justOpened = true;
        }

        //if the player fires the cannon prematurely go to state 5
        if(TUTORIAL_STATE == 3 && !ShellLoad.CANNON_LOADED)
        {
            TUTORIAL_STATE = 5;

         //   Debug.Log("Runs 8");
        }

        //when the player has turned the wheels, put arrow on trigger in state 4
        if (TUTORIAL_STATE == 3 && holdingWheel)
        {
            TUTORIAL_STATE = 4;

         //   Debug.Log("Runs 9");
        }

        //if the player fires the cannon go to state 5
        if (TUTORIAL_STATE == 4 && !ShellLoad.CANNON_LOADED)
        {
            TUTORIAL_STATE = 5;

            fired = true;

         //   Debug.Log("Runs 10");
        }

        //if the player closes the hatch without a shell in the cannon go to state 5
        if (TUTORIAL_ON && HatchControl.HATCH_LOCKED && !HatchControl.SHELL_CONTAINED)
        {
            TUTORIAL_STATE = 5;

          //  Debug.Log("Runs 11");
        }
        
        //if the player opens the hatch when an unfired shell is loaded go to state 0
        if (TUTORIAL_STATE == 2 && HatchControl.HATCH_FULLY_OPEN && justOpened)
        {
            TUTORIAL_STATE = 0;

          //  Debug.Log("Runs 12");

            justOpened = false;
        }
    
        //if the player opens the hatch go to state 6
        if (TUTORIAL_STATE == 5 && !HatchControl.HATCH_LOCKED)
        {
            TUTORIAL_STATE = 6;

          //  Debug.Log("Runs 13");
        }

        //if the player closes the hatch without opening it fully go to state 5
        if (TUTORIAL_STATE == 6 && HatchControl.HATCH_LOCKED)
        {
            TUTORIAL_STATE = 5;

          //  Debug.Log("Runs 14");
        }

        //if the cannon is empty and open and the player is not holding a shell go to state 0
        if (TUTORIAL_STATE == 6 && HatchControl.HATCH_FULLY_OPEN)
        {
            TUTORIAL_STATE = 0;


            if (fired)
            {
                TUTORIAL_ON = false;
                fired = false;
            }

         //   Debug.Log("Runs 15");
        }

        //if the tutorial is turned off go to state -1
        if (!TUTORIAL_ON)
        {
            TUTORIAL_STATE = -1;

          //  Debug.Log("Runs 16");
        }


        SetAmmoArrow();

        ExecuteState();

    }



    void ExecuteState()
    {

        switch (TUTORIAL_STATE)
        {

            case -1:

                Hide(AmmoArrow);
                Hide(InsertArrow);
                Hide(HatchArrow);
                Hide(SmallWheelArrow);
                Hide(BigWheelArrow);
                Hide(TriggerArrow);
                Hide(HatchReleaseArrow);
                Hide(HatchOpenArrow);

                break;

            case 0:

                Show(AmmoArrow);

                Hide(InsertArrow);
                Hide(HatchArrow);
                Hide(SmallWheelArrow);
                Hide(BigWheelArrow);
                Hide(TriggerArrow);
                Hide(HatchReleaseArrow);
                Hide(HatchOpenArrow);

                break;

            case 1:

                Show(InsertArrow);

                Hide(AmmoArrow);
                Hide(HatchArrow);
                Hide(SmallWheelArrow);
                Hide(BigWheelArrow);
                Hide(TriggerArrow);
                Hide(HatchReleaseArrow);
                Hide(HatchOpenArrow);

                break;

            case 2:

                Show(HatchArrow);

                Hide(InsertArrow);
                Hide(AmmoArrow);
                Hide(SmallWheelArrow);
                Hide(BigWheelArrow);
                Hide(TriggerArrow);
                Hide(HatchReleaseArrow);
                Hide(HatchOpenArrow);

                break;

            case 3:

                Show(SmallWheelArrow);
                Show(BigWheelArrow);


                Hide(InsertArrow);
                Hide(HatchArrow);
                Hide(AmmoArrow);
                Hide(TriggerArrow);
                Hide(HatchReleaseArrow);
                Hide(HatchOpenArrow);

                break;

            case 4:

                Show(TriggerArrow);
                Show(SmallWheelArrow);
                Show(BigWheelArrow);

                Hide(InsertArrow);
                Hide(HatchArrow);
                Hide(AmmoArrow);
                Hide(HatchReleaseArrow);
                Hide(HatchOpenArrow);

                break;

            case 5:

                Show(HatchReleaseArrow);

                Hide(SmallWheelArrow);
                Hide(BigWheelArrow);
                Hide(InsertArrow);
                Hide(HatchArrow);
                Hide(AmmoArrow);
                Hide(TriggerArrow);
                Hide(HatchOpenArrow);

                break;

            case 6:

                Show(HatchOpenArrow);

                Hide(SmallWheelArrow);
                Hide(BigWheelArrow);
                Hide(InsertArrow);
                Hide(HatchArrow);
                Hide(AmmoArrow);
                Hide(TriggerArrow);
                Hide(HatchReleaseArrow);

                break;


        }


    }

    void Hide(GameObject arrow)
    {

        Renderer[] r = arrow.GetComponentsInChildren<Renderer>();

        foreach(Renderer ren in r)
        {

            ren.enabled = false;

        }

    }

    void Show(GameObject arrow)
    {

        Renderer[] r = arrow.GetComponentsInChildren<Renderer>();

        foreach (Renderer ren in r)
        {

            ren.enabled = true;

        }

    }

    void SetAmmoArrow()
    {
        GameObject[] shells = GameObject.FindGameObjectsWithTag("Shell");

        GameObject nearestShell = shells[0];

        foreach(GameObject shell in shells)
        {
            if (Vector3.Distance(CannonPositon.position, shell.transform.position) < Vector3.Distance(CannonPositon.position, nearestShell.transform.position))
            {
                nearestShell = shell;
            }
        }

        AmmoArrow.transform.position = nearestShell.transform.position + new Vector3(0, 0.5f, 0);

    }


}
