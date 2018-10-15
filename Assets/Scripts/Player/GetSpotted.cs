using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class GetSpotted : MonoBehaviour {

    SpriteRenderer sR;
    public float enemyPow;
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
        //All of this was prototype anxiety display method
		//if(sR.color.r <= 0)
        //{
            //Debug.Log("Max Blue");
        //}
        //anx = Mathf.Ceil((255 - sR.color.r)*(100/255));
        //Debug.Log(anx);
        //GameManager.anxiety = anx;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemySight" || collision.gameObject.tag == "AnxietyZone1")
        {
            ScreenShake.shakeStrength = 2f;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //now this just tracks anxiety
        if (collision.gameObject.tag == "EnemySight")
        {
            //sR.color = new Color(sR.color.r - enemyPow , sR.color.g - enemyPow ,sR.color.b);
            anx += enemyPow;
        }
        if (collision.gameObject.tag == "AnxietyZone1")
        {
            //sR.color = new Color(sR.color.r - aZ1Pow, sR.color.g - aZ1Pow, sR.color.b);
            anx += aZ1Pow;
            aUI.extravig = Mathf.Lerp(aUI.extravig,.1f,.3f);
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
