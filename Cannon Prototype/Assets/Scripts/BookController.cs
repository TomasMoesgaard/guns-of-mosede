using UnityEngine;
using System.Collections;
using NewtonVR;

public class BookController : MonoBehaviour {

    private Animator anim;

    public Canvas RightCanvas;

    public Canvas LeftCanvas;

    private NVRHand hand;

    private SkinnedMeshRenderer mesh;

    private bool PagesVisible = false;

    private bool FacingPlayer = true;

    public Transform Face;

    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator>();

        hand = GetComponentInParent<NVRHand>();

        mesh = GetComponentInChildren<SkinnedMeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Face != null)
        {
            if (Vector3.Dot(-transform.forward, Face.forward) < -0.5)
            {

                FacingPlayer = true;

            }
            else
            {
                FacingPlayer = false;
            }

        }

        if (hand.PadPressed && FacingPlayer)
        {

            anim.SetBool("BookOpen", true);


        }
        else {

            anim.SetBool("BookOpen", false);



        }

	}

    public void ShowPages()
    {
        
        if (!PagesVisible)
        {
            RightCanvas.gameObject.SetActive(true);

            LeftCanvas.gameObject.SetActive(true);

            PagesVisible = true;


            mesh.enabled = true;

        }
        else
        {

            RightCanvas.gameObject.SetActive(false);

            LeftCanvas.gameObject.SetActive(false);

            PagesVisible = false;

            mesh.enabled = false;

        }
        

    }

}
