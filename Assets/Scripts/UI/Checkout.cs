﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkout : MonoBehaviour {

    public ArrayList clothSet;
    public GameObject counterScreen;
    public Movement move;
    public PickupClothes pC;
    public ThoughtText tT;
	// Use this for initialization
	void Awake () {
		foreach(GameObject c in clothSet)
        {
            c.SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(allCloth() || Input.GetKeyDown(KeyCode.Space))
        {
            counterScreen.SetActive(false);
            move.enabled = true;
            pC.enabled = true;
            Node newNode = new Node();
            newNode.thoughts = "Finally, I can get out of here!";
            newNode.thoughtTime = 2;
            tT.add(newNode);
            pC.purchased = true;
        }
	}

    bool allCloth()
    {
        foreach(GameObject c in clothSet)
        {
            if(c.transform.position.x < -19)
            {
                return false;
            }
        }
        return true;
    }
}
