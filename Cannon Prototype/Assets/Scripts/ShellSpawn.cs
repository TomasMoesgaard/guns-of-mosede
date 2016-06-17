using UnityEngine;
using System.Collections;

public class ShellSpawn : MonoBehaviour {

    public GameObject ShellPrefab;

    public Transform SpawnPoint;

    private bool empty = false;

    private Collider[] shells;

    private int numberOfShells;

    public Camera EyeCamera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(empty && !GetComponent<Renderer>().IsVisibleFrom(EyeCamera))
        {
            Instantiate(ShellPrefab, SpawnPoint.position, SpawnPoint.rotation);
        }

        shells = Physics.OverlapBox(transform.position, new Vector3(0.3f, 0.3f, 0.3f), transform.rotation);

        foreach(Collider col in shells)
        {

            if(col.tag == "Shell")
            {
                numberOfShells++;
         
            }


        }
        if (numberOfShells > 0)
        {
            empty = false;
        }
        else
        {
            empty = true;
        }

        numberOfShells = 0;

    }


}
