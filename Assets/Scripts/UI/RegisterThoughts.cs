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
        yield return new WaitForEndOfFrame();
        cash.text = "Good Evening";
        player.text = "";
        yield return new WaitForSecondsRealtime(4);
        player.text = "      hi";
        cash.text = "";
        yield return new WaitForSecondsRealtime(1);
        player.text = "";
        cash.text = "Did you find everything alright?";
        yield return new WaitForSecondsRealtime(5);
        cash.text = "";
        player.text = "...";
        yield return new WaitForSecondsRealtime(1);
        player.text = "";
        introDone = true;
    }

    IEnumerator endConvo()
    {
        yield return new WaitForEndOfFrame();
        cash.text = "Will that be cash or card?";
        yield return new WaitForSecondsRealtime(2);
        cash.text = "";
        player.text = "card";
        yield return new WaitForSecondsRealtime(1f);
        player.text = "";
        yield return new WaitForSecondsRealtime(4f);
        cash.text = "Here you go, have a nice day!";
        yield return new WaitForSecondsRealtime(2f);
        fin = true;

    }
	
}
