using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

    public GameObject img;
    int inventoryCount= 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(inventoryCount < GameManager.clothes.Count)
        {
            GameObject cloth = Instantiate(img) as GameObject;
            cloth.transform.parent = gameObject.transform;
            cloth.GetComponent<RectTransform>().transform.position = new Vector3(Random.Range(-160, 200) + 500, 200);
            cloth.GetComponent<Image>().sprite = ((GameObject) GameManager.clothes[inventoryCount]).GetComponent<SpriteRenderer>().sprite;
            inventoryCount++;
        }
		
	}
}
