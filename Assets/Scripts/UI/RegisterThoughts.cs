using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterThoughts : MonoBehaviour {

    public Text text;
    private void Start()
    { 
    }
    // Use this for initialization
    void Awake () {

	}

    IEnumerator Conversation()
    {
        yield return new WaitForEndOfFrame();
        text.text = "Hello";
    }
	
}
