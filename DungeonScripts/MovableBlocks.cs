using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableBlocks : MonoBehaviour
{
    public GameObject TriggerObject;
    bool movement_permission;

    public List<Transform> points; //The int value for next point index
    int nextID = 0; //The value of that applies to ID for changing
    int idChangeValue = 1; //Speed of movement or flying
    public float speed;

    Transform target;
    float next_way_point_distance = 3f;
    float nextshoot_time;

    Path mypath;
    int current_waypoint = 0;
    bool reached_ebd_point = false;
    bool firstTime;

    Seeker seeker;
    Rigidbody2D rb;

    void Start()
    {
        firstTime = true;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        speed = 0;

        InvokeRepeating("Update_path", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        TriggerPatrol();

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

        float distance = Vector2.Distance(rb.position, mypath.vectorPath[current_waypoint]);

        if (distance < next_way_point_distance)
        {
            current_waypoint++;
        }

    }

    void MoveToNextPoint()
    {
        Transform goalPoint = points[nextID];
        {
            if (goalPoint.transform.position.x > transform.position.x)
            {
                //transform.localScale = new Vector3(1, 1, 1);
                //FindObjectOfType<AudioManager>().Play("wallSound");
                target = points[nextID].transform;
            }
            else
            {
                //transform.localScale = new Vector3(1, 1, 1);
                target = points[nextID].transform;
            }

            transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);

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

    }

    public void TriggerPatrol()
    {
        if (!TriggerObject.activeInHierarchy)
        {
            if (firstTime)
            {
                FindObjectOfType<AudioManager>().Play("wallSound");
                firstTime = false;
            }
            
            //movement_permission = true;
            speed = 3;
        }
    }
}////////
