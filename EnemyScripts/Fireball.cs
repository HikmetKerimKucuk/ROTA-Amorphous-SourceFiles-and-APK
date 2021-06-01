using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    bool has_hit;
    public float fireball_damage;
    //move_trial aef_class;
    bool give_dmg;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fireball_damage = 15;
        give_dmg = true;
        //aef_class = GameObject.FindGameObjectWithTag("Player").GetComponent<move_trial>();
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

    /*void OnCollisionStay2D(Collision2D nesne) // when player collide with enemy
    {
        if (nesne.gameObject.tag == "Enemy_x")
        {
            has_hit = true;
            Vector2 last = rb.position;
            rb.velocity = Vector2.zero;
            Invoke("destroy_arrow", 0.55f);
            //rb.isKinematic = true;

        }
    }*/
    /*void OnCollisionEnter2D(Collision2D nesne) // when player collide with enemy
    {

        if (nesne.gameObject.tag == "level_side")
        {
            Invoke("destroy_arrow", 0.2f);
            has_hit = true;
        }
        if (nesne.gameObject.tag == "Player")
        {
            if (give_dmg == true)
            {
                Debug.Log("arujooya çarptı");
                Invoke("destroy_arrow", 0.2f);
                aef_class.get_damage(fireball_damage);

            }
            
        }
    }*/

    /*void OnCollisionStay2D(Collision2D nesne) // when player collide with enemy
    {
        if (nesne.gameObject.tag == "Player")
        {
            Debug.Log("arujooya çarptı");
            //Invoke("destroy_arrow", 0.2f);
            //aef_class.get_damage(fireball_damage);
            has_hit = true;
            give_dmg = false;
            // Debug.Log("arujooya çarptı");
            //  Invoke("destroy_arrow", 0.2f);
            // aef_class.get_damage(fireball_damage); // GERİ AÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇ
            //aef_class.transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.black;
        }
    }*/
    void OnTriggerEnter2D(Collider2D nesne) // when player enter the field
    {

        if (nesne.gameObject.tag == "Player")
        {
            Debug.Log("arujooya çarptı");
            Destroy(gameObject);
            //destroyFireball();
            //Invoke("destroy_arrow", 0.001f);
            //aef_class.get_damage(fireball_damage); /// HASAAAAAAAAAAAAAĞRRRRRRRRRRRRRRRYOOOOOOOOOOOOOOOĞĞĞĞ
            //Destroy(GameObject.FindGameObjectWithTag("fireball"));

        }

        if (nesne.gameObject.tag == "dungeontilemap")
        {
            Destroy(gameObject);
            //Invoke("destroy_arrow", 0.001f);
            //aef_class.get_damage(fireball_damage); /// HASAAAAAAAAAAAAAĞRRRRRRRRRRRRRRRYOOOOOOOOOOOOOOOĞĞĞĞ
            //Destroy(GameObject.FindGameObjectWithTag("fireball"));

        }



    }
    /*void OnTriggerStay2D(Collider2D nesne) // when player enter the field
    {

        if (nesne.gameObject.tag == "Arujo")
        {

            Destroy(GameObject.FindGameObjectWithTag("fireball"));

        }

    }*/

    void destroyFireball()
    {
        //GameObject.FindGameObjectWithTag("arrow");
        Destroy(gameObject);
    }
}//////
