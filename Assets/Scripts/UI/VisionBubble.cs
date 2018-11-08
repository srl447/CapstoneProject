using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionBubble : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemySight")
        {
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        if(collision.gameObject.tag == "AnxietyZone1")
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemySight")
        {
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (collision.gameObject.tag == "AnxietyZone1")
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
