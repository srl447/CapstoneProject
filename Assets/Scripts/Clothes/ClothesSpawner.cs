﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesSpawner : MonoBehaviour {

    public PickupClothes player;

    //Store all clothes in arrays by artical of clothing
    public GameObject[] tops;
    public GameObject[] pants;
    public GameObject[] ugTop;

    public MoveHand mH;

	// Use this for initialization
	public void Spawn ()
    {
        //assign a random piece of clothing to each spawner
        if (player.collidedClothes == "Tops")
        {
            GameObject cloth = Instantiate(tops[(int)Mathf.Floor(Random.Range(0f, tops.Length))]) as GameObject;
            cloth.transform.position = transform.position;
            float randScale = Random.Range(1f, 1.6f);
            cloth.transform.localScale = new Vector3(randScale, randScale, randScale);
            mH.viewClothes.Add(cloth);
        }
        //each area have their own kinds of clothes
        else if (player.collidedClothes == "Pants")
        {
            GameObject cloth = Instantiate(pants[(int)Mathf.Floor(Random.Range(0f, tops.Length))]) as GameObject;
            cloth.transform.position = transform.position;
            float randScale = Random.Range(1f, 1.6f);
            cloth.transform.localScale = new Vector3(randScale, randScale, randScale);
            mH.viewClothes.Add(cloth);
        }
        else if (player.collidedClothes == "UgTops")
        {
            GameObject cloth = Instantiate(ugTop[(int)Mathf.Floor(Random.Range(0f, tops.Length))]) as GameObject;
            cloth.transform.position = transform.position;
            float randScale = Random.Range(1f, 1.6f);
            cloth.transform.localScale = new Vector3(randScale, randScale, randScale);
            mH.viewClothes.Add(cloth);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
