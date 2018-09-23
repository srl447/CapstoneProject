using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHand : MonoBehaviour
{

    public GameObject clothesScreen;
    public Movement playerMovement;
    public float handSpeed;
    ArrayList clothes = new ArrayList();
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + handSpeed, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - handSpeed, transform.position.y, transform.position.z);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            clothes.Add(collision.gameObject.GetComponent<ClothType>().clothType);
            clothesScreen.SetActive(false);
            playerMovement.enabled = true;
        }
    }
}
