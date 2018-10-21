using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingPicture : MonoBehaviour {

    string screenShotName;
    //string filepath = "/Capstone/Assets/Sprites/Screenshots";
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("works");
            screenShotName = "finalPic" + Mathf.Floor(Random.Range(0, 9999999)) + ".png";
            ScreenCapture.CaptureScreenshot(screenShotName);
        }
		
	}
}
