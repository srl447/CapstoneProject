using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public float time;
    public float stallTime;
    public Vector3 dir;
	// Use this for initialization
	void Awake ()
    {
        StartCoroutine(SwitchDir());
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        this.GetComponent<Rigidbody2D>().MovePosition(transform.position+dir);
	}

    IEnumerator SwitchDir()
    {
        yield return new WaitForSecondsRealtime(time);
        Vector3 nextDir = dir * -1;
        dir = new Vector3(0,0,0);
        yield return new WaitForSecondsRealtime(stallTime);
        transform.eulerAngles = transform.eulerAngles + new Vector3(0,0,180f);
        dir = nextDir;
        StartCoroutine(SwitchDir());
    }
}
