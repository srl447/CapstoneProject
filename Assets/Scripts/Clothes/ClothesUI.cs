using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothesUI : MonoBehaviour {

    //this isn't used at all anymore?
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
                clothesText.text += " " +  ((GameObject)GameManager.clothes[i]).GetComponent<ClothType>().clothType;
            }
        }
        //change to let people know they purchased clothes
        else if(pC.purchased)
        {
            clothesText.text = "Purchased";
        }
		
	}
}
