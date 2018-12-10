using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.UI;

public class ChangingRooms : MonoBehaviour {

    public bool start;
    public Image fade;
    public Text text;

    public AudioClip[] lines;
    bool[] played = new bool[3];
    AudioSource aud;

    int timer = 0;
	// Use this for initialization
	void Start () {
        aud = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        if(start)
        {
            if (fade.color.a < 1)
            {
                fade.color = new Color(0, 0, 0, fade.color.a * 2);
            }
            if (timer <= 200)
            {
                text.text = "Why did I think I could do that?";
                if (!played[0])
                {
                    aud.PlayOneShot(lines[0]);
                    played[0] = true;
                }
                if (text.color.a < 1)
                    text.color = new Color(255, 255, 255, (text.color.a + .05f) * 2);
                timer++;
            }
            else if (timer <= 220)
            {
                text.color = new Color(255, 255, 255, (text.color.a) / 2);
                timer++;
            }
            else if (timer <= 470)
            {
                text.text = "What changing room would I even use?";
                if (!played[1])
                {
                    aud.PlayOneShot(lines[1]);
                    played[1] = true;
                }
                if (text.color.a < 1)
                    text.color = new Color(255, 255, 255, (text.color.a + .05f) * 2);
                timer++;
            }
            else if (timer <= 490)
            {
                text.color = new Color(255, 255, 255, (text.color.a) / 2);
                timer++;
            }
            else if (timer <= 740)
            {
                text.text = "I'm gonna get thrown out if I try to use the girls, but I'll die if I use the guys.";
                if (!played[2])
                {
                    aud.PlayOneShot(lines[2]);
                    played[2] = true;
                }
                if (text.color.a < 1)
                    text.color = new Color(255, 255, 255, (text.color.a + .05f) * 2);
                timer++;
            }
            else if (timer <= 760)
            {
                text.color = new Color(255, 255, 255, (text.color.a) / 2);
                timer++;
            }
            else if (timer < 800)
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
            start = true;
            fade.color = new Color(0, 0, 0, .1f);
            Time.timeScale = 0;
        }
    }
}
