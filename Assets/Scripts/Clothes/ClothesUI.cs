using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothesUI : MonoBehaviour {

    public Text clothesText;
    public MoveHand mH;
    public PickupClothes pC;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!pC.purchased)
        {
            clothesText.text = "Clothes Bought:";
            for (int i = 0; i < mH.clothes.Count; i++)
            {
                clothesText.text += " " + mH.clothes[i];
            }
        }
        //change to let people know they purchased clothes
        else if(pC.purchased)
        {
            clothesText.text = "Purchased";
        }
		
	}
}
