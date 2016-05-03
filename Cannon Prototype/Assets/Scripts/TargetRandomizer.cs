using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TargetRandomizer : MonoBehaviour {

    public enum Location {Agergaard, Himmelbjerg, Langagergaard, Søhøj, Kildegaard, Søndergaard, Sønderholm};

    public Location TargetLocation;

    public Transform agergaard;
    public Transform himmebjærg;
    public Transform langagergaard;
    public Transform søhøj;
    public Transform kildegaard;
    public Transform søndergaard;
    public Transform sønderholm;

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

        int randInt = Random.Range(0, 7);

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
            case 4:
                l = Location.Kildegaard;
                break;
            case 5:
                l = Location.Søndergaard;
                break;
            case 6:
                l = Location.Sønderholm;
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
                TargetText.text = "Agergaard";
                break;
            case Location.Himmelbjerg:
                transform.position = himmebjærg.position;
                TargetText.text = "Himmelbjærg";
                break;
            case Location.Langagergaard:
                transform.position = langagergaard.position;
                TargetText.text = "Langagergaard";
                break;
            case Location.Søhøj:
                transform.position = søhøj.position;
                TargetText.text = "Søhøj";
                break;
            case Location.Kildegaard:
                transform.position = kildegaard.position;
                TargetText.text = "Kildegaard";
                break;
            case Location.Søndergaard:
                transform.position = søndergaard.position;
                TargetText.text = "Søndergaard";
                break;
            case Location.Sønderholm:
                transform.position = sønderholm.position;
                TargetText.text = "Sønderholm";
                break;
        }

    }

}
