using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorShow : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void hideCursor()
    {
        Cursor.visible = false;
    }
}
