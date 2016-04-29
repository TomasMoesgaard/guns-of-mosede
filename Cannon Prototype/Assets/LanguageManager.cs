using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LanguageManager : MonoBehaviour {

    public enum Language { Danish, English};

    public static Language CurrentLanguage = Language.English;

    private bool ChangedSinceLastFrame = true;

    public Text[] Tries;

    public Text Reset;

    public Text Target;

    public GameObject DanishPanel;

    public GameObject EnglishPanel;



    // Use this for initialization
    void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.L))
        {
            ChangeLanguage();
        }

        if (ChangedSinceLastFrame)
        {
            switch (CurrentLanguage)
            {
                case Language.Danish:

                    for(int i = 0; i < Tries.Length; i++)
                    {
                        Tries[i].text = i + 1 + ". forsøg";
                    }

                    Target.text = "Mål:";

                    Reset.text = "< Træk her for at starte forfra";

                    break;

                case Language.English:

                    for (int i = 0; i < Tries.Length; i++)
                    {
                        Tries[i].text = i + 1 + ". try";
                    }

                    Target.text = "Target:";

                    Reset.text = "< Pull here to reset";

                    break;


            }


            ChangedSinceLastFrame = false;


        }

	
	}


   public void ChangeLanguage()
    {

        if(CurrentLanguage == Language.Danish)
        {
            CurrentLanguage = Language.English;

            EnglishPanel.SetActive(true);

            DanishPanel.SetActive(false);

        }
        else
        {
            CurrentLanguage = Language.Danish;

            EnglishPanel.SetActive(false);

            DanishPanel.SetActive(true);

        }

        ChangedSinceLastFrame = true;

    }

}
