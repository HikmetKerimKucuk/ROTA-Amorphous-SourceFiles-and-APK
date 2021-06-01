using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SagittariusArrow : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    bool has_hit;

    //Enemy_entitiy_features eef_class;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        if (has_hit == false)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }
    void OnCollisionStay2D(Collision2D nesne) // when player collide with enemy
    {
        if (nesne.gameObject.tag == "Enemy_x")
        {
            has_hit = true;
            Vector2 last = rb.position;
            rb.velocity = Vector2.zero;
            Invoke("destroy_arrow", 0.55f);
            //rb.isKinematic = true;

        }
    }

    void OnCollisionEnter2D(Collision2D nesne) // when player collide with enemy
    {

        if (nesne.gameObject.tag == "dungeontilemap")
        {
            Invoke("destroy_arrow", 0.55f);
            has_hit = true;
        }

        if (nesne.gameObject.tag == "bats")
        {
            Invoke("destroy_arrow", 0.0f);
            has_hit = true;
        }
        if (nesne.gameObject.tag == "Golem" || nesne.gameObject.tag == "golemit")
        {
            Invoke("destroy_arrow", 0.0f);
            has_hit = true;
        }
        if (nesne.gameObject.tag == "Pafkrav")
        {
            Invoke("destroy_arrow", 0.0f);
            has_hit = true;
        }
        if (nesne.gameObject.tag == "starguard")
        {
            Invoke("destroy_arrow", 0.0f);
            has_hit = true;
        }
        if (nesne.gameObject.tag == "meleechaser")
        {
            Invoke("destroy_arrow", 0.0f);
            has_hit = true;
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        has_hit = true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
    }*/
    void destroy_arrow()
    {
        //GameObject.FindGameObjectWithTag("arrow");
        //Destroy(GameObject.FindGameObjectWithTag("arrow"));
        Destroy(gameObject);
    }









    /*if (bm.Android_or_Windows == 0 ) //Android 
    {

    }
    
    else if (bm.Android_or_Windows == 1 ) //Windows
    {

    }*/



}///////
