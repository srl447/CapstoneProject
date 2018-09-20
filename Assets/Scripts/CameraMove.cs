using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.position.y < player.transform.position.y - 3f)
        {
            transform.Translate(new Vector3(0f, player.transform.position.y - 3f - transform.position.y, 0f));
        }
        if (transform.position.y > player.transform.position.y + 3f)
        {
            transform.Translate(new Vector3(0f, player.transform.position.y - transform.position.y + 3f, 0f));
        }
        if(transform.position.x < player.transform.position.x - 6f)
        {
            transform.Translate(new Vector3(player.transform.position.x - 6f - transform.position.x, 0f, 0f));
        }
        if (transform.position.x > player.transform.position.x + 6f)
        {
            transform.Translate(new Vector3(player.transform.position.x - transform.position.x + 6f, 0f,0f));
        }
    }
}
