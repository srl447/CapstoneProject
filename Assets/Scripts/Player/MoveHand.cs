using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHand : MonoBehaviour
{

    public GameObject clothesScreen;
    public Movement playerMovement;
    public PickupClothes playerPickup;
    public bool checkout;
    public bool holding, inCart;
    GameObject heldObject;
    public ArrayList viewClothes = new ArrayList();
    public AudioClip sound1, sound2, sound3;
    public AudioSource aud;

    public string type;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0); //get the x and y value
        pos = Camera.main.ScreenToWorldPoint(pos); //convert them to unity space
        pos = new Vector3(pos.x, pos.y, -9.9f); //push the cursor up infront of the camera
        transform.position = pos; //actually move the cursor

         if (Input.GetKeyUp(KeyCode.Mouse0))
         {
                holding = false;
                heldObject = null;
         }
         if (holding && !inCart)
         {
            if(heldObject != null)
                heldObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, heldObject.transform.position.z);
         }
        if(Input.GetKeyDown(KeyCode.Mouse1) && clothesScreen.activeSelf)
        {
           //remove clothes
           for (int i = 0; i < viewClothes.Count; i++)
           {
                Destroy((GameObject)viewClothes[i]);
                viewClothes.Remove(i);
           }
           //allow the player to move again
           clothesScreen.SetActive(false);
           playerMovement.enabled = true;
           StartCoroutine(clothDelay());
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //select clothes
        if (Input.GetKeyDown(KeyCode.Mouse0) )
        {
            /*if (collision.gameObject.GetComponent<ClothType>() != null)
            {
                if (!holding && collision.gameObject.tag == "Clothes")
                {
                    holding = true;
                    heldObject = collision.gameObject;
                }
                //StartCoroutine(pickup(collision.gameObject));
            }*/
            if (!holding && collision.gameObject.tag == "Clothes" && !inCart)
            {
                holding = true;
                heldObject = collision.gameObject;
            }
            else if (collision.gameObject.tag == "Sides" && !inCart && !holding)
            {
                for (int i = 0; i < viewClothes.Count; i++)
                {
                    Destroy((GameObject)viewClothes[i]);
                    viewClothes.Remove(i);
                }
                foreach (ClothesSpawner c in playerPickup.cS)
                {
                     c.Spawn();
                }
            }
            else if (collision.gameObject.tag == "Outside" && !inCart)
            {
                //remove clothes
                for (int i = 0; i < viewClothes.Count; i++)
                {
                    Destroy((GameObject)viewClothes[i]);
                    viewClothes.Remove(i);
                }
                //allow the player to move again
                clothesScreen.SetActive(false);
                playerMovement.enabled = true;
                StartCoroutine(clothDelay());
            }
            else
            {
                //if there's no clothes name, say which object is lacking it
                //Debug.LogError("no clothes on " + collision.gameObject.name);
            }
        }
        /*else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!holding && (Input.GetKeyDown(KeyCode.Mouse0) && collision.gameObject.tag == "Clothes"))
            {
                holding = true;
                heldObject = collision.gameObject;
            }
        }*/
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(holding && other.gameObject.tag == "Cart")
        {
            StartCoroutine(pickup(heldObject));
        }
    }
    //picks up the clothes, but run as it's own method to not rely on collision
    IEnumerator pickup(GameObject cloth)
    {
        inCart = true;
        holding = false;
        heldObject = null;
        GameObject newCloth = Instantiate(cloth) as GameObject;
        newCloth.SetActive(false);
        GameManager.clothes.Add(newCloth);
        switch ((int) Mathf.Ceil(Random.Range(0.00001f, 3)))
        {
            case 1:
                aud.PlayOneShot(sound1,7);
                break;
            case 2:
                aud.PlayOneShot(sound2,5);
                break;
            case 3:
                aud.PlayOneShot(sound3,6);
                break;
        }
        for(int i = 0; i < 6; i++)
        {
            cloth.transform.localScale += new Vector3(.15f, .15f, 0);
            yield return new WaitForEndOfFrame();
        }
        for (int i = 0; i < 5; i++)
        {
            cloth.transform.localScale -= new Vector3(.2f, .2f, 0);
            yield return new WaitForEndOfFrame();
        }
        //remove clothes
        for (int i = 0; i < viewClothes.Count; i++)
        {
            Destroy((GameObject)viewClothes[i]);
            viewClothes.Remove(i);
        }
        //allow the player to move again
        clothesScreen.SetActive(false);
        playerMovement.enabled = true;
        StartCoroutine(clothDelay());
    }

    IEnumerator clothDelay()
    {
        inCart = false;
        yield return new WaitForSecondsRealtime(.4f);
        playerPickup.enabled = true;
        playerPickup.canBuy = true;
    }
}
