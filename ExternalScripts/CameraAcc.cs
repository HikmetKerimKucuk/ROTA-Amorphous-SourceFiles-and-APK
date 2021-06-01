using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAcc : MonoBehaviour
{

    // Start is called before the first frame update
    //Rigidbody2D rb;
    
    float dirx;
    float diry;
    float gyroSpeed = 0.5f;
    public Rigidbody2D rb;
    public Camera cam;
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        //transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
            dirx = Input.acceleration.x * gyroSpeed;
            diry = Input.acceleration.y * gyroSpeed;
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, -4f, 4f), Mathf.Clamp(transform.position.y, -3f, 3f));
            rb.velocity = new Vector2(dirx, diry);
       
    }

    /*void FixedUpdate()
    {
        if (cam.gameObject.activeInHierarchy == true)
        {
            rb.velocity = new Vector2(dirx, diry);

        }
        
    }*/

}/////////
 
