using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHand : MonoBehaviour
{

    public GameObject clothesScreen;
    public Movement playerMovement;
    public PickupClothes playerPickup;
    public float handSpeed;
    //public ArrayList clothes = new ArrayList();
    public ArrayList viewClothes = new ArrayList();
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + handSpeed, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - handSpeed, transform.position.y, transform.position.z);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //select clothes
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (collision.gameObject.GetComponent<ClothType>() != null)
            {
                GameManager.clothes.Add(collision.gameObject);
                pickup();
            }
            else
            {
                //if there's no clothes name, say which object is lacking it
                Debug.LogError("no clothes on " + collision.gameObject.name);
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
}
