using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemZone : MonoBehaviour
{
    public bool is_triggered = false;
    //move_trial aef;
    public bool new_fire_permission = true;
    public Golem bgmc;
    public bool Arujo_is_in_damage_zone = false;

    float quake_frequency = 0;
    // Start is called before the first frame update
    public Animator anim;

    void Start()
    {
        //anim = GetComponent<Animator>();
        //bgmc = GameObject.FindGameObjectWithTag("Golem").GetComponent<Golem>();
        //aef = GameObject.FindGameObjectWithTag("Player").GetComponent<move_trial>();
        quake_frequency = 4f;
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
                FindObjectOfType<AudioManager>().Play("noticeGolem");
                Debug.Log("arujoyu gordum");
                Arujo_is_in_damage_zone = true;
                bgmc.focus_on_target();

                //pc_class.transform.localScale = new Vector3(-1 * aef.transform.localScale.x, 1, 1);
                //pc_class.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                bgmc.is_damage_area_trigerred = true;
                is_triggered = true;
                anim.SetBool("move", true);
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


                new_fire_permission = false;
            }

        }
    }

    public void delay_quake()
    {
        anim.SetBool("attack", true);
        bgmc.make_quake();
        //anim.SetBool("attack", true);
        Invoke("wait_for_quake_animation_time", 1.5f);

        /*bgmc.transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        bgmc.transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        bgmc.stop_getreadyfor_quake = false;*/
    }

    public void wait_for_quake_animation_time()
    {
        bgmc.stop_getreadyfor_quake = false;
        bgmc.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
        new_fire_permission = true;
        Debug.Log("anim bitti");
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
                bgmc.is_damage_area_trigerred = false;
                bgmc.focus_on_patrol();
                is_triggered = false;
            }
        }

    }
}/////////////
