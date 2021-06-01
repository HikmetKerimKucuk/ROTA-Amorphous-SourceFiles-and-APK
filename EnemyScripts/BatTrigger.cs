using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bats;
    public Transform bats_spawn_point;
    //public Transform bats_spawn_point1;
    //public Transform bats_spawn_point2;
    public bool is_triggered = false;
    public int bat_count = 3;

    void Start()
    {

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
                spawn_bats();
                is_triggered = true;
            }
        }

    }

    void spawn_bats()
    {
        for (int i = 0; i < bat_count; i++)
        {
            GameObject new_bat = Instantiate(bats, bats_spawn_point.position, Quaternion.identity);
        }
        /* GameObject new_bat = Instantiate(bats, bats_spawn_point.position, Quaternion.identity);
         GameObject new_bat1 = Instantiate(bats, bats_spawn_point1.position, Quaternion.identity);
         GameObject new_bat2 = Instantiate(bats, bats_spawn_point2.position, Quaternion.identity);*/
    }


}/////////
