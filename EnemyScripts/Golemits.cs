using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golemits : MonoBehaviour
{
    // Start is called before the first frame update
    public float golem_health;
    public float quake_damage;
    //public float enemy_touch_damage;
    public bool is_damage_area_trigerred;
    public bool stop_getreadyfor_quake;

    //Basic_attack_code bac_class;
    PlayerEntity aef_class;
    bool is_focus_on_player = false;


    public List<Transform> points; ///////////////////////////////////////////////////////
    //public Transform left_point;
    //public Transform right_point;
    //The int value for next point index
    public int nextID = 0;
    //The value of that applies to ID for changing
    int idChangeValue = 1;
    //Speed of movement or flying
    public float speed = 2;


    public Transform target;
    public Transform golemGFX;

    //public float speed = 200f;
    public float next_way_point_distance = 3f;
    //public float enemy_attack_damage = 0.01f;
    //public float bats_health = 500f;
    public float nextshoot_time;

    Path mypath;
    int current_waypoint = 0;
    bool reached_ebd_point = false;

    Seeker seeker;
    Rigidbody2D rb;


    public int pafkrov_direction = 1;
    //public GameObject golemits;
    public float launch_force = 1;
    //public Transform spawn_point;

    public bool stop_and_fire = false;
    //public int splitting_counter = 2;

    Golem bsmc;
    GolemitsZone gdz;
    public EnemyHealthBars HealthBar;
    //float fireball_move_speed = 0;

    // Arujo_entitiy_features aef_class;

    void Start()
    {
        is_damage_area_trigerred = false;
        stop_getreadyfor_quake = false;
        bsmc = GameObject.FindGameObjectWithTag("Player").GetComponent<Golem>();
        gdz = GameObject.FindGameObjectWithTag("golemit").GetComponentInChildren<GolemitsZone>();
        quake_damage = 15;
        //left_point = GameObject.Find("pafkrav_left").transform;
        //right_point = GameObject.Find("pafkrav_right").transform;
        golem_health = 800;
        // left_point = bsmc.points[0];
        //points[0] = left_point;
        // points[1] = right_point;
        golemGFX = transform.GetChild(0).GetComponent<SpriteRenderer>().transform;
        // fireball_move_speed = 0.8f;
        //enemy_touch_damage = 0.5f;
        aef_class = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEntity>();

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("Update_path", 0f, 0.5f);

        target = aef_class.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (golem_health <= 0)
        {
            when_enemy_health_runout();
        }

        if (golem_health >= 1)
        {
            HealthBar.SetHealth(golem_health, 800);
        }


        //MoveToNextPoint();
        watch_point_function();

        if (mypath == null)
        {
            return;
        }

        if (current_waypoint >= mypath.vectorPath.Count)
        {
            reached_ebd_point = true;
            return;
        }
        else
        {
            reached_ebd_point = false;
        }
        /*Vector2 direction = ((Vector2)mypath.vectorPath[current_waypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);*/

        float distance = Vector2.Distance(rb.position, mypath.vectorPath[current_waypoint]);

        if (distance < next_way_point_distance)
        {
            current_waypoint++;
        }

        /* if (force.x >= 0.01f)
         {
             stoneGFX.localScale = new Vector3(-1f, 1f, 1f);
         }
         else if (force.x <= -0.01f)
         {
             stoneGFX.localScale = new Vector3(1f, 1f, 1f);
         }*/


    }

    /*public void save_directions(Transform left , Transform right)
    {
        left_point = left;
        right_point = right;
    }*/

    public void get_damage(float damage_amount)
    {
        this.golem_health = this.golem_health - damage_amount;
    }

    public void when_enemy_health_runout()
    {
        FindObjectOfType<AudioManager>().Play("deathGolem");
        //splitting_mechanism();
        Destroy(gameObject);
        /*GameObject new_golemits0 = Instantiate(golemits, spawn_point.position, transform.rotation);
        GameObject new_golemits1 = Instantiate(golemits, spawn_point.position, transform.rotation);*/

    }

    /* public void give_damage_on_player(float damage_amount)
     {
         aef_class.arujo_form_health = fafkrav_health - damage_amount;
     }*/

    /*void OnCollisionStay2D(Collision2D nesne) // when player collide with enemy
    {
        if (nesne.gameObject.tag == "Player")
        {
           // get_damage(100); // GERİ AÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇ
                             // aef_class.transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.black;
                             //Invoke("Duzelt", 1f);
        }
    }*/

    /*void OnCollisionEnter2D(Collision2D nesne) // when player collide with enemy
    {
        if (nesne.gameObject.tag == "blade")
        {
            Debug.Log("BLADE");
            get_damage(200);
            //Invoke("destroy_arrow", 0.5f);
        }

        /**if (nesne.gameObject.tag == "level_side")
        {
            Invoke("destroy_arrow", 0.55f);
        }*/
    //}

    /*void Duzelt()
    {
        //GetComponent<SpriteRenderer>().color = Color.white;
        aef_class.transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
        //QualitySettings.SetQualityLevel
    }*/



    public void watch_point_function()
    {

        if (stop_getreadyfor_quake == false)
        {
            if (target.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
            else
            {
                transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            }
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        /*Transform goalPoint = target.transform;
        if (goalPoint.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
            target = watch_point;
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
            target = watch_point;
        }*/

    }

    void Update_path()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }

    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            mypath = p;
            current_waypoint = 0;
        }
    }

    public void focus_on_target()
    {
        target = aef_class.transform;
        is_focus_on_player = true;
    }

    /*public void focus_on_patrol()
    {
        target = target = points[nextID].transform;
        is_focus_on_player = false;
    }*/

    /* public void splitting_mechanism()
     {
         GameObject new_golemits0 = Instantiate(golemits, spawn_point.position, transform.rotation);
         //GameObject new_golemits1 = Instantiate(golemits, spawn_point.position, transform.rotation);
     }*/
    public void make_quake()
    {
        Debug.Log("SARSTIMMMM");
        stop_getreadyfor_quake = true;
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.gray;
        //rb.constraints =  RigidbodyConstraints2D.FreezePositionX| RigidbodyConstraints2D.FreezePositionY|RigidbodyConstraints2D.FreezeRotation;
        if (gdz.Arujo_is_in_damage_zone == true)
        {
            aef_class.hasarAl(20);
            //Debug.Log("mink hsar");
            //aef_class.get_damage(quake_damage);
            //HASAR VER

        }
    }
    void OnTriggerEnter2D(Collider2D nesne) // when player enter the field
    {
        if (nesne.gameObject.tag == "blade")
        {
            get_damage(50);
        }

        if (nesne.gameObject.tag == "pisces")
        {
            get_damage(50);
        }

    }
    void OnCollisionEnter2D(Collision2D other) // when player collide with enemy
    {
        if (other.gameObject.tag == "arrow")
        {
            get_damage(50f);
        }
        if (other.gameObject.tag == "taurus")
        {
            get_damage(250);
        }
    }
}//////////
