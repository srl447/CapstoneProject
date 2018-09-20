using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour {

    public float rotateSpeed;
	// Use this for initialization
	void Start () {
        StartCoroutine(RotateTimer());
	}
	
	// Update is called once per frame
	void Update () {

        transform.eulerAngles += new Vector3(0,0,rotateSpeed);
		
	}

    IEnumerator RotateTimer()
    {
        yield return new WaitForSecondsRealtime(3);
        rotateSpeed = rotateSpeed * -1;
        StartCoroutine(RotateTimer());

    }
}
