using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour {

    public AudioSource CannonFire;



    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.R))
        {

            ShellLoad.CANNON_LOADED = false;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);



        }

	
	}

    public static void PlaySound(string S)
    {



    }

}
