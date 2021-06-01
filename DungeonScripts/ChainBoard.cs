using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainBoard : MonoBehaviour
{
    public GameObject leftChain;
    public GameObject rightChain;
    public Rigidbody2D rb;
    public Collider2D leftchainColl;
    public Collider2D rightchainColl;

    int blue;
    int green;
    float m_Saturation;
    bool reddish;

    public float leftChainEnduranceScore;
    public float rightChainEnduranceScore;


    Pafkrav pf;
    void Start()
    {
        pf = GameObject.FindGameObjectWithTag("Pafkrav").GetComponent<Pafkrav>();

        reddish = false;
        rightChainEnduranceScore = 200;
        leftChainEnduranceScore = 200;
        blue = 255;
        green = 255;
        rb.bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    void Update()
    {
        if (!leftChain.activeInHierarchy && !rightChain.activeInHierarchy)
        {
            whenchainsbreaks();
        }

        if (reddish == true)
        {
            if (blue > 0 && green > 0)
            {
                reddish = false;
                Invoke("makereddish", 0.3f);
                //leftChain.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, green, blue, 255);
            }
        }
        ChainHide();
        //leftChain.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, green, blue,255);
    }

    public void whenchainsbreaks()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        pf.focus_on_target();
        pf.stop_and_fire = true;
        pf.is_triggered = true;
        pf.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
    public void ChainHide()
    {
        if (rightChainEnduranceScore <=0 )
        {
            rightChain.SetActive(false);
        }
        if (leftChainEnduranceScore <= 0)
        {
            leftChain.SetActive(false);
            //Destroy(leftChain.gameObject);

        }
    }




    void OnTriggerEnter2D(Collider2D other)
    {
        
            if (rightchainColl.IsTouching(other))
            {
                if (other.gameObject.tag == "blade")
                {
                    rightChainEnduranceScore = rightChainEnduranceScore - 50f;
                    FindObjectOfType<AudioManager>().Play("chainHit");
                }

                if (other.gameObject.tag == "pisces")
                {
                    rightChainEnduranceScore = rightChainEnduranceScore - 20f;
                    FindObjectOfType<AudioManager>().Play("chainHit");
                }
                if (other.gameObject.tag == "arrow")
                {
                    rightChainEnduranceScore = rightChainEnduranceScore - 50f;
                    FindObjectOfType<AudioManager>().Play("chainHit");
                }
                if (other.gameObject.tag == "taurus")
                {
                    rightChainEnduranceScore = rightChainEnduranceScore - 250f;
                    FindObjectOfType<AudioManager>().Play("chainHit");
                }

                /*if (other.gameObject.tag == "Player")
                {
                    rightChain.SetActive(false);
                }*/

            }
        if (leftchainColl.IsTouching(other))
        {
            /*if (other.gameObject.tag == "blade")
            {
                leftChainEnduranceScore = leftChainEnduranceScore - 50f;

            }

            if (other.gameObject.tag == "pisces")
            {
                leftChainEnduranceScore = leftChainEnduranceScore - 20f;
            }
            if (other.gameObject.tag == "arrow")
            {
                leftChainEnduranceScore = leftChainEnduranceScore - 50f;
            }
            if (other.gameObject.tag == "taurus")
            {
                Debug.Log("sibel go brr");
                leftChainEnduranceScore = leftChainEnduranceScore - 250f;
            }
            */
            if (other.gameObject.tag == "blade")
            {
                leftChainEnduranceScore = leftChainEnduranceScore - 50f;
                FindObjectOfType<AudioManager>().Play("chainHit");
            }

            if (other.gameObject.tag == "pisces")
            {
                leftChainEnduranceScore = leftChainEnduranceScore - 20f;
                FindObjectOfType<AudioManager>().Play("chainHit");
            }
            if (other.gameObject.tag == "arrow")
            {
                leftChainEnduranceScore = leftChainEnduranceScore - 50f;
                FindObjectOfType<AudioManager>().Play("chainHit");
            }
            if (other.gameObject.tag == "taurus")
            {
                leftChainEnduranceScore = leftChainEnduranceScore - 250f;
                FindObjectOfType<AudioManager>().Play("chainHit");
            }
            /*if (other.gameObject.tag == "Player")
            {
                rightChain.SetActive(false);
            }*/

        }



    }

    void OnCollisionEnter2D(Collision2D other) // when player collide with enemy
    {
        if (other.gameObject.tag == "taurus")
        {
            rightChainEnduranceScore = rightChainEnduranceScore - 250f;
            FindObjectOfType<AudioManager>().Play("chainHit");
        }

        /*if (other.gameObject.tag == "arrow")
        {
            leftChainEnduranceScore = leftChainEnduranceScore - 50f;
        }
        if (other.gameObject.tag == "taurus")
        {
            leftChainEnduranceScore = leftChainEnduranceScore - 250f;
        }


    if (other.gameObject.tag == "taurus")
        {
            rightChainEnduranceScore = rightChainEnduranceScore - 250f;
        }

        if (other.gameObject.tag == "arrow")
        {
            rightChainEnduranceScore = rightChainEnduranceScore - 50f;
        }
        if (other.gameObject.tag == "taurus")
        {
            rightChainEnduranceScore = rightChainEnduranceScore - 250f;
        }*/






        //

    }

    public void makereddish()
    {
        blue = blue - 30;
        green = green - 30;
        //reddish = true;
        leftChain.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, green, blue, 255);

    }


}/////////
