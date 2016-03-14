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

        TargetLocation = RandomLocation();

        switch (TargetLocation)
        {
            case Location.Agergaard:
                transform.position = agergaard.position;
                TargetText.text = "Target: Agergaard";
                break;
            case Location.Himmelbjerg:
                transform.position = himmebjærg.position;
                TargetText.text = "Target: Himmelbjærg";
                break;
            case Location.Langagergaard:
                transform.position = langagergaard.position;
                TargetText.text = "Target: Langagergaard";
                break;
            case Location.Søhøj:
                transform.position = søhøj.position;
                TargetText.text = "Target: Søhøj";
                break;
        }



        //transform.position = new Vector3(Random.Range(-500, -7000), 0f, Random.Range(7000, -7000));


    }
	
	// Update is called once per frame
	void Update () {
	
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

        return l;
    }

}
