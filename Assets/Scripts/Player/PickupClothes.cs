﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupClothes : MonoBehaviour
{
    int clothesCount = 0;
    public GameObject clothesScreen;
    public GameObject checkOut;
    public string collidedClothes;
    public ClothesSpawner[] cS;
    public ThoughtText tT;
    public Checkout check;
    public MoveHand mH;
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
                this.GetComponent<Movement>().up = false;
                this.GetComponent<Movement>().left = false;
                this.GetComponent<Movement>().down = false;
                this.GetComponent<Movement>().right = false;
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
                ArrayList clothSet = new ArrayList();
                foreach (GameObject c in GameManager.clothes)
                {
                    GameObject newCloth = Instantiate(c) as GameObject;
                    newCloth.transform.position = new Vector3(Random.Range(-28f, -32f), Random.Range(0f, -2f), -9f);
                    clothSet.Add(newCloth);
                }
                check.clothSet = clothSet;
                checkOut.SetActive(true);
                mH.checkout = true;
                this.GetComponent<Movement>().up = false;
                this.GetComponent<Movement>().left = false;
                this.GetComponent<Movement>().down = false;
                this.GetComponent<Movement>().right = false;
                this.GetComponent<Movement>().enabled = false;
                this.GetComponent<PickupClothes>().enabled = false;
            }

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collidedClothes = null;
    }
}
