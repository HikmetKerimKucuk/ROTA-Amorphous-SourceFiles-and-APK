using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemitsZone : MonoBehaviour
{
    public Animator anim;
    public bool is_triggered = false;
    public bool new_fire_permission = true;
    public bool Arujo_is_in_damage_zone = false;

    float quake_frequency = 0;

    //move_trial aef;
    Golemits bgc;

    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("idle", false);
        anim.SetBool("move", true);
        anim.SetBool("attack", false);

        bgc = GameObject.FindGameObjectWithTag("golemit").GetComponent<Golemits>();
        //aef = GameObject.FindGameObjectWithTag("Player").GetComponent<move_trial>();
        quake_frequency = 2f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D nesne) // when player enter the field
    {
        if (is_triggered == false)
        {
            if (nesne.gameObject.tag == "Player")
            {
                Debug.Log("arujoyu gordum");
                Arujo_is_in_damage_zone = true;
                bgc.focus_on_target();
                //pc_class.transform.localScale = new Vector3(-1 * aef.transform.localScale.x, 1, 1);
                //pc_class.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                bgc.is_damage_area_trigerred = true;
                is_triggered = true;
                //pc_class.Throw_a_fireball();
            }
        }

    }

    void OnTriggerStay2D(Collider2D nesne) // when player collide with enemy
    {
        if (nesne.gameObject.tag == "Player")
        {
            if (new_fire_permission == true)
            {

                //bgmc.make_quake();

                Invoke("delay_quake", quake_frequency);
                anim.SetBool("attack", true);


                new_fire_permission = false;
            }

        }
    }

    public void delay_quake()
    {
        bgc.make_quake();
        Invoke("wait_for_quake_animation_time", 0.7f);

        /*bgmc.transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        bgmc.transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        bgmc.stop_getreadyfor_quake = false;*/
    }

    public void wait_for_quake_animation_time()
    {
        bgc.stop_getreadyfor_quake = false;
        bgc.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
        new_fire_permission = true;
        anim.SetBool("attack", false);
    }

    void OnTriggerExit2D(Collider2D nesne) // when player enter the field
    {
        if (is_triggered == true)
        {
            if (nesne.gameObject.tag == "Player")
            {
                Debug.Log("arujo gitti");
                Arujo_is_in_damage_zone = false;
                //bgc.is_damage_area_trigerred = false;
                //bgc.focus_on_patrol();
                is_triggered = false;
            }
        }

    }

}///////
