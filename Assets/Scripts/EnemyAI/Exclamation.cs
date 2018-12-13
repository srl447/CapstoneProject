using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exclamation : MonoBehaviour {

    public AudioClip sound1, sound2, sound3;
    public AudioSource aud;
	// Use this for initialization
	void Awake () {
        StartCoroutine(Squash());
        switch ((int) Mathf.Floor(Random.Range(1,4)))
        {
            case 1:
                aud.PlayOneShot(sound1, 2);
                break;
            case 2:
                aud.PlayOneShot(sound2, 2);
                break;
            case 3:
                aud.PlayOneShot(sound3, 2);
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(transform.position.y);
	}

    IEnumerator Squash()
    {
        for (int i = 0; i < 14; i++)
        {
            yield return new WaitForEndOfFrame();
        }
        float yPos = transform.position.y;
        for (int i = 0;i<7;i++)
        {
            yield return new WaitForEndOfFrame();
            transform.localScale = new Vector3(Mathf.Lerp(transform.localScale.x, 2, .5f), Mathf.Lerp(transform.localScale.y, .5f, .5f), transform.localScale.z);
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, yPos - .25f, .5f), transform.position.z);
        }
        for (int i = 0; i < 9; i++)
        {
            yield return new WaitForEndOfFrame();
            transform.localScale = new Vector3(Mathf.Lerp(transform.localScale.x, .333334f, .5f), Mathf.Lerp(transform.localScale.y, 3, .5f), transform.localScale.z);
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, yPos + 1.25f, .5f), transform.position.z);
        }
        Destroy(gameObject);
    }
}
