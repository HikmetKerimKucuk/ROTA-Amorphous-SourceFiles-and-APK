using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnvisibleSpikes : MonoBehaviour
{
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = transform.gameObject.GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D nesne)
    {

        if (nesne.gameObject.tag == "Player")
        {
            sr.enabled = true;
            FindObjectOfType<AudioManager>().Play("unvisiblespike");
        }
    }

}//////
