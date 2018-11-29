using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveryerBeltScroller : MonoBehaviour {
    public float scrollSpeed;
    private Vector2 savedOffset;

    void Start()
    {
        savedOffset = GetComponent<Renderer>().sharedMaterial.GetTextureOffset("_MainTex");
    }

    void Update()
    {
        float y = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(-y, savedOffset.x);
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    void OnDisable()
    {
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }
}
