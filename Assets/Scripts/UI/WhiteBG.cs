using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhiteBG : MonoBehaviour {

    public GameObject whiteBox;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(this.GetComponent<Text>().text == "")
        {
            whiteBox.GetComponent<Image>().enabled = false;
        }
        else
        {
            whiteBox.GetComponent<Image>().enabled = true;
        }
		
	}
}
