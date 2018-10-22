using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnxiousThoughts : MonoBehaviour {

    public GetSpotted gS;
    public ThoughtText tT;
    public bool[] thoughts = new bool[1];
    public Image img;
    public Sprite[] heads;
	// Use this for initialization
	void Start ()
    {
        //No thoughts have been thunk
		for(int i = 0; i < thoughts.Length; i++)
        {
            thoughts[i] = false;
        }
	}

    // Update is called once per frame
    void Update()
    {
        //What's basically going on is there's an array of bools
        //when anxiety reaches a certain point a new thought will be displayed
        //and then never displayed again
        //the array of bools keeps track of this
        if (gS.anx > 0 && !thoughts[0])
        {
            Node newThought = new Node();
            newThought.thoughts = "I can't let anyone see me";
            newThought.thoughtTime = 2;
            tT.add(newThought);
            thoughts[0] = true;
            img.sprite = heads[0];

        }
        if (gS.anx > .3 && !thoughts[1])
        {
            Node newThought = new Node();
            newThought.thoughts = "Fuckkk people are staring at me";
            newThought.thoughtTime = 2;
            tT.add(newThought);
            thoughts[1] = true;
            img.sprite = heads[1];

        }
    }
}
