using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsText : MonoBehaviour {

    public Image panel, image1, image2; 
    public Text text1, text2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(fade());
        }
	
	}

    IEnumerator fade()
    {
        yield return new WaitForSeconds(.2f);
        for(; image1.color.a > 0;)
        {
            image1.color = new Color(image1.color.r, image1.color.g, image1.color.b, image1.color.a - .1f);
            image2.color = new Color(image2.color.r, image2.color.g, image2.color.b, image2.color.a - .1f);
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, panel.color.a - .1f);
            text1.color = new Color(text1.color.r, text1.color.g, text1.color.b, text1.color.a - .1f);
            yield return new WaitForEndOfFrame();
        }
        Destroy(this.gameObject);
    }
}
