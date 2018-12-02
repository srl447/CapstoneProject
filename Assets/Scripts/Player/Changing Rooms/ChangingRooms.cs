using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.UI;

public class ChangingRooms : MonoBehaviour {

    public bool start;
    public Image fade;
    public Text text;

    int timer = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(start)
        {
            if (fade.color.a < 1)
            {
                fade.color = new Color(0, 0, 0, fade.color.a * 2);
            }
            if (timer <= 220)
            {
                text.text = "Why did I think I could do that?";
                if(text.color.a < 1)
                    text.color = new Color(255, 255, 255, (text.color.a+.05f) * 2);
                timer++;
            }
            else if (timer <= 240)
            {
                text.color = new Color(255, 255, 255, (text.color.a)/2);
                timer++;
            }
            else if (timer <= 540)
            {
                text.text = "What changing room would I even use?";
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
                text.text = "I'm gonna get thrown out if I try to use the girls, but I'll die if I use the guys.";
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
                fade.color = Color.clear;
                Time.timeScale = 1;
                text.color = Color.clear;
                start = false;
            }
        }
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //StartCoroutine(CutScene());
            start = true;
            fade.color = new Color(0, 0, 0, .1f);
            Time.timeScale = 0;
        }
    }

    /*IEnumerator CutScene()
    {
      
    }*/
}
