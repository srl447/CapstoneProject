using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerSight : MonoBehaviour {

    public GameObject topUI;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Movement>().up = false;
            collision.gameObject.GetComponent<Movement>().left = false;
            collision.gameObject.GetComponent<Movement>().down = false;
            collision.gameObject.GetComponent<Movement>().right = false;
            collision.gameObject.GetComponent<Movement>().enabled = false;
            topUI.SetActive(true);
        }
    }
}
