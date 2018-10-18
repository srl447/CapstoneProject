using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHand : MonoBehaviour
{

    public GameObject clothesScreen;
    public Movement playerMovement;
    public PickupClothes playerPickup;
    public bool checkout;
    bool holding;
    GameObject heldObject;
    public ArrayList viewClothes = new ArrayList();
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0); //get the x and y value
        pos = Camera.main.ScreenToWorldPoint(pos); //convert them to unity space
        pos = new Vector3(pos.x, pos.y, -9.1f); //push the cursor up infront of the camera
        transform.position = pos; //actually move the cursor

        if(checkout)
        {
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                holding = false;
            }
            if (holding)
            {
                heldObject.transform.position = this.transform.position;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //select clothes
        if (Input.GetKeyDown(KeyCode.Mouse0) && !checkout)
        {
            if (collision.gameObject.GetComponent<ClothType>() != null)
            {
                GameObject newCloth = Instantiate(collision.gameObject) as GameObject;
                newCloth.SetActive(false);
                GameManager.clothes.Add(newCloth);
                
                pickup();
            }
            else
            {
                //if there's no clothes name, say which object is lacking it
                //Debug.LogError("no clothes on " + collision.gameObject.name);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && checkout)
        {
            if (!holding && (Input.GetKeyDown(KeyCode.Mouse0) && collision.gameObject.tag == "Clothes"))
            {
                holding = true;
                heldObject = collision.gameObject;
            }
        }
    }

    //picks up the clothes, but run as it's own method to not rely on collision
    private void pickup()
    {

        clothesScreen.SetActive(false);
        //remove clothes
        for (int i = 0; i < viewClothes.Count; i++)
        {
            Destroy((GameObject)viewClothes[i]);
            viewClothes.Remove(i);
        }
        //allow the player to move again
        playerMovement.enabled = true;
    }

    IEnumerator clothDelay()
    {
        yield return new WaitForSecondsRealtime(.1f);
        playerPickup.enabled = true;
    }
}
