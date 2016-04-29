using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class CollisionAudio : MonoBehaviour {

    private AudioSource audioSource;



    // Use this for initialization
    void Start () {

        audioSource = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {


        audioSource.volume = col.relativeVelocity.magnitude * 0.1f;

        

        audioSource.Play();

    }
}
