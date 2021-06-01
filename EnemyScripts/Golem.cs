using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MonoBehaviour
{
    // Start is called before the first frame update
    public float golem_health;
    public float quake_damage;

    //Basic_attack_code bac_class;
    PlayerEntity aef_class;
    bool is_focus_on_player = false;


    public List<Transform> points;
    //The int value for next point index
    public int nextID = 0;
    //The value of that applies to ID for changing
    int idChangeValue = 1;
    //Speed of movement or flying
    public float speed = 2;
    bool karsu;

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
    public Rigidbody2D rb;


    public int pafkrov_direction = 1;
    public GameObject golemits1;
    public GameObject golemits0;
    public float launch_force = 1;
    public Transform spawn_point;
    public Transform watch_point;

    public bool is_damage_area_trigerred = false;
    public bool stop_getreadyfor_quake = false;
    //public int splitting_counter = 2;
    bool isGolemDead;

    //float fireball_move_speed = 0;

    // Arujo_entitiy_features aef_class;
    //Basic_golemit_code bgc;
    public GolemZone gdz;
    public EnemyHealthBars HealthBar;
    //PlayerEntitiy pe;
    public Animator anim;
    bool firstTime;
    void Start()
    {
        firstTime = true;
        isGolemDead = false;
        karsu = false;
        //anim = GetComponent<Animator>();
        golem_health = 3000;
        quake_damage = 100;

        // fireball_move_speed = 0.8f;
        //enemy_touch_damage = 0.5f;
        aef_class = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEntity>();
        //gdz = GameObject.FindGameObjectWithTag("Golem").GetComponent<Golem_damage_zone>();
        //gdz = GameObject.FindGameObjectWithTag("Golem").GetComponentInChildren<GolemZone>();
        //HealthBar = GameObject.FindGameObjectWithTag("enemyHbar").GetComponentInChildren<EnemyHealthBars>();
        //gdz = GameObject.findga

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("Update_path", 0f, 0.5f);

        target = aef_class.transform;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (gameObject.activeInHierarchy)
        {
            if (golem_health <= 0 && isGolemDead == false)
            {
                isGolemDead = true;
                when_enemy_health_runout();
            }
        }*/
        if (golem_health <= 0)
        {

            //isGolemDead = true;
            FindObjectOfType<AudioManager>().Stop("moveGolem");
            when_enemy_health_runout();
        }
        if (golem_health >= 1)
        {
            HealthBar.SetHealth(golem_health, 3000);
        }


        //MoveToNextPoint();,w
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

    public void get_damage(float damage_amount)
    {
        golem_health = golem_health - damage_amount;
    }

    public void when_enemy_health_runout()
    {
        {
            FindObjectOfType<AudioManager>().Stop("moveGolem");
            FindObjectOfType<AudioManager>().Play("deathGolem");
            
            //GameObject new_bat = Instantiate(bats, bats_spawn_point.position, Quaternion.identity);
            GameObject new_golemits0 = Instantiate(golemits0, spawn_point.position, transform.rotation);
            GameObject new_golemits1 = Instantiate(golemits0, spawn_point.position, transform.rotation);
        }
        transform.gameObject.SetActive(false);
        //Destroy(gameObject);




    }

    /* public void give_damage_on_player(float damage_amount)
     {
         aef_class.arujo_form_health = fafkrav_health - damage_amount;
     }*/

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

    /*void OnCollisionEnter2D(Collision2D nesne) // when player collide with enemy
    {
        if (nesne.gameObject.tag == "arrow")
        {
            get_damage(250);
            Invoke("destroy_arrow", 0.5f);
        }

        if (nesne.gameObject.tag == "level_side")
        {
            Invoke("destroy_arrow", 0.55f);
        }
    }*/

    /*void Duzelt()
    {
        //GetComponent<SpriteRenderer>().color = Color.white;
        aef_class.transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
        //QualitySettings.SetQualityLevel
    }*/

    /* void destroy_arrow()
     {
         //GameObject.FindGameObjectWithTag("arrow");
         Destroy(GameObject.FindGameObjectWithTag("arrow"));
     }
    */

    /*
    void MoveToNextPoint()
    {
        if (is_damage_area_trigerred == false)
        {
            //Get the next Point transform
            Transform goalPoint = points[nextID];
            //Flip the enemy transform to look into the point's direction
            if (is_focus_on_player == false)
            {
                if (goalPoint.transform.position.x > transform.position.x)
                {
                    //transform.localScale = new Vector3(1, 1, 1);
                    target = points[nextID].transform;
                }
                if(goalPoint.transform.position.x < transform.position.x)
                {
                    //transform.localScale = new Vector3(-1, 1, 1);
                    target = points[nextID].transform;
                }

                //Move the enemy towards the goal point
                if (stop_getreadyfor_quake = false)
                {
                    transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
                }

                //Check the distance between enemy and goal point to trigger next point
                if (Vector2.Distance(transform.position, goalPoint.position) < 0.2f)
                {
                    //Check if we are at the end of the line (make the change -1)
                    if (nextID == points.Count - 1)
                        idChangeValue = -1;
                    //Check if we are at the start of the line (make the change +1)
                    if (nextID == 0)
                        idChangeValue = 1;
                    //Apply the change on the nextID
                    nextID += idChangeValue;
                }
            }

            else if (is_focus_on_player == true)
            {
                if (stop_getreadyfor_quake == true)
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                }

            }
        }


    }*/

    public void watch_point_function()
    {


        if (is_damage_area_trigerred == false)
        {
            Transform goalPoint = watch_point;
            if (goalPoint.transform.position.x != transform.position.x)
            {
                
                
                if (goalPoint.transform.position.x > transform.position.x)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    target = watch_point;
                    if (stop_getreadyfor_quake == false)
                    {
                        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
                    }
                }
                else
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    target = watch_point;
                    if (stop_getreadyfor_quake == false)
                    {
                        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
                    }
                }

            }

            if (goalPoint.transform.position.x == transform.position.x)
            {
                FindObjectOfType<AudioManager>().Stop("moveGolem");
                firstTime = true;
                transform.position = watch_point.position;
                anim.SetBool("idle", true);
                anim.SetBool("move", false);
                transform.localScale = new Vector3(-1, 1, 1);
            }
            //transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
        }

        else if (is_damage_area_trigerred == true)
        {
            if (stop_getreadyfor_quake == false)
            {
                //transform.localScale = new Vector3(-1, 1, 1);
                if (target.transform.position.x > transform.position.x)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                anim.SetBool("idle", false);
                anim.SetBool("idle", true);
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


            /*if (karsu==true)
            {
                anim.SetBool("move", false);
            }*/
        }
    }

    public void focus_on_target()
    {
        target = aef_class.transform;
        is_focus_on_player = true;
        if (firstTime)
        {
            FindObjectOfType<AudioManager>().Play("moveGolem");
            firstTime = false;
        }


        //karsu = false;
        //anim.SetBool("move", true);
    }

    public void focus_on_patrol()
    {
        target = watch_point.transform;
        is_focus_on_player = false;
        //karsu = true;
    }

    /*public void Throw_a_fireball()
    {

        Vector2 current_position = transform.position;
        Vector2 player_position = aef_class.transform.position;
        Vector2 fire_direction = player_position - current_position;


        GameObject new_fireball = Instantiate(fireball, shoot_point.position, transform.rotation);

        new_fireball.GetComponent<Rigidbody2D>().velocity = fire_direction * fireball_move_speed;
    }*/

    public void splitting_mechanism()
    {
        //GameObject new_golemits0 = Instantiate(golemits, spawn_point.position, transform.rotation);
        //GameObject new_golemits1 = Instantiate(golemits, spawn_point.position, transform.rotation);
    }

    public void make_quake()
    {

        stop_getreadyfor_quake = true;
        Debug.Log("anim başladı");
        //anim.SetBool("attack", true);
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.gray;
        //rb.constraints =  RigidbodyConstraints2D.FreezePositionX| RigidbodyConstraints2D.FreezePositionY|RigidbodyConstraints2D.FreezeRotation;
        if (gdz.Arujo_is_in_damage_zone == true)
        {
            FindObjectOfType<AudioManager>().Play("golemHush");
            Invoke("attackDelay", 1f);
            //aef_class.hasarAl(100);
            //pe = new PlayerEntitiy();
            //pe.TakeHit(quake_damage);
            //aef_class.arujo_form_speed = 80;
            //aef_class.get_damage(quake_damage);
            //HASAR VERECEK
        }
    }

    void attackDelay()
    {
        FindObjectOfType<AudioManager>().Play("attackGolem");
        aef_class.hasarAl(100);
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "blade")
        {
            get_damage(50);
        }

        if (other.gameObject.tag == "pisces")
        {
            Debug.Log(" kaza kaz abakınca");
            get_damage(50);
        }
    }


}//////////
