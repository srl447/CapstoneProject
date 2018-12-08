using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Glow : MonoBehaviour {

    float anxLastFrame;

    Image glow;
    public Image bar;
	// Use this for initialization
	void Start () {
        glow = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        glow.GetComponent<RectTransform>().sizeDelta = bar.GetComponent<RectTransform>().sizeDelta;
        if(anxLastFrame < GameManager.anxiety)
        {
            if (glow.color.a < 1)
                glow.color += new Color(0f,0f,0f,.2f);
        }
        else
        {
            if (glow.color.a > 0)
                glow.color -= new Color(0f, 0f, 0f, .2f);
        }
        anxLastFrame = GameManager.anxiety;
    }
		
}
