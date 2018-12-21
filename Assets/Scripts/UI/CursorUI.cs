using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorUI : MonoBehaviour
{
    bool holding;
    GameObject heldObject;
    internal static bool visible;
    bool handOn;
    public Sprite cursor, hand, grabbyHand;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0); //get the x and y value
        pos = Camera.main.ScreenToWorldPoint(pos); //convert them to unity space
        pos = new Vector3(pos.x, pos.y, -2f); //push the cursor up infront of the camera
        transform.position = pos; //actually move the cursor

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            holding = false;
        }
        if(holding)
        {
            this.GetComponent<SpriteRenderer>().sprite = grabbyHand;
            heldObject.transform.position = this.transform.position;
            if(Input.GetKey(KeyCode.A))
            {
                heldObject.transform.eulerAngles = new Vector3(heldObject.transform.eulerAngles.x, heldObject.transform.eulerAngles.y, heldObject.transform.eulerAngles.z - 1);
            }
            if (Input.GetKey(KeyCode.D))
            {
                heldObject.transform.eulerAngles = new Vector3(heldObject.transform.eulerAngles.x, heldObject.transform.eulerAngles.y, heldObject.transform.eulerAngles.z + 1);
            }
            if(Input.GetKey(KeyCode.W))
            {
                heldObject.GetComponent<SpriteRenderer>().sortingOrder--;
            }
            if (Input.GetKey(KeyCode.D))
            {
                heldObject.GetComponent<SpriteRenderer>().sortingOrder++;
            }
        }
        else if (!handOn)
        {
            this.GetComponent<SpriteRenderer>().sprite = cursor;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //select clothes
        if (!holding && (Input.GetKeyDown(KeyCode.Mouse0) && collision.gameObject.tag == "Clothes"))
        {
            holding = true;
            heldObject = collision.gameObject;
        }
        if(collision.gameObject.tag == "Clothes")
        {
            handOn = true;
            this.GetComponent<SpriteRenderer>().sprite = hand;
        }
        /*else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            holding = false;
        }
        else if(GameManager.holding)
        {
            collision.gameObject.transform.position = this.transform.position;
        }*/
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Clothes")
        {
            handOn = false;
        }
    }
}
