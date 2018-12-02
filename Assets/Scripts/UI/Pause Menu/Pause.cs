using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public GameObject pauseMenu;
    public ChangingRooms cR;
    public Bathrooms bath;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
           pauseMenu.SetActive(!pauseMenu.activeSelf);
        }
        if(pauseMenu.activeSelf)
        {
            Time.timeScale = 0;
        }
        else if (!pauseMenu.activeSelf && !cR.start && !bath.start)
        {
            Time.timeScale = 1;
        }
		
	}
}
