﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterThoughts2 : MonoBehaviour
{

    public Text cash;
    public Text player;
    bool introDone = false;
    public bool end = false;
    bool endRun = false;
    public bool fin = false;

    void Awake()
    {
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
        cash.text = "Hello, do you have a store card with us";
        player.text = "";
        yield return new WaitForSecondsRealtime(4);
        player.text = "      no";
        cash.text = "";
        yield return new WaitForSecondsRealtime(1);
        player.text = "";
        cash.text = "Oh are these for your girlfriend?";
        yield return new WaitForSecondsRealtime(5);
        cash.text = "";
        player.text = "yeah sure";
        yield return new WaitForSecondsRealtime(1);
        player.text = "";
        cash.text = "Oh good I wouldn't want you to be with one of those creeps who wears women's clothes";
        yield return new WaitForSecondsRealtime(2);
        cash.text = "";
        player.text = "haha yea";
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