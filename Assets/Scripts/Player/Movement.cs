using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Rigidbody2D rb;
    public Animator anim;
    //input variables per direction
    public bool up, down, left, right, upLeft, downLeft, upRight, downRight, walking;
    public float velocity;
    string[] triggers = new string[6] { "idle", "upIdle", "idleS", "sideWalk", "downWalk", "upWalk"};

    int soundTimer;
    public AudioClip sound1, sound2, sound3, sound4;
    public AudioSource aud;
    int soundCase;

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
		if(Input.GetKeyDown(KeyCode.W))
        {
            up = true;
            //ResetTriggers();
            //anim.SetTrigger("upWalk");
        }
        else if(Input.GetKeyUp(KeyCode.W))
        {
            up = false;
            //ResetTriggers();
            //anim.SetTrigger("upIdle");
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            down = true;
            //animation is set on button presses because it worked here
            //ResetTriggers();
            //anim.SetTrigger("downWalk");
        }
        else if(Input.GetKeyUp(KeyCode.S))
        {
            down = false;
            //ResetTriggers();
            //anim.SetTrigger("idle");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            right = true;
            //this.GetComponent<SpriteRenderer>().flipX =false;
            //ResetTriggers();
            //anim.SetTrigger("sideWalk");
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            right = false;
            //ResetTriggers();
            //anim.SetTrigger("idleS");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            //this.GetComponent<SpriteRenderer>().flipX = true;
            left = true;
            //ResetTriggers();
            //anim.SetTrigger("sideWalk");
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            left = false;
            //ResetTriggers();
            //anim.SetTrigger("idleS");
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
            walking = false;
        }
        else
        {
            walking = true;
            if (soundTimer < 15)
            {
                soundTimer++;
            }
            else
            {
                soundTimer = 0;
                switch (soundCase)
                {
                    case 1:
                        aud.PlayOneShot(sound1, 1);
                        break;
                    case 2:
                        aud.PlayOneShot(sound2, 1);
                        break;
                    case 3:
                        aud.PlayOneShot(sound3, 1);
                        break;
                    case 4:
                        aud.PlayOneShot(sound4, 1);
                        break;
                }
                soundCase++;
                if(soundCase > 4)
                {
                    soundCase = 0;
                }
            }
        }
    }

    void ResetTriggers()
    {
        for(int i = 0; i < triggers.Length;i++)
        {
            anim.ResetTrigger(triggers[i]);
        }
    }
}
