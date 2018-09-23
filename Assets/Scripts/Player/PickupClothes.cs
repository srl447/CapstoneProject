using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupClothes : MonoBehaviour
{
    int clothesCount = 0;
    public GameObject clothesScreen;
	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Clothes")
        {
            clothesScreen.SetActive(true);
            this.GetComponent<Movement>().enabled = false;
            clothesCount++;
        }
        if (collision.gameObject.tag == "Counter")
        {
            if (clothesCount > 0)
            {
                Debug.Log("Purchased");
            }

        }
    }
}
