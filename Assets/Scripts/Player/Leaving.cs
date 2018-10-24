using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Leaving : MonoBehaviour {

    public PickupClothes pC;
    ThoughtText tT;
    GetSpotted gS;
	// Use this for initialization
	void Start () {
        tT = GetComponent<ThoughtText>();
        gS = GetComponent<GetSpotted>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if they leave and haev purchased clothes
        if (collision.gameObject.tag == "Exit" && pC.purchased == true)
        {
            foreach (GameObject g in GameManager.clothes)
            {
                DontDestroyOnLoad(g);
            }
            SceneManager.LoadScene(0);
        }
        else if (collision.gameObject.tag == "Exit" && gS.anx > 1.5)
        {
            SceneManager.LoadScene(2);
        }
        else if (collision.gameObject.tag == "Exit" && pC.purchased == false)
        {
            Node dontLeave = new Node();
            dontLeave.thoughts = "I'm not letting myself leave until I purchase some clothes!";
            dontLeave.thoughtTime = 2;
            tT.add(dontLeave);
        }
    }
}
