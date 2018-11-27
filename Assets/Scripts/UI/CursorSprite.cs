using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSprite : MonoBehaviour {

    public GameObject checkOut, clothes;
    public Sprite cursor, hand;
	// Use this for initialization
	void Start () {
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (checkOut.activeSelf || clothes.activeSelf)
        {
            GetComponent<SpriteRenderer>().sprite = hand;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = cursor;
        }
	}
}
