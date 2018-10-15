using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaShopperList : MonoBehaviour {

    public GameObject [] enemies;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Here");
            foreach(GameObject e in enemies)
            {
                e.GetComponent<EnemyStare>().CollisionOccurence();
                e.GetComponent<EnemyStare>().StareWait(3f);
            }

        }
    }*/
}
