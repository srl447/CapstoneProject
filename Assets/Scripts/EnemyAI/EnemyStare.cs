﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStare : MonoBehaviour {

    public float stareTime;
    public bool stare = false;
    Vector3 origin;
    public GameObject player;
    public GameObject shopper;
    public EnemyMove eM;
    public EnemyRotation eR;

    public GameObject point;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (stare)
        {
            //Makes the enemy face the player
            Vector3 dir = player.transform.position - shopper.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
            shopper.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }
        
	}

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CollisionOccurence();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //once the player leaves, they stare for a bit longer
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(StareWait(stareTime));
        }
    }

    public void CollisionOccurence()
    {
        origin = shopper.transform.eulerAngles;
        //turns off coroutines
        if (eR != null)
        {
            eR.enabled = false;
        }
        if (eM != null)
        {
            eM.enabled = false;
        }
        if(!stare)
        {
            GameObject newPoint = Instantiate(point) as GameObject;
            newPoint.transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y + .8f, transform.parent.position.z);
        }
        stare = true;
    }
    public IEnumerator StareWait(float timer)
    {
        yield return new WaitForSecondsRealtime(timer);
        //stop coroutines
        stare = false;
        for(int i = 0; i <= 6; i++)
        {
            shopper.transform.eulerAngles = Vector3.Slerp(shopper.transform.eulerAngles, origin, .25f);
            yield return new WaitForEndOfFrame();
        }
        shopper.transform.eulerAngles = origin;
        if (eR)
        {
            eR.enabled = true;
        }
        if (eM)
        {
            eM.enabled = true;
        }
    }
}
