using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllShoppersLook : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AnxietyZone1")
        {
            if (collision.GetComponent<AreaShopperList>() != null)
            {
                foreach (GameObject e in collision.GetComponent<AreaShopperList>().enemies)
                {
                    if (e.GetComponent<EnemyStare>())
                    {
                        e.GetComponent<EnemyStare>().CollisionOccurence();
                        e.GetComponent<EnemyStare>().StareWait(3f);
                    }
                }
            }

        }
    }
}
