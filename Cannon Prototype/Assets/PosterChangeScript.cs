using UnityEngine;
using System.Collections;
using Leap.Unity;

public class PosterChangeScript : MonoBehaviour {

    public Texture2D leap;

    public Texture2D vive;

    public LeapServiceProvider lsp;

    private Renderer ren;

    private float timer = 0f;

    // Use this for initialization
    void Start () {

        ren = GetComponent<Renderer>();

	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;

        if (timer > 1f)
        {

            if (lsp.IsConnected())
            {

                ren.material.SetTexture("_MainTex", leap);

            }
            else
            {
                ren.material.SetTexture("_MainTex", vive);
            }

            timer = 0f;
        }

	}

}
