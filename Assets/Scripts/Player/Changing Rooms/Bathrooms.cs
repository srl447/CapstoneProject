using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bathrooms : MonoBehaviour {
    public bool start;
    public Image fade;
    public Text text;

    public AudioClip[] lines;
    public AudioSource aud;
    bool[] played = new bool[3];
    int timer = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (start)
        {
            if (fade.color.a < 1)
            {
                fade.color = new Color(0, 0, 0, fade.color.a * 2);
            }
            if (timer <= 220)
            {
                text.text = "As much as I have to go to the bathroom, I cant.";
                if (!played[0])
                {
                    aud.PlayOneShot(lines[0]);
                    played[0] = true;
                }
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
                text.text = "What would people think of me?";
                if (!played[1])
                {
                    aud.PlayOneShot(lines[1]);
                    played[1] = true;
                }
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
                text.text = "I don't wanna make anyone uncomfortable, so I can just never go";
                if (!played[2])
                {
                    aud.PlayOneShot(lines[2]);
                    played[2] = true;
                }
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
        if (collision.gameObject.tag == "Player")
        {
            //StartCoroutine(CutScene());
            start = true;
            fade.color = new Color(0, 0, 0, .1f);
            Time.timeScale = 0;
        }
    }

}
