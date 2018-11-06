using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonReact : MonoBehaviour {

    public Sprite sad, happy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("colliding");
        if(collision.gameObject.tag == "Clothes" && (collision.gameObject.transform.localScale.x < 1 || collision.gameObject.transform.localScale.x > 1.3))
        {
            GetComponent<SpriteRenderer>().sprite = sad;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = happy;
        }

    }
}
