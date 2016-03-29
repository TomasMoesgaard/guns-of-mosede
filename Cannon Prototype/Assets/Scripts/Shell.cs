using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour {

    public bool HaveBeenFired = false;

    private bool loaded = false;

    public PhysicMaterial BounceMetal;

    public AudioClip SoundMetal;

    public AudioClip SoundGround;

    private AudioSource audio;

    // Use this for initialization
    void Start () {

        audio = GetComponent<AudioSource>();

        StartCoroutine(TurnOnAudio());

    }
	
	// Update is called once per frame
	void Update () {

	}

    public void Eject()
    {

        

        if (ShellLoad.CANNON_LOADED)
        {
            //  ShellLoad.CANNON_LOADED = false;

            StartCoroutine(ChangeLoadedStatus());

            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
            transform.parent = null;
            Collider[] colliders = GetComponentsInChildren<Collider>();
            // GetComponent<Renderer>().enabled = true;
            foreach (Collider c in colliders)
            {

                    c.enabled = true;

            }

            loaded = false;

        }
        else
        {
            HaveBeenFired = true;

            Renderer[] renderers = GetComponentsInChildren<Renderer>();

            foreach (Renderer r in renderers)
            {
                if(r.transform.tag == "Payload")
                {
                   r.enabled = false;
                }
            }

            Collider[] colliders = GetComponentsInChildren<Collider>();

            foreach (Collider c in colliders)
            {
                if (c.transform.tag == "Payload")
                {
                    c.enabled = false;
                }
            }

            foreach (Collider c in colliders)
            {
                if (c.transform.tag == "Shell")
                {
                    c.enabled = true;
                }
            }

            GetComponent<ParticleSystem>().Play();

            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
            transform.parent = null;

          //  GetComponent<Renderer>().enabled = true;
         //   GetComponent<Collider>().enabled = true;

            GetComponent<CapsuleCollider>().material = BounceMetal;

            loaded = false;
        }



    }

    public void Load(Transform rec)
    {

        loaded = true;
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

     //   GetComponent<Renderer>().enabled = false;

    }

    IEnumerator ChangeLoadedStatus()
    {

        yield return new WaitForSeconds(1);

        ShellLoad.CANNON_LOADED = false;

    }

    void OnCollisionEnter(Collision col)
    {

        if(col.collider.tag == "Cannon")
        {

            audio.clip = SoundMetal;

        }
        else
        {

            audio.clip = SoundGround;

        }


        audio.Play();

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

}
