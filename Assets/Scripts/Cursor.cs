using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    bool holding = false;
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

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //select clothes
        if (Input.GetKeyDown(KeyCode.Mouse0) && collision.gameObject.tag == "Clothes" && !holding)
        {
            holding = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            holding = false;
        }
        else if(holding)
        {
            collision.gameObject.transform.position = this.transform.position;
        }
    }
}
