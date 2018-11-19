using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThoughtText : MonoBehaviour {

    public Text thought;
    public Node head;
    public Node current;
    public Node tail;

    public AudioSource aS;
    private void Start()
    {
        Node startNode = new Node();
        head = startNode;
        current = startNode;
        tail = startNode;
    }
    void Update ()
    {
        if(current != tail && thought.text == "")
        {
            next();
            StartCoroutine(thoughtTime(current));
        }
	}

    public bool hasNext(Node node)
    {
        if(node.nextNode == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void next()
    {
        current = current.nextNode;
    }
    public void add(Node newNode)
    {
        tail.nextNode = newNode;
        tail = newNode;
    }
    private void OnTriggerEnter2D (Collider2D other)
    {
        //sets text based on hitting certain areas 
        //such as store entrance
        if (other.gameObject.GetComponent<ThoughtZone>() != null && !GameManager.thinking)
        {
            Node nextThought = new Node();
            nextThought.thoughts = other.GetComponent<ThoughtZone>().thought;
            nextThought.thoughtTime = other.gameObject.GetComponent<ThoughtZone>().thoughtTime;
            nextThought.voiceLine = other.gameObject.GetComponent<ThoughtZone>().voiceLine;
            add(nextThought);
            Destroy(other.gameObject);
        }
        
    }
    //Text always stays for set amount of time
    //so that people can read it
    IEnumerator thoughtTime(Node thoughtNode)
    {
        thought.text = thoughtNode.thoughts;
        if (thoughtNode.voiceLine != null)
        {
            aS.PlayOneShot(thoughtNode.voiceLine);
        }
        yield return new WaitForSecondsRealtime(thoughtNode.thoughtTime);
        if(hasNext(current))
        {
            StartCoroutine(thoughtTime(thoughtNode.nextNode));
            next();
        }
        else
        {
            thought.text = "";
        }
    }

}

public class Node
{
    public string thoughts;
    public float thoughtTime;
    public AudioClip voiceLine;
    public Node nextNode;

    public Node()
    {

    }
    public Node(string text, int num)
    {
        thoughts = text;
        thoughtTime = num;
    }
    public Node(string text, int num, AudioClip line)
    {
        thoughts = text;
        thoughtTime = num;
        voiceLine = line;
    }
}