using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnxietyUI : MonoBehaviour {

    public Text anxietyText;
    public GetSpotted gS;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(gS.anx);
        anxietyText.text = "Anxiety: " + Mathf.Floor(gS.anx*100);
	}
}
