using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlocks : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D nesne) // when player collide with enemy
    {
        if (nesne.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("breakSound");
            Debug.Log("karsucum");
            gameObject.SetActive(false);
        }

    }
}////////////
