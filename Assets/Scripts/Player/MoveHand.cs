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

        if(checkout)
        {
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                holding = false;
            }
            if (holding)
            {
                heldObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, heldObject.transform.position.z);
            }
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
        if (Input.GetKeyDown(KeyCode.Mouse0) && !checkout)
        {
            if (collision.gameObject.GetComponent<ClothType>() != null)
            {
                GameObject newCloth = Instantiate(collision.gameObject) as GameObject;
                newCloth.SetActive(false);
                GameManager.clothes.Add(newCloth);

                pickup();
            }
            else if (collision.gameObject.tag == "Sides")
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
            else if (collision.gameObject.tag == "Outside")
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
        switch ((int) Mathf.Ceil(Random.Range(0, 3)))
        {
            case 1:
                aud.PlayOneShot(sound1,2);
                break;
            case 2:
                aud.PlayOneShot(sound2,2);
                break;
            case 3:
                aud.PlayOneShot(sound3,2);
                break;
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
        yield return new WaitForSecondsRealtime(.4f);
        playerPickup.enabled = true;
        playerPickup.canBuy = true;
    }
}
