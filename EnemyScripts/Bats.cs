using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bats : MonoBehaviour
{
    public Transform target;
    public Transform batGFX;

    public float speed;
    public float next_way_point_distance = 3f;
    //public float bats_bite_damage = 0.01f;
    public float bats_health = 500f;
    public float nextshoot_time;

    Path mypath;
    int current_waypoint = 0;
    bool reached_ebd_point = false;

    Seeker seeker;
    Rigidbody2D rb;

    BasicMovements aef_class;


    float saldiri_hiz;
    Vector3 currenteu;

    //public EnemyHealthBars HealthBar;
    void Start()
    {
        speed = 7f;
        saldiri_hiz = 20;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        aef_class = GameObject.FindGameObjectWithTag("Player").GetComponent<BasicMovements>();
        //HealthBar = GameObject.FindGameObjectWithTag("enemyHbar").GetComponent<EnemyHealthBars>();

        InvokeRepeating("Update_path", 0f, 0.5f);

        target = aef_class.transform;
        FindObjectOfType<AudioManager>().Play("batSound");

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

    void Update()
    {
        turnblade();
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

        float distance = Vector2.Distance(rb.position, mypath.vectorPath[current_waypoint]);

        if (distance < next_way_point_distance)
        {
            current_waypoint++;
        }

        if (bats_health <= 0)
        {
            aef_class.batDeathCount++;
            if (aef_class.batDeathCount == 3)
            {
                FindObjectOfType<AudioManager>().Stop("batSound");
                aef_class.batDeathCount = 0;
            }
            when_bats_health_runout();
        }
        



    }

    /*void FixedUpdate()
    {
        if (bats_health >= 1)
        {
            HealthBar.SetHealth(bats_health, 500);
        }
    }*/
    void OnCollisionEnter2D(Collision2D nesne) // when player collide with enemy
    {
        if (nesne.gameObject.tag == "arrow")
        {
           bats_health = bats_health - 50f;
        }
        if (nesne.gameObject.tag == "taurus")
        {
            bats_health = bats_health - 250f;
        }

        //

    }



   /* void attack_function(float dmg)
    {
        //aef_class.get_damage(bats_bite_damage); // GERİ AÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇ
        //aef_class.transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.black;
        //Invoke("Duzelt", 1f);

    }*/

    public void turnblade()
    {
        currenteu += new Vector3(0, 0, 50) * Time.deltaTime * saldiri_hiz;
        gameObject.transform.GetChild(1).transform.eulerAngles = currenteu;
    }

    /*public void get_damage(float damage_amount)
    {
        bats_health = bats_health - damage_amount;
    }*/

    public void when_bats_health_runout()
    {
        Destroy(gameObject);
    }

    void destroy_arrow()
    {
        Destroy(GameObject.FindGameObjectWithTag("arrow"));
    }

    void OnTriggerEnter2D(Collider2D nesne) // when player enter the field
    {
        if (nesne.gameObject.tag == "blade")
        {
            bats_health = bats_health - 50f;
        }

        if (nesne.gameObject.tag == "pisces")
        {
            bats_health = bats_health - 50f;
        }

        



    }



    public void watch_point_function()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

    }

}/////////
