using UnityEngine;
using System.Collections;

public class CameraChange : MonoBehaviour {

    public SteamVR_GameView GameView;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeCamera();
        }

	
	}

    public void ChangeCamera()
    {

        if (GameView.enabled)
        {

            GameView.enabled = false;

        }
        else
        {

            GameView.enabled = true;

        }

    }
}
