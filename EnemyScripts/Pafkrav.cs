using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pafkrav : MonoBehaviour
{
    // Start is called before the first frame update
    public float fafkrav_health;
    public Animator anim;
    //public float enemy_touch_damage;

    //Basic_attack_code bac_class;
    PlayerEntity aef_class;
    bool is_focus_on_player = false;
    public Collider2D Area;
    public Collider2D mycapsule;

    public List<Transform> points;
    //The int value for next point index
    public int nextID = 0;
    //The value of that applies to ID for changing
    int idChangeValue = 1;
    //Speed of movement or flying
    public float speed = 2;


    public Transform target;
    public Transform pafkravGFX;

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
    public GameObject fireball;
    public float launch_force = 1;
    public Transform shoot_point;

    public bool stop_and_fire = false;


    float fireball_move_speed = 0;



    public bool is_triggered = false;
    //Pakrav_code pc_class;
    //Arujo_entitiy_features aef;
    public bool new_fire_permission = true;

    public float fire_rate = 0;

    // Arujo_entitiy_features aef_class;
    public EnemyHealthBars HealthBar;

    void Start()
    {
        fire_rate = 1.5f;
        fafkrav_health = 1000;
        anim.SetBool("fire", false);
        anim.SetBool("patrol", true);

        fireball_move_speed = 0.8f;
        //enemy_touch_damage = 0.5f;
        aef_class = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEntity>();

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("Update_path", 0f, 0.5f);

        //target = aef_class.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (fafkrav_health <= 0)
        {
            when_enemy_health_runout();
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

        /* if (force.x >= 0.01f)
         {
             stoneGFX.localScale = new Vector3(-1f, 1f, 1f);
         }
         else if (force.x <= -0.01f)
         {
             stoneGFX.localScale = new Vector3(1f, 1f, 1f);
         }*/
        if (fafkrav_health >= 1)
        {
            HealthBar.SetHealth(fafkrav_health, 1000);
        }

    }

    public void get_damage(float damage_amount)
    {
        fafkrav_health = fafkrav_health - damage_amount;
    }

    public void when_enemy_health_runout()
    {
        //Destroy(gameObject);
        FindObjectOfType<AudioManager>().Play("deathPafkrav");
        this.gameObject.SetActive(false);
    }

    /* public void give_damage_on_player(float damage_amount)
     {
         aef_class.arujo_form_health = fafkrav_health - damage_amount;
     }*/

    /*void OnCollisionStay2D(Collision2D nesne) // when player collide with enemy
    {
        if (nesne.gameObject.tag == "Player")
        {
            //aef_class.get_damage(enemy_touch_damage); // GERİ AÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇÇ
            aef_class.transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.black;
            Invoke("Duzelt", 1f);
        }
    }*/

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
    void Duzelt()
    {
        //GetComponent<SpriteRenderer>().color = Color.white;
        aef_class.transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
        //QualitySettings.SetQualityLevel
    }

    /* void destroy_arrow()
     {
         //GameObject.FindGameObjectWithTag("arrow");
         Destroy(GameObject.FindGameObjectWithTag("arrow"));
     }
    */
    void MoveToNextPoint()
    {
        if (stop_and_fire == false)
        {
            //Get the next Point transform
            Transform goalPoint = points[nextID];
            //Flip the enemy transform to look into the point's direction
            if (is_focus_on_player == false)
            {
                if (goalPoint.transform.position.x > transform.position.x)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    target = points[nextID].transform;
                }
                else
                {
                    transform.localScale = new Vector3(-1, 1, 1);
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

            /*else if (is_focus_on_player == true)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }*/
        }


    }
    /// <summary>
    /// //////////////////////////////////////////////////////////
    /// </summary>

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

        anim.SetBool("fire", true);
        anim.SetBool("patrol", false);
    }

    public void focus_on_patrol()
    {
        target = points[nextID].transform;
        is_focus_on_player = false;

        anim.SetBool("fire", false);
        anim.SetBool("patrol", true);
    }

    public void Throw_a_fireball()
    {
        /*GameObject new_arrow = Instantiate(arrow, shoot_point.position, shoot_point.rotation);
        new_arrow.GetComponent<Rigidbody2D>().velocity = transform.GetChild(2).GetChild(1).GetChild(1).transform.right * launch_force;*/
        FindObjectOfType<AudioManager>().Play("attackPafkrav");
        Vector2 current_position = transform.position;
        Vector2 player_position = aef_class.transform.position;
        Vector2 fire_direction = player_position - current_position;
        //transform.right = fire_direction; //allahını kaybedip yüzünü sana çeviriyor lazım olabilir SAKLA BU KODU !!
        //float oran = fire_direction;

        GameObject new_fireball = Instantiate(fireball, shoot_point.position, transform.rotation);

        //new_fireball.GetComponent<Rigidbody2D>().velocity = transform.right * launch_force;
        new_fireball.GetComponent<Rigidbody2D>().velocity = fire_direction.normalized * fireball_move_speed * 20;
        //new_fireball.GetComponent<Rigidbody2D>().velocity =  Vector2.one;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        /*if (other.gameObject.tag == "pisces")
        {
            get_damage(10);
            Debug.Log("uy nuri babacum kulağımı hamsi isirduğ");
        }*/
        if (other.gameObject.tag == "blade")
        {
            fafkrav_health = fafkrav_health - 50f;
        }

        if (other.gameObject.tag == "pisces")
        {
            fafkrav_health = fafkrav_health - 20f;
        }
        


        if (Area.IsTouching(other))
        {
            if (other.gameObject.tag == "pisces")
            {
                //Area.gameObject.SetActive(false);
            }

            if (is_triggered == false)
            {
                if (other.gameObject.tag == "Player")
                {
                    Debug.Log("girdimmm");
                    focus_on_target();

                    //transform.localScale = new Vector3(-1 * aef_class.transform.localScale.x, 1, 1);
                    //pc_class.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    stop_and_fire = true;
                    is_triggered = true;
                    //pc_class.Throw_a_fireball();
                }
            }
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Area.IsTouching(other))
        {
            if (other.gameObject.tag == "Player")
            {

                if (new_fire_permission == true)
                {

                    Invoke("delay_fire", fire_rate);
                    Throw_a_fireball();
                    new_fire_permission = false;


                }

                if (transform.position.x >= aef_class.transform.position.x)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                if (transform.position.x < aef_class.transform.position.x)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }
    }

    public void delay_fire()
    {
        new_fire_permission = true;
    }

    void OnTriggerExit2D(Collider2D nesne) // when player enter the field
    {
        if (is_triggered == true)
        {
            if (nesne.gameObject.tag == "Player")
            {
                Debug.Log("çıktımmmmmm");
                stop_and_fire = false;
                focus_on_patrol();
                is_triggered = false;
            }
        }

    }
    void OnCollisionEnter2D(Collision2D other) // when player collide with enemy
    {
        if (other.gameObject.tag == "arrow")
        {
            fafkrav_health = fafkrav_health - 50f;
        }
        if (other.gameObject.tag == "taurus")
        {
            fafkrav_health = fafkrav_health - 250f;
        }

        //

    }

    
}////////
