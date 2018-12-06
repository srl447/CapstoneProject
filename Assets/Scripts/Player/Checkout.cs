using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkout : MonoBehaviour {

    public ArrayList clothSet;
    public GameObject counterScreen, topUI, clothes, cart;
    public Movement move;
    public PickupClothes pC;
    public ThoughtText tT;
    public RegisterThoughts rT;
    public RegisterThoughts2 rT2;
    public RegisterThoughts3 rT3;
    public AnxiousThoughts aT;

    int clothCount;

    // Use this for initialization
    void Awake() {
        GameManager.cantLoose = true;
        cart.SetActive(false);
        clothes.SetActive(false);
        tT.enabled = false;
        aT.enabled = false;
        foreach (GameObject c in clothSet)
        {
            c.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update() {
        if (GameManager.clothes.Count <= clothCount)
        {
            rT.end = true;
            rT2.end = true;
            rT3.end = true;
        }
        if (rT.fin || rT2.fin || rT3.fin)
        {
           // Debug.Log("step 1");
            tT.enabled = true;
            topUI.SetActive(false);
            foreach (GameObject c in clothSet)
            {
                c.SetActive(false);
            }
            counterScreen.SetActive(false);
           // Debug.Log("step 2");
            move.enabled = true;
            pC.enabled = true;
           // Debug.Log("step 3");
            Node newNode = new Node();
            newNode.thoughts = "Finally, I can get out of here!";
            newNode.thoughtTime = 2;
            tT.add(newNode);
            pC.purchased = true;
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Clothes")
        {
            clothCount++;
            clothSet.Add(collision.gameObject);
        }
    }
    bool allCloth()
    {
        foreach(GameObject c in clothSet)
        { 
            if(c.transform.position.x < -18)
            {
                return false;
            }
            else
            {
                //c.SetActive(false);
            }
        }
        return true;
    }
}
