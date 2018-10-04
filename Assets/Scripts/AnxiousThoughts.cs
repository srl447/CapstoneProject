using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnxiousThoughts : MonoBehaviour {

    public GetSpotted gS;
    public Text text;
    public bool[] thoughts = new bool[1];
	// Use this for initialization
	void Start ()
    {
		for(int i = 0; i < thoughts.Length; i++)
        {
            thoughts[i] = false;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(gS.anx >0 && !GameManager.thinking && !thoughts[0])
        {
            text.text = "I can't let anyone see me";
            StartCoroutine(thoughtTime(2));
            thoughts[0] = true;

        }
		
	}

    IEnumerator thoughtTime(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        text.text = "";
        GameManager.thinking = false;
    }
}
