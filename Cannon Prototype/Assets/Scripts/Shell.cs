using UnityEngine;
using System.Collections;
using NewtonVR;

public class Shell : MonoBehaviour {

    public bool HaveBeenFired = false;

    private bool loaded = false;

    public PhysicMaterial BounceMetal;

    public AudioClip SoundMetal;

    public AudioClip SoundGround;

    private AudioSource audioSource;

    // Use this for initialization
    void Start () {

        audioSource = GetComponent<AudioSource>();

        StartCoroutine(TurnOnAudio());

    }
	
	// Update is called once per frame
	void Update () {

	}

    public void LoadShell(Transform rec)
    {

        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;


        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider c in colliders)
        {

            c.enabled = false;

        }

        transform.parent = rec;

        transform.position = rec.position;
        transform.rotation = rec.rotation;

        GetComponent<NVRInteractableItem>().enabled = false;

    }

    public void FireShell()
    {

        Destroy(transform.GetChild(0).gameObject);

        transform.tag = "SpentShell";

    }

    public void UnloadShell()
    {

        StartCoroutine(DelayUnload());

    }

    IEnumerator ChangeTag()
    {

        tag = "UnspentShell";

        yield return new WaitForSeconds(2f);

        tag = "Shell";

    }

    void OnCollisionEnter(Collision col)
    {

        if(col.collider.tag == "Cannon")
        {

            audioSource.clip = SoundMetal;

        }
        else
        {

            audioSource.clip = SoundGround;

        }


        audioSource.Play();

    }

    public void LetGo()
    {
        if (!loaded)
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
            transform.parent = null;
        }
    }

    IEnumerator TurnOnAudio()
    {

        yield return new WaitForSeconds(2);

        GetComponent<AudioSource>().enabled = true;

    }

    IEnumerator DelayUnload()
    {


        if (tag == "Shell")
        {

            StartCoroutine(ChangeTag());

        }

        yield return new WaitForSeconds(0.8f);

        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().useGravity = true;

        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider c in colliders)
        {

            c.enabled = true;

        }

        GetComponent<NVRInteractableItem>().enabled = true;

        transform.parent = null;

    }
}
