using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Leaving : MonoBehaviour {

    public PickupClothes pC;
    ThoughtText tT;
    GetSpotted gS;

    bool start;
    public Image fade;
    public Text text;

    int timer = 0;

    // Use this for initialization
    void Start () {
        tT = GetComponent<ThoughtText>();
        gS = GetComponent<GetSpotted>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(start)
        {
            GetComponent<ThoughtText>().enabled = false;
            if (fade.color.a < 1)
            {
                fade.color = new Color(0, 0, 0, fade.color.a + .05f * 2);
            }
            if (timer <= 220)
            {
                text.text = "I guess I can always come back another day...";
                if (text.color.a < 1)
                    text.color = new Color(255, 255, 255, (text.color.a + .05f) * 2);
                timer++;
            }
            else if (timer <= 240)
            {
                text.color = new Color(255, 255, 255, (text.color.a) / 2);
                timer++;
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if they leave and haev purchased clothes
        if (collision.gameObject.tag == "Exit" && pC.purchased == true)
        {
            foreach (GameObject g in GameManager.clothes)
            {
                DontDestroyOnLoad(g);
            }
            StartCoroutine(FadeLeave());
        }
        else if (collision.gameObject.tag == "Exit" && gS.anx > 1.5)
        {
            SceneManager.LoadScene(0);
        }
        else if (collision.gameObject.tag == "Exit" && pC.purchased == false && GameManager.clothes.Count > 0)
        {
            Node dontLeave = new Node();
            dontLeave.thoughts = "I'm not letting myself leave until I purchase some clothes!";
            dontLeave.thoughtTime = 2;
            tT.add(dontLeave);
        }
        else if (collision.gameObject.tag == "Exit" && pC.purchased == false)
        {
            start = true;
        }
    }

    IEnumerator FadeLeave()
    {
        yield return new WaitForEndOfFrame();
        for(;fade.color.a < 1;)
        {
            fade.color = new Color(0, 0, 0, fade.color.a + .05f * 2);
            yield return new WaitForEndOfFrame();
        }
        SceneManager.LoadScene(1);
    }
}
