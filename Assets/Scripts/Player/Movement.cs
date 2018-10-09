using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Rigidbody2D rb;
    public Animator anim;
    bool up, down, left, right;
    public float velocity;
	// Use this for initialization
	void Start ()
    {
        rb = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
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
        if(!up && !left && !down && !right)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
        }
    }
}
