using System.Collections;
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
    public Image head;
    public Sprite headSprite;

    public RectTransform loc;

    public AudioClip[] lines;
    AudioSource aud;

    void Awake()
    {
        aud = GetComponent<AudioSource>();
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
        cash.text = "Hello, do you have a store card with us";
        aud.PlayOneShot(lines[0]);
        player.text = "";
        yield return new WaitForSecondsRealtime(4);
        player.text = "      no";
        aud.PlayOneShot(lines[1]);
        cash.text = "";
        yield return new WaitForSecondsRealtime(1);
        player.text = "";
        cash.text = "Oh are these for your girlfriend?";
        aud.PlayOneShot(lines[2]);
        yield return new WaitForSecondsRealtime(5);
        cash.text = "";
        player.text = "yeah sure";
        aud.PlayOneShot(lines[3]);
        yield return new WaitForSecondsRealtime(1);
        player.text = "";
        cash.text = "Oh good I hate those creeps who wears women's clothes";
        aud.PlayOneShot(lines[4]);
        yield return new WaitForSecondsRealtime(2);
        cash.text = "";
        player.text = "haha yea";
        aud.PlayOneShot(lines[5]);
        yield return new WaitForSecondsRealtime(1);
        player.text = "";
        introDone = true;
    }

    IEnumerator endConvo()
    {
        yield return new WaitForEndOfFrame();
        cash.text = "Will that be cash or card?";
        aud.PlayOneShot(lines[6]);
        yield return new WaitForSecondsRealtime(2);
        cash.text = "";
        player.text = "card";
        aud.PlayOneShot(lines[7]);
        yield return new WaitForSecondsRealtime(1f);
        player.text = "";
        yield return new WaitForSecondsRealtime(4f);
        cash.text = "Here's your stuff";
        aud.PlayOneShot(lines[8]);
        yield return new WaitForSecondsRealtime(2f);
        fin = true;

    }

}