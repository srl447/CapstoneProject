using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stealing : MonoBehaviour {

    public GameObject wall;
    public AudioClip steal;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PickupClothes>().purchased == false && GameManager.clothes.Count > 0)
        {
            wall.SetActive(true);
            collision.gameObject.GetComponent<ThoughtText>().add(new Node("Even if the register is scary, I can't shoplift!", 3f, steal));
        }
        
    }
}
