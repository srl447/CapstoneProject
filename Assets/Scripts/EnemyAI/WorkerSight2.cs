﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerSight2 : MonoBehaviour {

    public GameObject topUI;
    public Text helpText;
    public ThoughtText tT;
    public Workers work;

    bool canTalk = true;
    bool talking;

    public Image head;
    public Sprite headSprite;


    //GameObject player;
    //Vector3 pos;

    public RectTransform loc;
    public AudioClip[] tessLines, workLines;
    AudioSource aud;
    // Use this for initialization
    void Awake()
    {
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(talking)
        {
            player.transform.position = pos;
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && canTalk && GameManager.anxiety <= 1.55f && !collision.gameObject.GetComponent<PickupClothes>().purchased)
        {
            collision.gameObject.GetComponent<Movement>().up = false;
            collision.gameObject.GetComponent<Movement>().left = false;
            collision.gameObject.GetComponent<Movement>().down = false;
            collision.gameObject.GetComponent<Movement>().right = false;
            collision.gameObject.GetComponent<Movement>().walking = false;
            collision.gameObject.GetComponent<Movement>().enabled = false;
            collision.gameObject.GetComponent<PickupClothes>().enabled = false;
            topUI.SetActive(true);
            work.enabled = false;
            StartCoroutine(Convo(collision.gameObject));
            //player = collision.gameObject;
            //pos = player.transform.position;
            canTalk = false;
            talking = true;
        }
    }

    IEnumerator Convo(GameObject player)
    {
        head.sprite = headSprite;
        Vector3 oldPos = topUI.GetComponent<RectTransform>().position;
        for (int i = 0; i < 8; i++)
        {
            yield return new WaitForEndOfFrame();
            topUI.GetComponent<RectTransform>().position = new Vector3(topUI.GetComponent<RectTransform>().position.x, Mathf.Lerp(topUI.GetComponent<RectTransform>().position.y, loc.position.y, .1f), topUI.GetComponent<RectTransform>().position.z);

        }
        for (; tT.current.nextNode != null;)
        {
            yield return new WaitForEndOfFrame();
        }
        if (tT.thought.text != "")
        {
            yield return new WaitForSecondsRealtime(tT.current.thoughtTime);
        }
        tT.add(new Node(" ", 2f));
        tT.add(new Node("just looking", 1.4f, tessLines[0]));
        tT.add(new Node(" ", 3));
        tT.add(new Node("thank you...", 1, tessLines[1]));
        tT.add(new Node(" ", 2));
        yield return new WaitForEndOfFrame();
        Vector3 dir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
        transform.parent.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        helpText.text = "Excuse me Mister, are you looking for the men's section?";
        aud.PlayOneShot(workLines[0]);
        yield return new WaitForSecondsRealtime(2);
        helpText.text = "";
        yield return new WaitForSecondsRealtime(1.4f);
        helpText.text = "Oh the bathrooms and fitting rooms are in the back";
        aud.PlayOneShot(workLines[1]);
        yield return new WaitForSecondsRealtime(2);
        helpText.text = "";
        yield return new WaitForSecondsRealtime(1);
        helpText.text = "No problem sir, anything for our customers.";
        aud.PlayOneShot(workLines[2]);
        yield return new WaitForSecondsRealtime(1.5f);
        for (int i = 0; i < 8; i++)
        {
            yield return new WaitForEndOfFrame();
            topUI.GetComponent<RectTransform>().position = new Vector3(topUI.GetComponent<RectTransform>().position.x, Mathf.Lerp(topUI.GetComponent<RectTransform>().position.y, oldPos.y, .1f), topUI.GetComponent<RectTransform>().position.z);

        }
        player.GetComponent<Movement>().enabled = true;
        player.GetComponent<PickupClothes>().enabled = true;
        topUI.SetActive(false);
        work.enabled = true;
        talking = false;

        yield return new WaitForSecondsRealtime(3);
        canTalk = true;
    }
}
