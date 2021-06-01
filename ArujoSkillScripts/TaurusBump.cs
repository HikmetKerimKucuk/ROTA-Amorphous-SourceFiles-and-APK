using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaurusBump : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    bool has_hit;
    float alpha_counter;
    public float bump_force;
    public float get_ready_time;
    public float bumping_damage;
    //public bool is_available_taurus_skill;

    //Basic_movement_code bmc_class;
    TaurusSkill tmc;
    public Animator anim;
    //Enemy_entitiy_features eef_class;
    void Start()
    {
        //is_available_taurus_skill = true;
        rb = GetComponent<Rigidbody2D>();
        alpha_counter = 0;
        //transform.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha_counter);
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha_counter);
        //bmc_class = GameObject.FindGameObjectWithTag("Player").GetComponent<Basic_movement_code>();
        tmc = GameObject.FindGameObjectWithTag("Player").GetComponent<TaurusSkill>();
        //eef_class = GameObject.FindGameObjectWithTag("Enemy_x").GetComponent<Enemy_entitiy_features>();
        Destroy(gameObject, 7f);


    }
    // Update is called once per frame
    void Update()
    {
        taurus_skill_function();
    }

    public void taurus_skill_function()
    {
        Invoke("alpha_adding", 0.1f);
        /*for (int i = 0; i < 1000; i++)
        {
            transform.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha_counter);
            alpha_counter = alpha_counter + 0.005f;
        }*/

        //transform.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha_counter);
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha_counter);
    }

    public void alpha_adding()
    {
        alpha_counter = alpha_counter + get_ready_time;
        if (alpha_counter < 1)
        {
            alpha_counter = alpha_counter + get_ready_time;
            taurus_dash_function();
            //Debug.Log("1denkucuk" + alpha_counter);
        }
        else
        {
            taurus_dash_function();
            // Debug.Log("1den BUYUK");
        }
    }

    public void taurus_dash_function()
    {
        if (tmc.taurus_direction == 1)
        {

            if (alpha_counter < 1)
            {
                rb.velocity = Vector2.left * bump_force / 50;
            }
            else if (alpha_counter == 1)
            {
                rb.velocity = Vector2.zero;
            }
            else if (alpha_counter > 1)
            {
                rb.velocity = Vector2.right * bump_force;
            }
        }

        else if (tmc.taurus_direction == -1)
        {
            if (alpha_counter < 1)
            {
                rb.velocity = Vector2.right * bump_force / 50;
                Debug.Log(" dashhhhhhhhhhhhhhhhhf");
            }
            else if (alpha_counter == 1)
            {
                rb.velocity = Vector2.zero;
            }
            else if (alpha_counter > 1)
            {
                rb.velocity = Vector2.left * bump_force;
            }
        }

    }

    void OnCollisionEnter2D(Collision2D nesne) // when player collide with enemy
    {

        if (nesne.gameObject.tag == "Golem" || nesne.gameObject.tag == "golemit")
        {
            if (alpha_counter > 1)
            {
                Invoke("CancelCollider", 0.1f);
            }
                
            //bumping_damage = 400;
            //Debug.Log("carptım susmana");
            //eef_class.get_damage(bumping_damage);// DÜŞMAN HASARI

        }

        if (nesne.gameObject.tag == "bats")
        {
            if (alpha_counter > 1)
            {
                Invoke("CancelCollider", 0.1f);
            }
        }

        if (nesne.gameObject.tag == "starguard")
        {
            if (alpha_counter > 1)
            {
                Invoke("CancelCollider", 0.1f);
            }
        }
        if (nesne.gameObject.tag == "pafkrav")
        {
            if (alpha_counter > 1)
            {
                Invoke("CancelCollider", 0.1f);
            }
        }
        if (nesne.gameObject.tag == "meleechaser")
        {
            if (alpha_counter > 1)
            {
                Invoke("CancelCollider", 0.1f);
            }
        }


    }

    void CancelCollider()
    {
        transform.gameObject.GetComponent<CapsuleCollider2D>().isTrigger = true;
        transform.gameObject.GetComponent<CapsuleCollider2D>().gameObject.SetActive(false);
    }

}////

