using System.Collections;
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