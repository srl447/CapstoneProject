﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningClothes : MonoBehaviour {

    public GameObject[] clothing;
	// Use this for initialization
	void Start () {
        //Debug.Log(GameManager.clothes.Count);
        for(int i = 0; i < GameManager.clothes.Count; i++)
        {
            GameObject newCloth = Instantiate((GameObject) GameManager.clothes[i]) as GameObject;
            newCloth.SetActive(true);
            newCloth.transform.position = new Vector3(Random.Range(-6f, -2f), Random.Range(-3f, 3f), -1f); 
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
