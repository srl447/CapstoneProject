using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerSight : MonoBehaviour {

    public GameObject topUI;
    public Text helpText;
    public ThoughtText tT;
    public Workers work;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Movement>().up = false;
            collision.gameObject.GetComponent<Movement>().left = false;
            collision.gameObject.GetComponent<Movement>().down = false;
            collision.gameObject.GetComponent<Movement>().right = false;
            collision.gameObject.GetComponent<Movement>().enabled = false;
            topUI.SetActive(true);
            work.enabled = false;
            StartCoroutine(Convo(collision.gameObject));
            tT.add(new Node("", 3));
            tT.add(new Node("nothing im fine", 1.4f));
            tT.add(new Node("", 3));
        }
    }

    IEnumerator Convo(GameObject player)
    {
        yield return new WaitForEndOfFrame();
        Vector3 dir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
        transform.parent.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        helpText.text = "Hello Sir! Can I help you at all today?";
        yield return new WaitForSecondsRealtime(3);
        helpText.text = "";
        yield return new WaitForSecondsRealtime(3);
        player.gameObject.GetComponent<Movement>().enabled = true;
        topUI.SetActive(false);
        work.enabled = true;

    }
}
