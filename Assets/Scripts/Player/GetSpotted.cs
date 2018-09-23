using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSpotted : MonoBehaviour {

    SpriteRenderer sR;
    public float enemyPow;
    public float aZ1Pow;
	// Use this for initialization
	void Start ()
    {
        sR = GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void Update ()
    {
		if(sR.color.r <= 0)
        {
            Debug.Log("Max Blue");
        }
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemySight")
        {
            sR.color = new Color(sR.color.r - enemyPow , sR.color.g - enemyPow ,sR.color.b);
        }
        if (collision.gameObject.tag == "AnxietyZone1")
        {
            sR.color = new Color(sR.color.r - aZ1Pow, sR.color.g - aZ1Pow, sR.color.b);
        }
    }
}
