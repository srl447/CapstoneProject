using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSprite : MonoBehaviour {

    public GameObject checkOut, clothes, circle;
    public Sprite cursor, hand, grabbyHand;
    bool col;
	// Use this for initialization
	void Start () {
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (checkOut.activeSelf || clothes.activeSelf)
        {
            circle.GetComponent<SpriteRenderer>().enabled = false;
            if (col)
            {
                GetComponent<SpriteRenderer>().sprite = grabbyHand;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = hand;
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = cursor;
            circle.GetComponent<SpriteRenderer>().enabled = True;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Clothes")
        {
            col = true;
        }
        else
        {
            col = false;
        }
    }
}
