using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothesUI : MonoBehaviour {

    public Text clothesText;
    public PickupClothes pC;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!pC.purchased)
        {
            clothesText.text = "Clothes Bought:";
            for (int i = 0; i < GameManager.clothes.Count; i++)
            {
                clothesText.text += " " + GameManager.clothes[i].ToString();
            }
        }
        //change to let people know they purchased clothes
        else if(pC.purchased)
        {
            clothesText.text = "Purchased";
        }
		
	}
}
