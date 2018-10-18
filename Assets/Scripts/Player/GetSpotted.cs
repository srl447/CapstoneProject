using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class GetSpotted : MonoBehaviour {

    SpriteRenderer sR;
    public float enemyPow, cashPow;
    public float aZ1Pow;
    public float anx;
    public AnxietyUI aUI;
	// Use this for initialization
	void Start ()
    {
        sR = GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void Update ()
    {
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemySight" || collision.gameObject.tag == "AnxietyZone1")
        {
           // ScreenShake.shakeStrength = 2f;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //now this just tracks anxiety
        if (collision.gameObject.tag == "EnemySight")
        { 
            anx += enemyPow;
        }
        if (collision.gameObject.tag == "AnxietyZone1")
        { 
            anx += aZ1Pow;
            aUI.extravig = Mathf.Lerp(aUI.extravig,.1f,.3f);
        }
        if(collision.gameObject.tag == "CashSight")
        {
            anx += cashPow;
            aUI.extravig = Mathf.Lerp(aUI.extravig, -.1f, .3f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AnxietyZone1")
        {
            StartCoroutine(LerpBack());
        }
    }

    IEnumerator LerpBack()
    {
        for(;aUI.extravig > .05;)
        {
            yield return new WaitForEndOfFrame();
            aUI.extravig = Mathf.Lerp(aUI.extravig, 0, .2f);
        }
    }
}
