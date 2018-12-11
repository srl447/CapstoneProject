using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public float time;
    public float stallTime;
    public Vector3 dir;
    Quaternion facing, facing2;
	// Use this for initialization
	void Start ()
    {
        facing = this.transform.rotation;
        facing2 = this.transform.rotation * new Quaternion(0, 0, 1, 0);
        StartCoroutine(SwitchDir());
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        this.GetComponent<Rigidbody2D>().MovePosition(transform.position+dir);
        //this.transform.rotation = Quaternion.AngleAxis(transform.rotation.z, dir);
	}

    public IEnumerator SwitchDir()
    {
        yield return new WaitForSecondsRealtime(time);
        Vector3 nextDir = dir * -1;
        dir = new Vector3(0,0,0);
        yield return new WaitForSecondsRealtime(stallTime);
        if(this.transform.rotation == facing)
        {
            this.transform.rotation= facing2;
        }
        else
        {
            this.transform.rotation = facing;
        }
        dir = nextDir;
        StartCoroutine(SwitchDir());
    }
}
