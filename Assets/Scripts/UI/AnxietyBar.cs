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
       // Debug.Log(GameManager.anxiety);
        bar.sizeDelta = new Vector2(265 - (GameManager.anxiety * 100f)*1.3f, bar.sizeDelta.y);
        bar.position = new Vector3(525 - (GameManager.anxiety * 50f)*1.3f, bar.position.y, bar.position.z);
		
	}
}
