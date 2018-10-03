using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PostProcessing;

public class AnxietyUI : MonoBehaviour {

    public float bloomSpeed;
    public float chromeSpeed;

    public Text anxietyText;
    public GetSpotted gS;
    public PostProcessingProfile mainProfile;

    BloomModel.Settings bloomS;
    ChromaticAberrationModel.Settings chromeS;
    // Use this for initialization
    void Start ()
    {
        bloomS = mainProfile.bloom.settings;
        bloomS.bloom.intensity = 0;
        chromeS = mainProfile.chromaticAberration.settings;
        chromeS.intensity = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        bloomS.bloom.intensity = gS.anx*bloomSpeed;
        chromeS.intensity = gS.anx * chromeSpeed;
        mainProfile.chromaticAberration.settings = chromeS;
        mainProfile.bloom.settings = bloomS;
        anxietyText.text = "Anxiety: " + Mathf.Floor(gS.anx*100);
	}
}
