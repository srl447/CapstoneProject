using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour {

    public Transform cursor;
    float xDir, yDir;

    public Animator anim;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //dir = Mathf.Rad2Deg*Mathf.Tan((cursor.position.y - transform.position.y) / (cursor.position.x - transform.position.x));
        //Debug.Log((cursor.position.y - transform.position.y) / (cursor.position.x - transform.position.x));
        xDir = cursor.position.x - transform.position.x;
        yDir = cursor.position.y - transform.position.y;
        if (xDir >= 0 && Mathf.Abs(xDir) > Mathf.Abs(yDir))
        {
            Debug.Log("right");
        }
        if(xDir < 0 && Mathf.Abs(xDir) > Mathf.Abs(yDir))
        {
            Debug.Log("left");
        }
        if (yDir >= 0 && Mathf.Abs(yDir) > Mathf.Abs(xDir))
        {
            Debug.Log("up");
        }
        if (yDir < 0 && Mathf.Abs(yDir) > Mathf.Abs(xDir))
        {
            Debug.Log("down");
        }
    }
}
