using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffBlocks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void disappearFunction()
    {
        this.gameObject.SetActive(false);
    }
    public void appearFunction()
    {
        this.gameObject.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D nesne)
    {

        if (nesne.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("triggerBlock");
            Debug.Log("playere değdim");
            Invoke("disappearFunction", 0.5f);
            Invoke("appearFunction", 4f);

        }
    }
}////////////
