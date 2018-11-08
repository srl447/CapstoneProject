using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnxietyBar : MonoBehaviour {

    public RectTransform bar;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(GameManager.anxiety);
        bar.sizeDelta = new Vector2(325 - (GameManager.anxiety * 100), bar.sizeDelta.y);
        bar.position = new Vector3(615 - (GameManager.anxiety * 50), bar.position.y, bar.position.z);
		
	}
}
