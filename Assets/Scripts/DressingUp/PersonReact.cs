using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonReact : MonoBehaviour {

    public Sprite reallyHappy, happy;
    int clothes;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(clothes == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = happy;
        }
        else if (clothes == 2)
        {
            this.GetComponent<SpriteRenderer>().sprite = reallyHappy;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Clothes")
        {
            clothes++;
        }
    }
}
