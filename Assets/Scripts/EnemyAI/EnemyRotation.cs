using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour {

    public float rotateSpeed;
    public float rotateTime;
    public float pauseTime;
	// Use this for initialization
	void Start () {
        StartCoroutine(RotateTimer());
	}
	
	// Update is called once per frame
	void Update () {

        transform.eulerAngles += new Vector3(0,0,rotateSpeed);
		
	}

    public IEnumerator RotateTimer()
    {
        yield return new WaitForSecondsRealtime(rotateTime);
        float NextRotateSpeed = rotateSpeed * -1;
        rotateSpeed = 0;
        yield return new WaitForSecondsRealtime(pauseTime);
        rotateSpeed = NextRotateSpeed;
        StartCoroutine(RotateTimer());

    }
}
