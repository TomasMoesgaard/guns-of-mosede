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

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.LeftShift) && !loaded)
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
            transform.parent = null;
        }

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

           // GetComponent<Renderer>().enabled = true;
           GetComponent<Collider>().enabled = true;

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
                   r.GetComponent<Renderer>().enabled = false;
                }
            }

            GetComponent<ParticleSystem>().Play();

            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
            transform.parent = null;

          //  GetComponent<Renderer>().enabled = true;
            GetComponent<Collider>().enabled = true;

            GetComponent<CapsuleCollider>().material = BounceMetal;

            loaded = false;
        }



    }

    public void Load(Transform rec)
    {

        loaded = true;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Collider>().enabled = false;

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


}
