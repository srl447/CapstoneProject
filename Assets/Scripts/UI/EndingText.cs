using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingText : MonoBehaviour {

    string[] words = {"I can't wear these clothes.", "The world's a scary place.", "But I love these clothes", "Because they are mine!" };
    public Text final;
    public int wordIndex = 0;
    // Use this for initialization
    void Start ()
    {
        final.text = words[0];
        StartCoroutine(TextFades());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator TextFades()
    {
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
            yield return new WaitForSecondsRealtime(1f);
            SceneManager.LoadScene(2);
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
}
