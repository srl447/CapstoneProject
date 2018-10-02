using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static ArrayList clothes = new ArrayList();
    //public static float anxiety;

    public static bool holding;

	// Use this for initialization
	void Awake ()
    {
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
