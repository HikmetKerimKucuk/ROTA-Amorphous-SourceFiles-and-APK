using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SagittariusDash : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float dash_speed;
    private float dash_time;
    public float start_dash_time;
    private int das_direction;

    CharSwitcher bmc_class;
    public bool dash_affirmation;

    public Animator animdash;
    void Start()
    {
        das_direction = 0;
        //rb = GetComponent<Rigidbody2D>();
        bmc_class = GameObject.FindGameObjectWithTag("Player").GetComponent<CharSwitcher>();
        //rb = bmc_class.GameObject.FindObjectOfType<Rigidbody2D>().GetComponent<Basic_movement_code>();
        //rb = bmc_class.GetComponent<Rigidbody2D>();
        dash_time = start_dash_time;
        // bmc_class
        dash_affirmation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bmc_class.current_form_id == 2)
        {
            Debug.Log("yayım ben  bastm");
            if (das_direction == 0)
            {
                if (Input.GetKeyDown(KeyCode.K))
                {
                    animdash.SetBool("move", false);
                    animdash.SetBool("idle", false);
                    animdash.SetBool("dash", true);
                    gameObject.transform.localScale = new Vector2(-1, 1);
                    Debug.Log("k bastm");
                    das_direction = 1;
                }

                else if (Input.GetKeyDown(KeyCode.L))
                {
                    animdash.SetBool("move", false);
                    animdash.SetBool("idle", false);
                    animdash.SetBool("dash", true);
                    gameObject.transform.localScale = new Vector2(1, 1);
                    das_direction = 2;
                    Debug.Log("LLL bastm");
                }
            }

            else
            {
                if (dash_time <= 0)
                {
                    das_direction = 0;
                    dash_time = start_dash_time;
                    //rb.velocity = Vector2.zero; // SAKINCALI 
                }
                else
                {
                    dash_time -= start_dash_time;

                    if (das_direction == 1)
                    {
                        rb.velocity = Vector2.left * dash_speed;
                        //das_direction = 0;
                        Invoke("dash_ender", 0.3f);
                    }

                    if (das_direction == 2)
                    {
                        rb.velocity = Vector2.right * dash_speed;
                        // das_direction = 0;
                        Invoke("dash_ender", 0.3f);
                    }
                }
            }
        }
        else
        {
            //
        }


    }

    void dash_ender()
    {
        rb.velocity = Vector2.zero;
        animdash.SetBool("dash", false);
    }

    public void form_is_Sagitatrius(bool x)
    {
        dash_affirmation = x;
    }


}//////////
