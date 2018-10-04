using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThoughtText : MonoBehaviour {

    public Text thought;
    public string currentThought;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        thought.text = currentThought;
		
	}

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.GetComponent<ThoughtZone>() != null && !GameManager.thinking)
        {
            currentThought = other.GetComponent<ThoughtZone>().thought;
            GameManager.thinking = true;
            StartCoroutine(thoughtTime(other.gameObject.GetComponent<ThoughtZone>().thoughtTime, other.gameObject));
        }
        
    }

    IEnumerator thoughtTime(float time, GameObject thoughtTrigger)
    {
        yield return new WaitForSecondsRealtime(time);
        currentThought = "";
        Destroy(thoughtTrigger);
        GameManager.thinking = false;
    }

}
