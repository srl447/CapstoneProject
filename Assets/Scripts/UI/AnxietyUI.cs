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


    float heartbeat = 0;
    public AudioClip heartSound;
    public AudioSource aud;

    //To edit Post Processing effects through code
    //you need to have setting variables that you edit
    //for each component you want to change
    BloomModel.Settings bloomS;
    ChromaticAberrationModel.Settings chromeS;
    VignetteModel.Settings vigS;
    GrainModel.Settings grainS;

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
        StartCoroutine(heartbeatChange());
        grainS = mainProfile.grain.settings;
        grainS.intensity = 0;
        mainProfile.grain.settings = grainS;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // vigS.center = player.position; //Need to convert world space to canvas space
        //Basically, this just increases several post processing effects intensities, bloom
        //vingette, and chromatic abberation, as anxiety rises.
       if (vigS.intensity < 3.5f)
        {
            vigS.intensity = (gS.anx * vigSpeed) + extravig + .5f + heartbeat;
        }
        else
        {
            vigS.intensity = 3.5f + +heartbeat;
        }
        bloomS.bloom.intensity = gS.anx * bloomSpeed + heartbeat;
        chromeS.intensity = gS.anx * chromeSpeed + heartbeat;
        mainProfile.vignette.settings = vigS;
        mainProfile.chromaticAberration.settings = chromeS;
        mainProfile.bloom.settings = bloomS;
       // anxietyText.text = "Anxiety: " + Mathf.Floor(gS.anx*100);
        if(GameManager.anxiety > 1.2)
        {
            grainS.intensity = (GameManager.anxiety - 1.2f)*2;
            mainProfile.grain.settings = grainS;
        }
        /*if(gS.anx > 1.3 && !flicker)
        {
            StartCoroutine(flickering());
            flicker = true;
            Debug.Log(flicker);
        }
        sinWave += .001f;*/
	}

    IEnumerator heartbeatChange()
    {
        yield return new WaitForSecondsRealtime(GameManager.anxiety < 1.8f ? 1.9f - GameManager.anxiety : .1f);
        aud.PlayOneShot(heartSound, 1f + GameManager.anxiety);
        yield return new WaitForEndOfFrame();
        for(;heartbeat < .03f;)
        {
            heartbeat = Mathf.Lerp(heartbeat, .03f, .2f + GameManager.anxiety / 2);
            yield return new WaitForEndOfFrame();
            if(heartbeat > .028f)
            {
                heartbeat = .03f;
            }
        }
        yield return new WaitForEndOfFrame();
        for (; heartbeat >0;)
        {
            heartbeat = Mathf.Lerp(heartbeat, 0, 1f + GameManager.anxiety / 2);
            yield return new WaitForEndOfFrame();
            if (heartbeat < .002f)
            {
                heartbeat = 0;
            }
        }
        yield return new WaitForSecondsRealtime((GameManager.anxiety < 1.8f ? (1.9f - GameManager.anxiety) / 10 : .01f));
        aud.PlayOneShot(heartSound, .7f + GameManager.anxiety);
        yield return new WaitForEndOfFrame();
        for (; heartbeat < .03f;)
        {
            heartbeat = Mathf.Lerp(heartbeat,.03f, .2f + GameManager.anxiety / 2);
            yield return new WaitForEndOfFrame();
            if (heartbeat > .028f)
            {
                heartbeat = .03f;
            }
        }
        yield return new WaitForEndOfFrame();
        for (; heartbeat > 0;)
        {
            heartbeat = Mathf.Lerp(heartbeat, 0, .1f + GameManager.anxiety / 2);
            yield return new WaitForEndOfFrame();
            if (heartbeat < .002f)
            {
                heartbeat = 0;
            }
        }
        StartCoroutine(heartbeatChange());
    }
}
