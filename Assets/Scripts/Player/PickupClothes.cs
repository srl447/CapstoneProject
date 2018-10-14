using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupClothes : MonoBehaviour
{
    int clothesCount = 0;
    public GameObject clothesScreen;
    public string collidedClothes;
    public ClothesSpawner[] cS;
    public ThoughtText tT;
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
            if (Input.GetKeyDown(KeyCode.Mouse0) && !clothesScreen.activeInHierarchy)
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
                Node newNode = new Node();
                newNode.thoughts = "Finally, I can get out of here!";
                newNode.thoughtTime = 2;
                tT.add(newNode);
                purchased = true;
            }

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collidedClothes = null;
    }
}
