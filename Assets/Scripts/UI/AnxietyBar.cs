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
        //print(Screen.currentResolution);
        //Debug.Log(GameManager.anxiety);
        //bar.sizeDelta = new Vector2((0.12f*Screen.width) - (GameManager.anxiety * 100f)*1.3f, bar.sizeDelta.y);
        //bar.position = new Vector3((0.425f*Screen.width) - (GameManager.anxiety * 50f)*1.3f, bar.position.y, bar.position.z);
        bar.sizeDelta = new Vector2(-630.5f - GameManager.anxiety*130, bar.sizeDelta.y);
        //Debug.Log(bar.sizeDelta);

		
	}
}
