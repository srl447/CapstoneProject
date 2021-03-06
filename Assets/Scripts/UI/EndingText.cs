﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingText : MonoBehaviour {

    string[] words = {"I wish I could wear these clothes.", "The world's a scary place.", "But I love these clothes", "Because they are mine!" };
    public AudioClip[] lines;
    public GameObject[] credits;
    public Text final;
    public int wordIndex = 0;

    AudioSource aud;
    // Use this for initialization
    void Start ()
    {
        aud = this.GetComponent<AudioSource>();
        final.text = words[0];
        StartCoroutine(TextFades());
        GameManager.clothes = new ArrayList();
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
		
	}

    IEnumerator TextFades()
    {
        aud.PlayOneShot(lines[wordIndex]);
        yield return new WaitForSecondsRealtime(2);
        for(int i = 0; i < 10; i++)
        { 
            final.color = new Color(final.color.r, final.color.g, final.color.b, final.color.a - .2f);
            yield return new WaitForEndOfFrame();
        }
        final.color = new Color(final.color.r, final.color.g, final.color.b, 0);
        yield return new WaitForEndOfFrame();
        wordIndex++;
        if (wordIndex == words.Length)
        {
            yield return new WaitForSecondsRealtime(.3f);
            GameManager.clothes = new ArrayList();
            StartCoroutine(Credits());
        }
        else
        {
            final.text = words[wordIndex];
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            for (int i = 0; i < 8; i++)
            {
                final.color = new Color(final.color.r, final.color.g, final.color.b, final.color.a + .22f);
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForEndOfFrame();
            StartCoroutine(TextFades());
        }
    }

    IEnumerator Credits()
    {
        yield return new WaitForEndOfFrame();
        for (; credits[0].GetComponent<Image>().color.a < 1;)
        {
            credits[0].GetComponent<Image>().color += new Color(0f, 0f, 0f, .22f);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSecondsRealtime(3.5f);
        for (; credits[0].GetComponent<Image>().color.a > 0;)
        {
            credits[0].GetComponent<Image>().color -= new Color(0f, 0f, 0f, .22f);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSecondsRealtime(.6f);
        for (; credits[1].GetComponent<Image>().color.a < 1;)
        {
            credits[1].GetComponent<Image>().color += new Color(0f, 0f, 0f, .22f);
            credits[2].GetComponent<Text>().color += new Color(0f, 0f, 0f, .22f);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSecondsRealtime(3f);
        for (; credits[1].GetComponent<Image>().color.a > 0;)
        {
            credits[1].GetComponent<Image>().color -= new Color(0f, 0f, 0f, .22f);
            credits[2].GetComponent<Text>().color -= new Color(0f, 0f, 0f, .22f);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSecondsRealtime(.6f);
        for (; credits[3].GetComponent<Image>().color.a < 1;)
        {
            credits[3].GetComponent<Image>().color += new Color(0f, 0f, 0f, .22f);
            credits[4].GetComponent<Text>().color += new Color(0f, 0f, 0f, .22f);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSecondsRealtime(3f);
        for (; credits[3].GetComponent<Image>().color.a > 0;)
        {
            credits[3].GetComponent<Image>().color -= new Color(0f, 0f, 0f, .22f);
            credits[4].GetComponent<Text>().color -= new Color(0f, 0f, 0f, .22f);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSecondsRealtime(.6f);
        for (; credits[5].GetComponent<Image>().color.a < 1;)
        {
            credits[5].GetComponent<Image>().color += new Color(0f, 0f, 0f, .22f);
            credits[6].GetComponent<Text>().color += new Color(0f, 0f, 0f, .22f);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSecondsRealtime(3f);
        for (; credits[5].GetComponent<Image>().color.a > 0;)
        {
            credits[5].GetComponent<Image>().color -= new Color(0f, 0f, 0f, .22f);
            credits[6].GetComponent<Text>().color -= new Color(0f, 0f, 0f, .22f);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSecondsRealtime(.6f);
        for (; credits[7].GetComponent<Image>().color.a < 1;)
        {
            credits[7].GetComponent<Image>().color += new Color(0f, 0f, 0f, .22f);
            credits[9].GetComponent<Image>().color += new Color(0f, 0f, 0f, .22f);
            credits[8].GetComponent<Text>().color += new Color(0f, 0f, 0f, .22f);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSecondsRealtime(3f);
        for (; credits[7].GetComponent<Image>().color.a > 0;)
        {
            credits[7].GetComponent<Image>().color -= new Color(0f, 0f, 0f, .22f);
            credits[9].GetComponent<Image>().color -= new Color(0f, 0f, 0f, .22f);
            credits[8].GetComponent<Text>().color -= new Color(0f, 0f, 0f, .22f);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSecondsRealtime(.6f);
        for (; credits[17].GetComponent<Image>().color.a < 1;)
        {
            credits[17].GetComponent<Image>().color += new Color(0f, 0f, 0f, .22f);
            credits[16].GetComponent<Text>().color += new Color(0f, 0f, 0f, .22f);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSecondsRealtime(3f);
        for (; credits[17].GetComponent<Image>().color.a > 0;)
        {
            credits[17].GetComponent<Image>().color -= new Color(0f, 0f, 0f, .22f);
            credits[16].GetComponent<Text>().color -= new Color(0f, 0f, 0f, .22f);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSecondsRealtime(.6f);
        for (; credits[10].GetComponent<Image>().color.a < 1;)
        {
            credits[10].GetComponent<Image>().color += new Color(0f, 0f, 0f, .22f);
            credits[11].GetComponent<Text>().color += new Color(0f, 0f, 0f, .22f);
            credits[12].GetComponent<Text>().color += new Color(0f, 0f, 0f, .22f);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSecondsRealtime(3f);
        for (; credits[10].GetComponent<Image>().color.a > 0;)
        {
            credits[10].GetComponent<Image>().color -= new Color(0f, 0f, 0f, .22f);
            credits[11].GetComponent<Text>().color -= new Color(0f, 0f, 0f, .22f);
            credits[12].GetComponent<Text>().color -= new Color(0f, 0f, 0f, .22f);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSecondsRealtime(.6f);
        for (; credits[13].GetComponent<Image>().color.a < 1;)
        {
            credits[13].GetComponent<Image>().color += new Color(0f, 0f, 0f, .22f);
            credits[14].GetComponent<Image>().color += new Color(0f, 0f, 0f, .22f);
            credits[15].GetComponent<Text>().color += new Color(0f, 0f, 0f, .22f);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSecondsRealtime(5f);
        for (; credits[13].GetComponent<Image>().color.a > 0;)
        {
            credits[13].GetComponent<Image>().color -= new Color(0f, 0f, 0f, .22f);
            credits[14].GetComponent<Image>().color -= new Color(0f, 0f, 0f, .22f);
            credits[15].GetComponent<Text>().color -= new Color(0f, 0f, 0f, .22f);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSecondsRealtime(.2f);
        SceneManager.LoadScene(0);

    }
}
