using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PostProcessing;

public class AnxietyUI : MonoBehaviour {

    public float bloomSpeed;
    public float chromeSpeed;
    public float vigSpeed;

    public Text anxietyText;
    public Transform player;
    public GetSpotted gS;
    public PostProcessingProfile mainProfile;

    //To edit Post Processing effects through code
    //you need to have setting variables that you edit
    //for each component you want to change
    BloomModel.Settings bloomS;
    ChromaticAberrationModel.Settings chromeS;
    VignetteModel.Settings vigS;

    // Use this for initialization
    void Start ()
    {
        //Always assign the default settings so other 
        //things you don't want to change aren't reset
        bloomS = mainProfile.bloom.settings;
        bloomS.bloom.intensity = 0;
        chromeS = mainProfile.chromaticAberration.settings;
        chromeS.intensity = 0;
        vigS = mainProfile.vignette.settings;
        vigS.intensity = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //vigS.center = player.position; //Need to convert world space to canvas space
        //Basically, this just increases several post processing effects intensities, bloom
        //vingette, and chromatic abberation, as anxiety rises.
        vigS.intensity = gS.anx * vigSpeed;
        bloomS.bloom.intensity = gS.anx * bloomSpeed;
        chromeS.intensity = gS.anx * chromeSpeed;
        mainProfile.vignette.settings = vigS;
        mainProfile.chromaticAberration.settings = chromeS;
        mainProfile.bloom.settings = bloomS;
        anxietyText.text = "Anxiety: " + Mathf.Floor(gS.anx*100);
	}
}
