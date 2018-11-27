using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontDoors : MonoBehaviour {

    public GameObject door1, door2;
    float ogPos1, ogPos2;
    bool open;
	// Use this for initialization
	void Start () {
        ogPos1 = door1.transform.position.x;
        ogPos2 = door2.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if(!open)
        {
            door1.transform.position = new Vector3(Mathf.Lerp(door1.transform.position.x, ogPos1, .15f), door1.transform.position.y, door1.transform.position.z);
            door2.transform.position = new Vector3(Mathf.Lerp(door2.transform.position.x, ogPos2, .15f), door2.transform.position.y, door2.transform.position.z);
        }
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            open = true;
            door1.transform.position = new Vector3(Mathf.Lerp(door1.transform.position.x, ogPos1 - 2,.15f), door1.transform.position.y, door1.transform.position.z);
            door2.transform.position = new Vector3(Mathf.Lerp(door2.transform.position.x, ogPos2 + 2, .15f), door2.transform.position.y, door2.transform.position.z);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            open = false;
        }
    }
}
