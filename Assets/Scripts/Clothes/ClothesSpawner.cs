using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesSpawner : MonoBehaviour {

    public PickupClothes player;

    //Store all clothes in arrays by artical of clothing
    public GameObject[] tops;
    public GameObject[] pants;
    public GameObject[] ugTop;
    public GameObject[] hats;
    public GameObject[] dresses;
    public GameObject[] misc;
    public GameObject[] skirts;

    public MoveHand mH;

	// Use this for initialization
	public void Spawn ()
    {
        //assign a random piece of clothing to each spawner
        if (player.collidedClothes == "Tops")
        {
            GameObject cloth = Instantiate(tops[(int)Mathf.Floor(Random.Range(0f, tops.Length))]) as GameObject;
            cloth.transform.position = transform.position;
            float randScale = Random.Range(1f, 1.3f);
            cloth.transform.localScale = new Vector3(randScale, randScale, randScale);
            mH.viewClothes.Add(cloth);
        }
        //each area have their own kinds of clothes
        else if (player.collidedClothes == "Pants")
        {
            GameObject cloth = Instantiate(pants[(int)Mathf.Floor(Random.Range(0f, tops.Length))]) as GameObject;
            cloth.transform.position = transform.position;
            float randScale = Random.Range(1f, 1.3f);
            cloth.transform.localScale = new Vector3(randScale, randScale, randScale);
            mH.viewClothes.Add(cloth);
        }
        else if (player.collidedClothes == "UgTops")
        {
            GameObject cloth = Instantiate(ugTop[(int)Mathf.Floor(Random.Range(0f, tops.Length))]) as GameObject;
            cloth.transform.position = transform.position;
            float randScale = Random.Range(1f, 1.3f);
            cloth.transform.localScale = new Vector3(randScale, randScale, randScale);
            mH.viewClothes.Add(cloth);
        }
        else if (player.collidedClothes == "Hats")
        {
            GameObject cloth = Instantiate(hats[(int)Mathf.Floor(Random.Range(0f, hats.Length))]) as GameObject;
            cloth.transform.position = transform.position;
            float randScale = Random.Range(1f, 1.3f);
            cloth.transform.localScale = new Vector3(randScale, randScale, randScale);
            mH.viewClothes.Add(cloth);
        }
        else if (player.collidedClothes == "Dresses")
        {
            GameObject cloth = Instantiate(dresses[(int)Mathf.Floor(Random.Range(0f, dresses.Length))]) as GameObject;
            cloth.transform.position = transform.position;
            float randScale = Random.Range(1f, 1.3f);
            cloth.transform.localScale = new Vector3(randScale, randScale, randScale);
            mH.viewClothes.Add(cloth);
        }
        else if (player.collidedClothes == "Misc")
        {
            GameObject cloth = Instantiate(misc[(int)Mathf.Floor(Random.Range(0f, misc.Length))]) as GameObject;
            cloth.transform.position = transform.position;
            float randScale = Random.Range(1f, 1.3f);
            cloth.transform.localScale = new Vector3(randScale, randScale, randScale);
            mH.viewClothes.Add(cloth);
        }
        else if (player.collidedClothes == "Skirts")
        {
            GameObject cloth = Instantiate(skirts[(int)Mathf.Floor(Random.Range(0f, skirts.Length))]) as GameObject;
            cloth.transform.position = transform.position;
            float randScale = Random.Range(1f, 1.3f);
            cloth.transform.localScale = new Vector3(randScale, randScale, randScale);
            mH.viewClothes.Add(cloth);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
