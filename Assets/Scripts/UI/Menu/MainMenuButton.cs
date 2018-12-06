using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour {

    public GameObject gameManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SceneManager.LoadScene(0);
        GameManager.clothes = new ArrayList();
        Destroy(gameManager);
	}
}
