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
        //up
        if(this.transform.position.y < player.transform.position.y - 2.7f)
        {
            this.transform.Translate(new Vector3(0f, player.transform.position.y - 2.7f - transform.position.y, 0f));
        }
        //down
        if (this.transform.position.y > player.transform.position.y + 2f)
        {
            this.transform.Translate(new Vector3(0f, player.transform.position.y - transform.position.y + 2f, 0f));
        }
        //left
        if(this.transform.position.x < player.transform.position.x - 5f)
        {
            this.transform.Translate(new Vector3(player.transform.position.x - 5f - transform.position.x, 0f, 0f));
        }
        //right
        if (this.transform.position.x > player.transform.position.x + 5f)
        {
            this.transform.Translate(new Vector3(player.transform.position.x - transform.position.x + 5f, 0f,0f));
        }
    }
}
