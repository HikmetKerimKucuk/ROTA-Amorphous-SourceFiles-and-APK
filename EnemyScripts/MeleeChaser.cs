using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeChaser : MonoBehaviour
{
    public float enemy_health;
    public float enemy_touch_damage;

    public EnemyHealthBars HealthBar;
    PlayerEntity pe;
    public bool is_focus_on_player;


    public List<Transform> points;
    //The int value for next point index
    public int nextID = 0;
    //The value of that applies to ID for changing
    int idChangeValue = 1;
    //Speed of movement or flying
    public float speed = 2;


    public Transform target;
    public Transform stoneGFX;

    public float next_way_point_distance = 3f;
    public float enemy_attack_damage = 0.01f;
    public float nextshoot_time;

    Path mypath;
    int current_waypoint = 0;
    bool reached_ebd_point = false;

    Seeker seeker;
    Rigidbody2D rb;
    public Collider2D Area;
    public bool is_triggered = false;
    Vector3 currenteu;
    float saldiri_hiz;
    bool firstTime;

    public Animator anim;
    public GameObject blade;


    void Start()
    {
        saldiri_hiz = 5;
        firstTime = true;
        enemy_health = 1000;
        enemy_touch_damage = 0.5f;
        pe = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEntity>();

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("Update_path", 0f, 1f);

        //target = aef_class.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy_health <= 0)
        {
            when_enemy_health_runout();
        }
        if (enemy_health >= 1)
        {
            HealthBar.SetHealth(enemy_health, 1000);
        }

        MoveToNextPoint();

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
        //turnblade();
        //currenteu += new Vector3(0, 0, 50) * Time.deltaTime * saldiri_hiz;

    }
    public void turnblade()
    {
        //if (target == pe.transform)
        //{anim.SetBool("fire", false);
        
        currenteu += new Vector3(0, 0, 50) * Time.deltaTime * saldiri_hiz;
        blade.transform.eulerAngles = currenteu;


        //}

    }

    public void get_damage(float damage_amount)
    {
        enemy_health = enemy_health - damage_amount;
    }

    public void when_enemy_health_runout()
    {
        //Destroy(gameObject);
        FindObjectOfType<AudioManager>().Play("meleeDeath");
        this.gameObject.SetActive(false);
    }

    public void give_damage_on_player(float damage_amount)
    {
        //aef_class.arujo_form_health = enemy_health - damage_amount;
    }

    void OnCollisionStay2D(Collision2D nesne) // when player collide with enemy
    {
        if (nesne.gameObject.tag == "Player")
        {
            //aef_class.get_damage(enemy_touch_damage); // GERİ AÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇ
            //pe.transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.black;
            //Invoke("Duzelt", 1f);
        }
    }

    void OnCollisionEnter2D(Collision2D nesne) // when player collide with enemy
    {


        if (nesne.gameObject.tag == "arrow")
        {
            get_damage(50);
        }
        if (nesne.gameObject.tag == "taurus")
        {
            get_damage(250);
        }
    }
    void Duzelt()
    {
        //GetComponent<SpriteRenderer>().color = Color.white;
        //pe.transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
        //QualitySettings.SetQualityLevel
    }

    void destroy_arrow()
    {
        //GameObject.FindGameObjectWithTag("arrow");
        Destroy(GameObject.FindGameObjectWithTag("arrow"));
    }

    void MoveToNextPoint()
    {
        //Get the next Point transform
        Transform goalPoint = points[nextID];
        //Flip the enemy transform to look into the point's direction
        if (is_focus_on_player == false)
        {
            anim.SetBool("attack", false);
            anim.SetBool("move", true);
            if (goalPoint.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                target = points[nextID].transform;
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
                target = points[nextID].transform;
            }

            //Move the enemy towards the goal point
            transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
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
            turnblade();
            //gameObject.transform.GetChild(2).transform.eulerAngles = currenteu;
            anim.SetBool("attack", true);
            anim.SetBool("move", false);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            //is_focus_on_player = true;
            //target = pe.transform;
            //MoveToNextPoint();
            if (target.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                //target = points[nextID].transform;
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
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
        }
    }

    public void focus_on_target()
    {
        
        target = pe.transform;
        is_focus_on_player = true;
        
        if (firstTime)
        {
            FindObjectOfType<AudioManager>().Play("meleeAttack");
            firstTime = false;
        }
        //FindObjectOfType<AudioManager>().Play("meleeNotice");
    }

    public void focus_on_patrol()
    {
        
        target = target = points[nextID].transform;
        is_focus_on_player = false;
        FindObjectOfType<AudioManager>().Stop("meleeAttack");
        firstTime = true;

    }


    void OnTriggerEnter2D(Collider2D nesne) // when player enter the field
    {
        if (Area.IsTouching(nesne))
        {
            if (is_triggered == false)
            {
                if (nesne.gameObject.tag == "Player")
                {
                    Debug.Log("girdimmm");
                    focus_on_target();
                    is_triggered = true;
                    FindObjectOfType<AudioManager>().Play("meleeNotice");
                }
            }
        }

        if (nesne.gameObject.tag == "blade")
        {
            get_damage(50);
        }

        if (nesne.gameObject.tag == "pisces")
        {
            get_damage(20);
        }

    }

    void OnTriggerStay2D(Collider2D nesne) // when player enter the field
    {
        if (Area.IsTouching(nesne))
        {
            if (nesne.gameObject.tag == "Player")
            {
                Debug.Log("kal kal");
                focus_on_target();
            }
        }

    }

    void OnTriggerExit2D(Collider2D nesne) // when player enter the field
    {
        if (nesne.gameObject.tag == "Player")
        {
            if (is_triggered == true)
            {
                focus_on_patrol();
                is_triggered = false;
            }
        }


    }


}///////////
