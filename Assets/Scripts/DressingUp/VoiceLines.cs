using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceLines : MonoBehaviour
{

    public AudioClip bandana, jeans, leggings, splatter, ugly, romper, uglyW, basicOkay, cute, skirt;
    public AudioSource aud;
    bool[] played = { false, false, false, false, false, false, false, false, false, false, false };

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ClothType>() != null)
        {
            ClothType name = collision.gameObject.GetComponent<ClothType>();
            if (name.clothType == "Bandana" && !played[0])
            {
                aud.PlayOneShot(bandana);
                played[0] = true;
                return;
            }
            if (name.clothType == "Jeans" && !played[1])
            {
                aud.PlayOneShot(jeans);
                played[1] = true;
                return;
            }
            if (name.clothType == "Leggings" && !played[2])
            {
                aud.PlayOneShot(leggings);
                played[2] = true;
                return;
            }
            if (name.clothType == "Splatter Dress" && !played[3])
            {
                aud.PlayOneShot(splatter);
                played[3] = true;
                return;
            }
            if (name.clothType == "Ugly" && !played[4])
            {
                aud.PlayOneShot(ugly);
                played[4] = true;
                return;
            }
            if (name.clothType == "Romper" && !played[5])
            {
                aud.PlayOneShot(romper);
                played[5] = true;
                return;
            }
            if (name.clothType == "UglyW" && !played[6])
            {
                aud.PlayOneShot(uglyW);
                played[6] = true;
                return;
            }
            if (name.clothType == "Shirt" && !played[7])
            {
                aud.PlayOneShot(basicOkay);
                played[7] = true;
                return;
            }
            if (name.clothType == "Cute" && !played[8])
            {
                aud.PlayOneShot(cute);
                played[8] = true;
                return;
            }
            if (name.clothType == "Skirt" && !played[9])
            {
                aud.PlayOneShot(skirt);
                played[9] = true;
                return;
            }
        }
    }

}
