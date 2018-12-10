﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterThoughts3 : MonoBehaviour
{

    public Text cash;
    public Text player;
    bool introDone = false;
    public bool end = false;
    bool endRun = false;
    public bool fin = false;
    public Image head;
    public Sprite headSprite;

    public RectTransform loc;

    void Awake()
    {
        if (this.enabled)
        {
            StartCoroutine(Conversation());
            head.sprite = headSprite;
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
        cash.text = "Hey There!";
        player.text = "";
        yield return new WaitForSecondsRealtime(2);
        player.text = "      hi";
        cash.text = "";
        yield return new WaitForSecondsRealtime(1);
        player.text = "";
        cash.text = "Hope everything went well";
        yield return new WaitForSecondsRealtime(3);
        cash.text = "";
        player.text = "...it did";
        yield return new WaitForSecondsRealtime(1);
        player.text = "";
        cash.text = "Is that for you? You'll look great in it!";
        yield return new WaitForSecondsRealtime(3);
        player.text = "aww thanks";
        cash.text = "";
        yield return new WaitForSecondsRealtime(1);
        player.text = "";
        introDone = true;
    }

    IEnumerator endConvo()
    {
        yield return new WaitForEndOfFrame();
        cash.text = "Will you pay with cash or card?";
        yield return new WaitForSecondsRealtime(2);
        cash.text = "";
        player.text = "card";
        yield return new WaitForSecondsRealtime(1f);
        player.text = "";
        yield return new WaitForSecondsRealtime(4f);
        cash.text = "Here ya go, have a great day!";
        yield return new WaitForSecondsRealtime(2f);
        fin = true;

    }

}