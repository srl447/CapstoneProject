using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSprite : MonoBehaviour {

    public GameObject checkOut, clothes, circle;
    public Sprite cursor, hand, grabbyHand, cursor2;
    bool col;
	// Use this for initialization
	void Start () {
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (checkOut.activeSelf || clothes.activeSelf)
        {
            circle.SetActive(false);
            if(this.GetComponent<MoveHand>().holding)
            {
                GetComponent<SpriteRenderer>().sprite = grabbyHand;
            }
            else if (col)
            {
                GetComponent<SpriteRenderer>().sprite = hand;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = cursor2;
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = cursor;
            circle.SetActive(true);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Clothes" || collision.gameObject.tag == "Sides")
        {
            col = true;
        }
        else
        {
            col = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Clothes" || collision.gameObject.tag == "Sides")
        {
            col = false;
        }
    }
}
