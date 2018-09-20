using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSpotted : MonoBehaviour {

    SpriteRenderer sR;
	// Use this for initialization
	void Start ()
    {
        sR = GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemySight")
        {
            sR.color = new Color(sR.color.r - .01f , sR.color.g - .01f ,sR.color.b);
        }
    }
}
