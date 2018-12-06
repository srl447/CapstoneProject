using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {

    public AudioClip boop;
    public AudioSource aud;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        aud.PlayOneShot(boop);
        Application.Quit();
		
	}
}
