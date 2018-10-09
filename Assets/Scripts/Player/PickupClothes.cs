using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupClothes : MonoBehaviour
{
    int clothesCount = 0;
    public GameObject clothesScreen;
    public string collidedClothes;
    public ClothesSpawner[] cS;
    public bool purchased = false;

	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Clothes")
        {
            if (collision.GetComponent<ClothType>() != null)
            { 
                collidedClothes = collision.GetComponent<ClothType>().clothType;
            } 
            if (Input.GetKeyDown(KeyCode.E) && !clothesScreen.activeInHierarchy)
            {
                clothesScreen.SetActive(true);
                foreach (ClothesSpawner c in cS)
                {
                    c.Spawn();
                }
                //turn off player movement
                this.GetComponent<Movement>().enabled = false;
                clothesCount++;
                collidedClothes = collision.GetComponent<ClothType>().clothType;
                this.GetComponent<PickupClothes>().enabled = false;
            }
        }
        //purchasing clothes
        if (collision.gameObject.tag == "Counter" && Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (clothesCount > 0)
            {
                purchased = true;
                Debug.Log("works!");
            }

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collidedClothes = null;
    }
}
