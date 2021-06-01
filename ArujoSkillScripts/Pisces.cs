using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pisces : MonoBehaviour
{
    public Transform target;
    public Transform PiscesGFX;

    public float speed;
    public float next_way_point_distance = 3f;
    public float nextshoot_time;

    Path mypath;
    int current_waypoint = 0;
    bool reached_ebd_point = false;

    Seeker seeker;
    Rigidbody2D rb;

    BasicMovements aef_class;
    Bats b;

    float saldiri_hiz;
    Vector3 currenteu;

    PiscesSkill ps;
    public bool alldestroy;
    EnemyBrowse eb;

    void Start()
    {
        eb = GameObject.FindGameObjectWithTag("enemybrowser").GetComponent<EnemyBrowse>();
        ps = GameObject.FindGameObjectWithTag("piscescircle").GetComponent<PiscesSkill>();
        target = null;
        speed = 20f;
        saldiri_hiz = 20;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("Update_path", 0f, 0.5f);

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
        if (ps.nowattack == true)
        {
            watch_point_function();
        }

       
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
        


    }
    


    void OnTriggerEnter2D(Collider2D nesne) // when player enter the field
    {
        if (nesne.gameObject.tag == "Golem")
        {
            Destroy(gameObject);
        }
        if (nesne.gameObject.tag == "Pafkrav")
        {
            Destroy(gameObject);
        }
        if (nesne.gameObject.tag == "bats")
        {
            Destroy(gameObject);
        }
        if (nesne.gameObject.tag == "meleechaser")
        {
            Destroy(gameObject);
        }
        if (nesne.gameObject.tag == "starguard")
        {
            Destroy(gameObject);
        }

        if (nesne.gameObject.tag == "Player") // if area is empty
        {
            Destroy(gameObject);

        }
        /*else
        {
            if (true)
            {

            } 
        }*/


    }
    public void destroyke()
    {
        Destroy(gameObject);
    }

    public void watch_point_function()
    {
        alldestroy = false;
        target = eb.target;
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        //.EnemyZone.radius = 1f;


    }

    
}///////////
