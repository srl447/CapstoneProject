using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

    public AudioClip boop;
    public AudioSource aud;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        aud.PlayOneShot(boop);
        SceneManager.LoadScene(2);
		
	}
}
