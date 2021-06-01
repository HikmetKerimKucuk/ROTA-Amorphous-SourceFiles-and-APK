using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGuard : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject asteroidZone;
    //public Transform parent;
    public GameObject parent_object;
    public float z_rotation_amount = 0f;
    public float star_damage;
    public float starGuard_health;
    public bool player_is_in_internalZone = false;
    public bool player_is_in_externalZone = false;
    public float nowz;
    public float up_and_down;
    public Transform start_pozitiion;

    //public Collider2D internalZone;
    //public Collider2D externalZone;
    public EnemyHealthBars HealthBar;

    //Arujo_entitiy_features aef;
    void Start()
    {
        nowz = 1.0f;
        up_and_down = 0.1f;
        starGuard_health = 1000;
        //start_pozitiion = transform.GetComponent<Transform>();
        start_pozitiion = transform.GetComponentInParent<Transform>();
        //aef = GameObject.FindGameObjectWithTag("Player").GetComponent<Arujo_entitiy_features>();
        star_damage = 5f;
        //parent = transform.GetComponentInParent<Transform>();
        //self_call_function();
        uppo();
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("revolve_function", 0.2f);
        asteroid_rotation();
        zone_expand_or_narrow();
        up_and_down_flying_animation();

        if (starGuard_health <= 0)
        {
            when_enemy_health_runout();
        }

        if (starGuard_health >= 1)
        {
            HealthBar.SetHealth(starGuard_health, 1000);
        }
    }
    public void when_enemy_health_runout()
    {
        //Destroy(parent_object);
        FindObjectOfType<AudioManager>().Play("StarGDeath");
        this.gameObject.SetActive(false);
    }

    public void asteroid_rotation()
    {
        asteroidZone.transform.rotation = Quaternion.Euler(0, 0, z_rotation_amount);
    }

    public void revolve_function()
    {
        z_rotation_amount = z_rotation_amount - 7f;
    }

    /*void OnTriggerEnter2D(Collider2D nesne) // when player enter the field
    {

        if (nesne.gameObject.tag == "Arujo")
        {
            Debug.Log("arujoyu VURDUM");
            //aef.get_damage(star_damage);
            //Arujo_is_in_damage_zone = true;
            //bgc.focus_on_target();
            //pc_class.transform.localScale = new Vector3(-1 * aef.transform.localScale.x, 1, 1);
            //pc_class.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            //bgc.is_damage_area_trigerred = true;
            //is_triggered = true;
            //pc_class.Throw_a_fireball();
        }


    }*/

    void zone_expand_or_narrow()
    {
        if (player_is_in_internalZone == false && player_is_in_externalZone == false)
        {
            //transform.localScale = new Vector3(1.2f, 1.2f, 0.1f);
            nowz = 1f;
            increase_z();
            // Invoke("increase_z", 0.2f);
        }
        else if (player_is_in_internalZone == false && player_is_in_externalZone == true)
        {
            //transform.localScale = new Vector3(2.4f, 2.4f, 0.1f);
            nowz = 2.2f;
            increase_z();
            // Invoke("increase_z", 0.2f);
        }
        else if (player_is_in_internalZone == true && player_is_in_externalZone == true)
        {
            //transform.localScale = new Vector3(1.2f, 1.2f, 0.1f);
            nowz = 1f;
            //Invoke("increase_z", 0.2f);
            increase_z();
        }
    }

    public void increase_z()
    {
        if (asteroidZone.transform.localScale.x == nowz)
        {
            // transform.localScale = new Vector3(1.2f, 1.2f, 0.1f);
        }
        else if (asteroidZone.transform.localScale.x < nowz)
        {
            //transform.localScale.x = transform.localScale.x + 0.1f;
            if (asteroidZone.transform.localScale.x != nowz)
            {
                asteroidZone.transform.localScale = new Vector3(asteroidZone.transform.localScale.x + 0.01f, asteroidZone.transform.localScale.y + 0.01f, 0.1f);
            }

        }
        else if (asteroidZone.transform.localScale.x > nowz)
        {
            if (asteroidZone.transform.localScale.x != nowz)
            {
                asteroidZone.transform.localScale = new Vector3(asteroidZone.transform.localScale.x - 0.01f, asteroidZone.transform.localScale.y - 0.01f, 0.1f);
            }
        }

        //return 0f;
    }

    public void up_and_down_flying_animation()
    {
        //transform.GetComponentInParent<Rigidbody2D>().velocity.y(Vector2.up);
        if (Time.timeScale == 1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + up_and_down, transform.position.z);

        }
    }

    public void uppo()
    {
        up_and_down = 0.01f;
        Invoke("downo", 2f);
    }
    public void downo()
    {
        up_and_down = -0.01f;
        Invoke("uppo", 2f);
    }

    public void get_damage_function(float damage_amount)
    {
        starGuard_health = starGuard_health - damage_amount;
    }

    void OnCollisionEnter2D(Collision2D other) // when player collide with enemy
    {
        if (other.gameObject.tag == "arrow")
        {
            starGuard_health = starGuard_health - 50f;
        }
        if (other.gameObject.tag == "taurus")
        {
            starGuard_health = starGuard_health - 250f;
        }

        //

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
            starGuard_health = starGuard_health - 50f;
        }

        if (other.gameObject.tag == "pisces")
        {
            starGuard_health = starGuard_health - 50f;
        }
    }

}//////////////
