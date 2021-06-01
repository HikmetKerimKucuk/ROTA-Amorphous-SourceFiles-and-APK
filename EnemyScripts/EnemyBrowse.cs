using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrowse : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    PlayerEntity pe;

    public bool findAnyEnemy;
    public bool startFunction;
    void Start()
    {
        findAnyEnemy = false;
        pe = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEntity>();
        //this.gameObject.GetComponent<CircleCollider2D>().radius=
    }

    // Update is called once per frame
    void Update()
    {
        if (startFunction == true)
        {
            if (this.gameObject.GetComponent<CircleCollider2D>().radius <= 11)
            {
                this.gameObject.GetComponent<CircleCollider2D>().radius += 0.8f;
            }
        }
        if (this.gameObject.GetComponent<CircleCollider2D>().radius >= 11)
        {
            target = pe.gameObject.transform;
            this.gameObject.GetComponent<CircleCollider2D>().radius = 1;
            //Invoke("recallSound", 0.3f);
            //recallSound();

            findAnyEnemy = true;
            startFunction = false;
        }
    }

    public void BrowseEnemy()
    {
        findAnyEnemy = false;
        startFunction = true;
        
        
    }

    void recallSound()
    {
        //Invoke("recallSound", 0.6f);
        if (findAnyEnemy == false)
        {
            FindObjectOfType<AudioManager>().Play("piscesRecall");
        }
        
    }

    void OnTriggerEnter2D(Collider2D nesne) // when player enter the field
    {
        if (findAnyEnemy == false)
        {
            if (nesne.gameObject.tag == "Golem")
            {
                target = nesne.gameObject.transform;
                this.gameObject.GetComponent<CircleCollider2D>().radius = 1;
                findAnyEnemy = true;
                startFunction = false;
            }

            else if (nesne.gameObject.tag == "bats")
            {
                target = nesne.gameObject.transform;
                this.gameObject.GetComponent<CircleCollider2D>().radius = 1;
                findAnyEnemy = true;
                startFunction = false;
            }

            else if (nesne.gameObject.tag == "Pafkrav")
            {
                target = nesne.gameObject.transform;
                this.gameObject.GetComponent<CircleCollider2D>().radius = 1;
                findAnyEnemy = true;
                startFunction = false;
            }

            else if (nesne.gameObject.tag == "meleechaser")
            {
                target = nesne.gameObject.transform;
                this.gameObject.GetComponent<CircleCollider2D>().radius = 1;
                findAnyEnemy = true;
                startFunction = false;
            }

            else if (nesne.gameObject.tag == "starguard")
            {
                target = nesne.gameObject.transform;
                this.gameObject.GetComponent<CircleCollider2D>().radius = 1;
                findAnyEnemy = true;
                startFunction = false;
            }


            /*else 
            {
                target = pe.gameObject.transform;
                this.gameObject.GetComponent<CircleCollider2D>().radius = 1;
                findAnyEnemy = true;
                startFunction = false;
            }*/
        }
        



    }



}///////////
