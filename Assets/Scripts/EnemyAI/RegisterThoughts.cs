using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterThoughts : MonoBehaviour {

    public Text cash;
    public Text player;
    bool introDone = false;
    public bool end = false;
    bool endRun = false;
    public bool fin = false;

    public AudioClip[] lines;
    public AudioSource aud;

    public RectTransform loc;

    void Awake () {
        if (this.enabled)
        {
            StartCoroutine(Conversation());
        }
	}

    private void Update()
    {
        if (end && !endRun && introDone)
        {
            StartCoroutine(endConvo());
            endRun = true;
        }
    }
    IEnumerator Conversation()
    {
        Vector3 oldPos = GetComponent<RectTransform>().position;
        for (int i = 0; i < 8; i++)
        {
            yield return new WaitForEndOfFrame();
            GetComponent<RectTransform>().position = new Vector3(GetComponent<RectTransform>().position.x, Mathf.Lerp(GetComponent<RectTransform>().position.y, loc.position.y, .1f), GetComponent<RectTransform>().position.z);
        }
        yield return new WaitForEndOfFrame();
        cash.text = "Good Evening";
        aud.PlayOneShot(lines[0]);
        player.text = " ";
        yield return new WaitForSecondsRealtime(3);
        player.text = "      hi";
        aud.PlayOneShot(lines[2]);
        cash.text = " ";
        yield return new WaitForSecondsRealtime(1);
        player.text = "";
        cash.text = "Did you find everything alright?";
        aud.PlayOneShot(lines[3]);
        yield return new WaitForSecondsRealtime(3);
        cash.text = " ";
        player.text = "...";
        yield return new WaitForSecondsRealtime(1);
        player.text = " ";
        introDone = true;
    }

    IEnumerator endConvo()
    {
        yield return new WaitForEndOfFrame();
        cash.text = "Will that be cash or card?";
        aud.PlayOneShot(lines[4]);
        yield return new WaitForSecondsRealtime(2);
        cash.text = "";
        player.text = "card";
        aud.PlayOneShot(lines[5]);
        yield return new WaitForSecondsRealtime(1f);
        player.text = "";
        yield return new WaitForSecondsRealtime(4f);
        cash.text = "Here you go, have a great day!";
        aud.PlayOneShot(lines[6]);
        yield return new WaitForSecondsRealtime(2f);
        fin = true;

    }
	
}
