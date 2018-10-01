using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Leaving : MonoBehaviour {

    public PickupClothes pC;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        //check if they leave and haev purchased clothes
        if(collision.gameObject.tag == "Exit" && pC.purchased == true)
        {
            SceneManager.LoadScene(1);
        }
    }
}
