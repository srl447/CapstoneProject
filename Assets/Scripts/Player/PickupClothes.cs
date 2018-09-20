using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupClothes : MonoBehaviour
{
    bool hasClothes = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Clothes")
        {
            Destroy(collision.gameObject);
            hasClothes = true;
        }
    }
}
