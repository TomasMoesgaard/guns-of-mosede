using UnityEngine;
using System.Collections;
using NewtonVR;

public class LanguageLever : MonoBehaviour {

    public Renderer DanishFlag;

    public Renderer EnglishFlag;

    private NVRLever lever;

    public LanguageManager LM;

	// Use this for initialization
	void Start () {

        lever = GetComponent<NVRLever>();

        if (LanguageManager.CurrentLanguage == LanguageManager.Language.Danish)
        {

            DanishFlag.material.color = Color.white;

            EnglishFlag.material.color = new Color(0.2f, 0.2f, 0.2f, 1f);

        }
        else
        {

            EnglishFlag.material.color = Color.white;

            DanishFlag.material.color = new Color(0.2f, 0.2f, 0.2f, 1f);
        }

    }
	
	// Update is called once per frame
	void Update () {


        if (lever.LeverEngaged)
        {
            LM.ChangeLanguage();

            if(LanguageManager.CurrentLanguage == LanguageManager.Language.Danish)
            {

                DanishFlag.material.color = Color.white;

                EnglishFlag.material.color = new Color(0.2f, 0.2f, 0.2f, 1f);

            }
            else
            {

                EnglishFlag.material.color = Color.white;

                DanishFlag.material.color = new Color(0.2f, 0.2f, 0.2f, 1f);
            }


        }


    }


}
