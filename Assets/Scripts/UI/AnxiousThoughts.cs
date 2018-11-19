using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnxiousThoughts : MonoBehaviour {

    public GetSpotted gS;
    PickupClothes pC;
    public ThoughtText tT;
    public bool[] thoughts = new bool[1];
    public Image img;
    public Sprite[] heads;
    public AudioClip[] lines;
	// Use this for initialization
	void Start ()
    {
        pC = GetComponent<PickupClothes>();
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
            newThought.voiceLine = lines[0];
            tT.add(newThought);
            thoughts[0] = true;
            img.sprite = heads[0];

        }
        if (gS.anx > .3 && !thoughts[1])
        {
            Node newThought = new Node();
            newThought.thoughts = "Fuckkk people are staring at me";
            newThought.thoughtTime = 2;
            newThought.voiceLine = lines[1];
            tT.add(newThought);
            thoughts[1] = true;
            img.sprite = heads[1];

        }
        if (gS.anx > .6 && !thoughts[2])
        {
            Node newThought = new Node();
            newThought.thoughts = "I hate this, I hate this, I hate this";
            newThought.voiceLine = lines[2];
            newThought.thoughtTime = 2;
            tT.add(newThought);
            thoughts[2] = true;
            img.sprite = heads[2];

        }
        if (gS.anx > .8 && ! thoughts[4])
        {
            Node newThought= new Node("You need to stay calm Kril, pretend like no one's around", 4,lines[4]);
            tT.add(newThought);
            thoughts[4] = true;
            img.sprite = heads[4];
        }
        if(gS.anx > 1.4 && !thoughts[3])
        {
            Node badEnd = new Node("I can't take this anymore. I can barely think. I have to get out!", 3, lines[3]);
            tT.add(badEnd);
            thoughts[3] = true;
            pC.enabled = false;
            img.sprite = heads[3];
        }
    }
}
