using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Losing : MonoBehaviour {


    public Image fade;
    public Text text;

    int timer = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(GameManager.anxiety > 1.6f)
        {
            GetComponent<ThoughtText>().enabled = false;
            if (fade.color.a < 1)
            {
                fade.color = new Color(0, 0, 0, fade.color.a+.01f * 2);
            }
            if (timer <= 220)
            {
                text.text = "I think I have to give up";
                if (text.color.a < 1)
                    text.color = new Color(255, 255, 255, (text.color.a + .05f) * 2);
                timer++;
            }
            else if (timer <= 240)
            {
                text.color = new Color(255, 255, 255, (text.color.a) / 2);
                timer++;
            }
            else if (timer <= 540)
            {
                text.text = "There's always tomorrow";
                if (text.color.a < 1)
                    text.color = new Color(255, 255, 255, (text.color.a + .05f) * 2);
                timer++;
            }
            else if (timer <= 560)
            {
                text.color = new Color(255, 255, 255, (text.color.a) / 2);
                timer++;
            }
            else if (timer <= 720)
            {
                text.text = "I'll just drop the clothes, and try again later";
                if (text.color.a < 1)
                    text.color = new Color(255, 255, 255, (text.color.a + .05f) * 2);
                timer++;
            }
            else if (timer <= 740)
            {
                text.color = new Color(255, 255, 255, (text.color.a) / 2);
                timer++;
            }
            else if (timer < 900)
            {
                SceneManager.LoadScene(0);
            }
        }
		
	}
}
