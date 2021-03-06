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
    public GameObject topUI;
    public bool purchased = false;
    public bool canBuy = true;
    public AudioClip[] clothesThoughts;

    bool[] played = { false, false, false };
    public GameObject cart;

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
        if (collision.gameObject.tag == "ClothesZone" && GameManager.anxiety <= 1.6f)
        {
            if (collision.GetComponent<ClothType>() != null)
            { 
                collidedClothes = collision.GetComponent<ClothType>().clothType;
            } 
            if (canBuy && Input.GetKeyDown(KeyCode.Mouse0) && !clothesScreen.activeInHierarchy && collision.GetComponent<ClothType>() && !mH.checkout)
            {
                if (GameManager.clothes.Count == 0 && !played[0])
                {
                    Node newThought = new Node("Ooo they're so many cute options!", 2, clothesThoughts[0]);
                    tT.add(newThought);
                    played[0] = true;
                }
                else if (GameManager.clothes.Count == 1 && !played[1])
                {
                    Node newThought = new Node("I wonder if these are the right size?", 2, clothesThoughts[2]);
                    tT.add(newThought);
                    played[1] = true;
                }
                /*else if(GameManager.clothes.Count == 2)
                {
                    Node newThought = new Node("I hope I'm not spending too much", 2, clothesThoughts[1]);
                    tT.add(newThought);
                }*/
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
                canBuy = false;
                this.GetComponent<PickupClothes>().enabled = false;
            }
        }
        //purchasing clothes
        if ((collision.gameObject.tag == "Counter" || collision.gameObject.tag == "Counter2" || collision.gameObject.tag == "Counter3")  && Input.GetKeyDown(KeyCode.Mouse0) && GameManager.anxiety <= 1.55f)
        {
            if (clothesCount > 0)
            {
                ArrayList clothSet = new ArrayList();
                foreach (GameObject c in GameManager.clothes)
                {
                    GameObject newCloth = Instantiate(c) as GameObject;
                    newCloth.transform.position = cart.transform.position + new Vector3(Random.Range(-1f,1f),Random.Range(-.5f,.5f), .03f);
                    clothSet.Add(newCloth);
                }
                check.clothSet = clothSet;
                checkOut.SetActive(true);
                mH.checkout = true;
                GameManager.cantLoose = true;
                if (collision.gameObject.tag == "Counter")
                {
                    checkOut.GetComponentInChildren<Checkout>().rT.enabled = true;
                    checkOut.GetComponentInChildren<Checkout>().rT2.enabled = false;
                    checkOut.GetComponentInChildren<Checkout>().rT3.enabled = false;

                }
                else if (collision.gameObject.tag == "Counter2")
                {
                    checkOut.GetComponentInChildren<Checkout>().rT2.enabled = true;
                    checkOut.GetComponentInChildren<Checkout>().rT.enabled = false;
                    checkOut.GetComponentInChildren<Checkout>().rT3.enabled = false;
                }
                else if (collision.gameObject.tag == "Counter3")
                {
                    checkOut.GetComponentInChildren<Checkout>().rT3.enabled = true;
                    checkOut.GetComponentInChildren<Checkout>().rT2.enabled = false;
                    checkOut.GetComponentInChildren<Checkout>().rT.enabled = false;
                }
                topUI.SetActive(true);
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
