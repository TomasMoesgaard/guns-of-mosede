using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TargetRandomizer : MonoBehaviour {

    public enum Location {Agergaard, Himmelbjerg, Langagergaard, Søhøj};

    public Location TargetLocation;

    public Transform agergaard;
    public Transform himmebjærg;
    public Transform langagergaard;
    public Transform søhøj;

    public Text TargetText;
    // Use this for initialization
    void Start () {

        NewLocation();


    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.T))
        {
            NewLocation();

        }

	}

   Location RandomLocation()
    {
        Location l = Location.Agergaard;

        int randInt = Random.Range(0, 4);

        switch (randInt)
        {
            case 0:
                l = Location.Agergaard;
                break;
            case 1:
                l = Location.Himmelbjerg;
                break;
            case 2:
                l = Location.Langagergaard;
                break;
            case 3:
                l = Location.Søhøj;
                break;

        }

        while(l == TargetLocation)
        {

            l = RandomLocation();

        }

        return l;
    }

    public void NewLocation()
    {

        TargetLocation = RandomLocation();

        switch (TargetLocation)
        {
            case Location.Agergaard:
                transform.position = agergaard.position;
                TargetText.text = "Mål: Agergaard";
                break;
            case Location.Himmelbjerg:
                transform.position = himmebjærg.position;
                TargetText.text = "Mål: Himmelbjærg";
                break;
            case Location.Langagergaard:
                transform.position = langagergaard.position;
                TargetText.text = "Mål: Langagergaard";
                break;
            case Location.Søhøj:
                transform.position = søhøj.position;
                TargetText.text = "Mål: Søhøj";
                break;
        }

    }

}
