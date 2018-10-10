using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Rigidbody2D rb;
    public Animator anim;
    //input variables per direction
    bool up, down, left, right, upLeft, downLeft, upRight, downRight;
    public float velocity;
	// Use this for initialization
	void Start ()
    {
        rb = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //check which input occurs
        //Diagnols to be added laters
        if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.A))
        {

        }
        else if(Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.D))
        {

        }
        else if (Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.A))
        {

        }
        else if (Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.D))
        {

        }
		if(Input.GetKey(KeyCode.W))
        {
            up = true;
        }
        else
        {
            up = false;
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            down = true;
            //animation is set on button presses because it worked here
            anim.SetTrigger("downWalk");
        }
        else if(Input.GetKeyUp(KeyCode.S))
        {
            down = false;
            anim.SetTrigger("idle");
        }
        if (Input.GetKey(KeyCode.D))
        {
            right = true;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            right = false;
            anim.SetTrigger("idleS");
        }
        if (Input.GetKey(KeyCode.A))
        {
            left = true;
        }
        else
        {
            left = false;
        }
    }

    private void FixedUpdate()
    {
        //move in FixedUpdate for physics reasons
        if (up)
        {
            transform.Translate(Vector3.up * velocity * Time.deltaTime);
        }
        if (left)
        {
            transform.Translate(Vector3.left * velocity * Time.deltaTime);
        }
        if (down)
        {
            transform.Translate(Vector3.down * velocity * Time.deltaTime);

        }
        if (right)
        {
            transform.Translate(Vector3.right * velocity * Time.deltaTime);
        }
        //stops character from being pushed kinda
        //Needs to be adjusted for while moving
        if(!up && !left && !down && !right)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
        }
    }
}
