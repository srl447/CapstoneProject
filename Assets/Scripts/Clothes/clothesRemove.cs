using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clothesRemove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "MallScene")
        {
            if(!GameObject.Find("buying clothes screen") && !GameObject.Find("CheckOut"))
            {
                this.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
	}
}
