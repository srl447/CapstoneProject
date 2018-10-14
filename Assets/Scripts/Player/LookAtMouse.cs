using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour {

    public Transform cursor;
    float xDir, yDir;

    Animator anim;
    string[] triggers = new string[6] { "idle", "upIdle", "idleS", "sideWalk", "downWalk", "upWalk" };
    Movement move;
    SpriteRenderer sR;
	// Use this for initialization
	void Start () {
        sR = GetComponent<SpriteRenderer>();
        move = GetComponent<Movement>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        //dir = Mathf.Rad2Deg*Mathf.Tan((cursor.position.y - transform.position.y) / (cursor.position.x - transform.position.x));
        //Debug.Log((cursor.position.y - transform.position.y) / (cursor.position.x - transform.position.x));
        xDir = cursor.position.x - transform.position.x;
        yDir = cursor.position.y - transform.position.y;
        if (xDir >= 0 && Mathf.Abs(xDir) > Mathf.Abs(yDir))
        {
            sR.flipX = false;
            if (move.walking)
            {
                SetTriggers("sideWalk");
            }
            else
            {
                SetTriggers("idleS");
            }
        }
        if(xDir < 0 && Mathf.Abs(xDir) > Mathf.Abs(yDir))
        {
            sR.flipX = true;
            if (move.walking)
            {
                SetTriggers("sideWalk");
            }
            else
            {
                SetTriggers("idleS");
            }
        }
        if (yDir >= 0 && Mathf.Abs(yDir) > Mathf.Abs(xDir))
        {
            sR.flipX = false;
            if (move.walking)
            {
                SetTriggers("upWalk");
            }
            else
            {
                SetTriggers("upIdle");
            }
        }
        if (yDir < 0 && Mathf.Abs(yDir) > Mathf.Abs(xDir))
        {
            sR.flipX = false;
            if (move.walking)
            {
                SetTriggers("downWalk");
            }
            else
            {
                SetTriggers("idle");
            }
        }
    }
    void SetTriggers(string trigger)
    {
        for (int i = 0; i < triggers.Length; i++)
        {
            anim.ResetTrigger(triggers[i]);
        }
        anim.SetTrigger(trigger);
    }

}
