using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

    public GameObject img;
    int inventoryCount= 0;
    public GameObject holder;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(inventoryCount < GameManager.clothes.Count)
        {
            GameObject cloth = Instantiate(img) as GameObject;
            cloth.transform.parent = holder.transform;
            cloth.GetComponent<RectTransform>().transform.position = new Vector3(Random.Range(-100, 250) + 500, 78);
            cloth.GetComponent<RectTransform>().sizeDelta = new Vector2(cloth.GetComponent<RectTransform>().sizeDelta.x * 10 - 20, cloth.GetComponent<RectTransform>().sizeDelta.y * 5 - 20);
            cloth.GetComponent<Image>().sprite = ((GameObject) GameManager.clothes[inventoryCount]).GetComponent<SpriteRenderer>().sprite;
            inventoryCount++;
        }
		
	}
}
