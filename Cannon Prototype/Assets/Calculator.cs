using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Calculator : MonoBehaviour {

    public Text Output;

    public Text Input;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CalculateAngle()
    {



        float n;
        bool isNumeric = float.TryParse(Input.text, out n);



        if (isNumeric)
        {
            Output.text = Utility.CalculateCanonTilt(float.Parse(Input.text)).ToString("F1");

            if(Output.text == "NaN")
            {

                Output.text = "0";

            }

        }
        else
        {

            Output.text = "0";

        }


    }
}
