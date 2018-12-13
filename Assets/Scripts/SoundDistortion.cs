using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDistortion : MonoBehaviour {

    AudioDistortionFilter aDF;
    AudioLowPassFilter aLPF;
    AudioSource aud;
	// Use this for initialization
	void Start () {
        aDF = this.GetComponent<AudioDistortionFilter>();
        aLPF = this.GetComponent<AudioLowPassFilter>();
        aud = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
       /* if (aDF.distortionLevel < .6f)
        {
            aDF.distortionLevel = GameManager.anxiety;
        }*/
        aLPF.cutoffFrequency = 4000 - (3200 * GameManager.anxiety);
        aud.volume = .5f - GameManager.anxiety / 3f;
		
	}
}
