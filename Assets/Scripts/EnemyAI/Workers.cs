using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workers : MonoBehaviour {

    public GameObject[] points;
    int pointIndex;

    public float speed;
	// Use this for initialization
	void Start () {
        pointIndex = 0;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        Vector3 dir = points[pointIndex].transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if(Mathf.Floor(transform.position.x) == Mathf.Floor(points[pointIndex].transform.position.x) && Mathf.Floor(transform.position.y) == Mathf.Floor(points[pointIndex].transform.position.y))
        {
            pointIndex++;
            if(pointIndex >= points.Length)
            {
                pointIndex = 0;
            }
        }
        
	}
}
