using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiscesSkill : MonoBehaviour
{
    public List<Transform> Spawnpoints;
    GameObject newPiscesPF;
    public GameObject Piscesx8;
    public bool is_triggered = false;
    public int pisceCount = 8;
    public bool igniter;
    int counter;
    public float ReloadSkillTime;

    public float additionalTime;
    public bool  piscesPermission;

    //public CircleCollider2D EnemyZone;

    string targetID;

    Pisces ps;
    PlayerEntity pe;
    public GameObject playerre;
    //public GameObject gobj_target;

    public bool nowattack;
    public bool destroyAllPisces;
    bool enough;

    bool boski;
    void Start()
    {
       pe = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEntity>();
        ps = transform.gameObject.GetComponent<Pisces>();
        piscesPermission = false;
        boski = false;
        igniter = true;
        additionalTime = 0.2f;
        enough = true;
        //gobj_target = null;


        destroyAllPisces = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            //gobj_target = null;
            if (igniter == true)
            {
                counter = 0;
                spawn_bats(counter);
                igniter = false;
            }

        }

        else if (piscesPermission == true)
        {
            //gobj_target = null;
            if (igniter == true)
            {
                playerre.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                //EnemyZone.radius = 1;
                pe.playerMana = pe.playerMana - 100;
                counter = 0;
                igniter = false; 
                piscesPermission = false;
                spawn_bats(counter);
                
            }
        }
        //Debug.Log(counter);
    }

    public void UsePiscesSkill(bool value)
    {
        if (igniter == true)
        {
            if (pe.playerMana >= 100)
            {
                // EnemyZone.radius = 14;
                enough = true;
                destroyAllPisces = false;
                piscesPermission = value;

            }
        }
       


    }

    IEnumerator selfCallFunction(int index)
    {
        yield return new WaitForSeconds(index * additionalTime);
        Vector3 vv = new Vector3(Spawnpoints[index].position.x, Spawnpoints[index].position.y, -3);
        FindObjectOfType<AudioManager>().Play("piscesSpawn");
        newPiscesPF = Instantiate(Piscesx8, vv, Quaternion.identity);
        //EnemyZone.radius = 2 * index;
        if (index == 7)
        {
            if (enough == true)
            {
                Invoke("ReloadPiscesSkill", ReloadSkillTime);
                //EnemyZone.radius = 1f; 
                //index = 8;
                Invoke("ReloadPiscesSkill", ReloadSkillTime);
                //EnemyZone.radius = 1.31f;
                Invoke("PiscesDelay", 0.3f);

                /* (boski == true)
                {
                    destroyAllPisces = true;
                }*/
                Invoke("BodyUnlock", 0.5f);
                enough = false;
            }
        }
    }
   
    void BodyUnlock()
    {
        playerre.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
    void PiscesDelay()
    {
        nowattack = true;
    }

    void spawn_bats(int index)
    {
        nowattack = false;
        for (int i = 0; i <= 7; i++)
        {
            StartCoroutine(selfCallFunction(i));
            if (i == 7)
            {
                
                
            }
        }

    }

    public void ReloadPiscesSkill()
    {
        igniter = true;
        //nowattack = false; //açççç
    }

    



}//////////
