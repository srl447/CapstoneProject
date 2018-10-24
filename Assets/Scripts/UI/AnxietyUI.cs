using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PostProcessing;

public class AnxietyUI : MonoBehaviour {

    public float bloomSpeed;
    public float chromeSpeed;
    public float vigSpeed;
    public float extravig;

    public Text anxietyText;
    public Transform player;
    public GetSpotted gS;
    public PostProcessingProfile mainProfile;

    bool flicker = false;
    float flickerAmount = 0;

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
        vigS.intensity = 0.5f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //vigS.center = player.position; //Need to convert world space to canvas space
        //Basically, this just increases several post processing effects intensities, bloom
        //vingette, and chromatic abberation, as anxiety rises.
        if (vigS.intensity < 3.5f)
        {
            vigS.intensity = (gS.anx * vigSpeed) + extravig + .5f + flickerAmount;
        }
        else
        {
            vigS.intensity = 3.5f + flickerAmount;
        }
        bloomS.bloom.intensity = gS.anx * bloomSpeed + flickerAmount;
        chromeS.intensity = gS.anx * chromeSpeed + flickerAmount;
        mainProfile.vignette.settings = vigS;
        mainProfile.chromaticAberration.settings = chromeS;
        mainProfile.bloom.settings = bloomS;
        anxietyText.text = "Anxiety: " + Mathf.Floor(gS.anx*100);
        if(gS.anx > 1.3 && !flicker)
        {
            StartCoroutine(flickering());
            flicker = true;
            Debug.Log(flicker);
        }
	}

    IEnumerator flickering()
    {
        yield return new WaitForEndOfFrame();
        float randomAmount = Random.Range(-.08f, .08f);
        float randomSpeed = Random.Range(.3f, .8f);
        int counter = 0;
        for(;flickerAmount != randomAmount;)
        {
            flickerAmount = Mathf.Lerp(flickerAmount, randomAmount, randomSpeed);
            yield return new WaitForEndOfFrame();
            counter++;
            if(counter > 9)
            {
                flickerAmount = randomAmount;
            }
            Debug.Log(flickerAmount);
            //if(flickerAmount +.05f > randomAmount || flickerAmount -.05f < randomAmount)
        }
        Debug.Log("finished");
        StartCoroutine(flickering());
    }
}
