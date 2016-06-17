using UnityEngine;
using System.Collections;

public class WebcamScript : MonoBehaviour {

   WebCamTexture webcamTexture;

    // Use this for initialization
    void Start () {
        webcamTexture = new WebCamTexture();
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = webcamTexture;
        webcamTexture.Play();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StopWebcam()
    {

        webcamTexture.Stop();

    }

}
