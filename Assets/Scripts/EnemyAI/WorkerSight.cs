using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerSight : MonoBehaviour {

    public GameObject topUI;
    public Text helpText;
    public ThoughtText tT;
    public Workers work;

    bool canTalk = true;

    public RectTransform loc;

    public AudioClip[] tessLines, workLines;
    AudioSource aud;
	// Use this for initialization
	void Start ()
    {
        aud = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && canTalk)
        {
            collision.gameObject.GetComponent<Movement>().up = false;
            collision.gameObject.GetComponent<Movement>().left = false;
            collision.gameObject.GetComponent<Movement>().down = false;
            collision.gameObject.GetComponent<Movement>().right = false;
            collision.gameObject.GetComponent<Movement>().walking = false;
            collision.gameObject.GetComponent<Movement>().enabled = false;
            topUI.SetActive(true);
            work.enabled = false;
            StartCoroutine(Convo(collision.gameObject));
            canTalk = false;
        }
    }

    IEnumerator Convo(GameObject player)
    {
        Vector3 oldPos = topUI.GetComponent<RectTransform>().position;
        for (int i = 0; i < 8; i++)
        {
            yield return new WaitForEndOfFrame();
            topUI.GetComponent<RectTransform>().position = new Vector3(topUI.GetComponent<RectTransform>().position.x, Mathf.Lerp(topUI.GetComponent<RectTransform>().position.y, loc.position.y, .1f), topUI.GetComponent<RectTransform>().position.z);

        }
        for (; tT.current.nextNode != null;)
        {
            yield return new WaitForEndOfFrame();
        }
        tT.add(new Node(" ", .2f));
        tT.add(new Node("nothing im fine", 1.4f, tessLines[0]));
        tT.add(new Node(" ", 4));
        tT.add(new Node("   thanks.", 1, tessLines[1]));
        tT.add(new Node(" ", 1));
        yield return new WaitForEndOfFrame();
        Vector3 dir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
        transform.parent.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        helpText.text = "Hello Sir! Can I help you at all today?";
        aud.PlayOneShot(workLines[0]);
        yield return new WaitForSecondsRealtime(2);
        helpText.text = "";
        yield return new WaitForSecondsRealtime(1.4f);
        helpText.text = "The man's section on the right. You shouldn't care about the rest.";
        aud.PlayOneShot(workLines[1]);
        yield return new WaitForSecondsRealtime(2);
        helpText.text = "Fitting Rooms and Bathrooms are in the back";
        aud.PlayOneShot(workLines[2]);
        yield return new WaitForSecondsRealtime(2);
        helpText.text = "";
        yield return new WaitForSecondsRealtime(1);
        helpText.text = "If you need anything else, just ask...";
        aud.PlayOneShot(workLines[3]);
        yield return new WaitForSecondsRealtime(1);
        for (int i = 0; i < 8; i++)
        {
            yield return new WaitForEndOfFrame();
            topUI.GetComponent<RectTransform>().position = new Vector3(topUI.GetComponent<RectTransform>().position.x, Mathf.Lerp(topUI.GetComponent<RectTransform>().position.y, oldPos.y, .1f), topUI.GetComponent<RectTransform>().position.z);

        }
        player.gameObject.GetComponent<Movement>().enabled = true;
        topUI.SetActive(false);
        work.enabled = true;

        yield return new WaitForSecondsRealtime(3);
        canTalk = true;
    }
}
