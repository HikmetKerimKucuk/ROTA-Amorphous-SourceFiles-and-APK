using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SagittariusBow : MonoBehaviour
{
    public int Sagitarrius_direction;
    public GameObject arrowOBJ;
    public float launch_force;
    public Transform shoot_point;

    //Basic_movement_code bmc_class;
    Vector2 bowDirection;
    int bow_dr_carpan;
    float deltax;
    float deltay;
    float derece;
    bool attackdelayer;


    double angle;
    double radians;
    double result;

    public Animator animBow;
    public Slider DegreeSlider;

    BasicMovements bm;
    CharSwitcher cs;
    Vector2 vec;

    void Start()
    {
        bm = GameObject.FindGameObjectWithTag("Player").GetComponent<BasicMovements>();
        cs = GameObject.FindGameObjectWithTag("Player").GetComponent<CharSwitcher>();
        //  Sagitarrius_direction = 1;
        Sagitarrius_direction = 1;
        bow_dr_carpan = 1;

        attackdelayer = false;



    }

    public void SliderOnOff(bool onoff)
    {
        DegreeSlider.gameObject.SetActive(onoff);
    }

    public void SliderCancel()
    {
        if (cs.current_form_id != 2)
        {
            if (DegreeSlider.gameObject.activeInHierarchy)
            {
                DegreeSlider.gameObject.SetActive(false);
            }
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        if (bm.Android_or_Windows == 0 ) //Android
        {
            angle = DegreeSlider.value;
            radians = angle * (Math.PI / 180);
            result = Math.Tan(radians);

        }
        else if (bm.Android_or_Windows == 1 ) //Windows
        {
            Vector2 bowPosition = transform.position;
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            bowDirection = mousePosition - bowPosition;
            deltax = bowDirection.x;
            deltay = bowDirection.y;
        }
        
        
        //float derece = Mathf.Abs(deltay) /(deltax);
        okyonusorgulama();
        //transform.right = Sagitarrius_direction * bowDirection * bow_dr_carpan;
        if (Input.GetKeyDown(KeyCode.D)) //arujo
        {
            Sagitarrius_direction = 1;
            //transform.GetChild(2).GetChild(1).GetChild(0).transform.Rotate(0, 180, 0);
            // transform.GetChild(1).Rotate(0, -180, 0);
            // bowDirection = (mousePosition - bowPosition)*(-1);
            bow_dr_carpan = 1;

        }
        if (Input.GetKeyDown(KeyCode.A)) //arujo
        {
            Sagitarrius_direction = -1;
            //transform.GetChild(2).GetChild(1).GetChild(0).transform.Rotate(0, -180, 0);
            //transform.GetChild(1).Rotate(0, 180, 0);
            // bowDirection = (mousePosition - bowPosition) * (1);
            bow_dr_carpan = -1;
        }

        /* if (Input.GetMouseButtonDown(1))
         {
             animBow.SetBool("attack", true);
         }

         if (Input.GetMouseButtonUp(1))
         {
             animBow.SetBool("attack", false);
         }*/
        if (bm.Android_or_Windows == 1)
        {
            if (Input.GetMouseButton(0))
            {
                //Throw_an_arrow();

            }
            if (Input.GetMouseButtonDown(0))
            {
                //Throw_an_arrow();
                animBow.SetBool("idle", false);
                animBow.SetBool("attack", true);

            }
            if (Input.GetMouseButtonUp(0))
            {
                Throw_an_arrow();
                animBow.SetBool("attack", false);
                animBow.SetBool("idle", true);
            }
        }
        

        /*  Vector2 bowPosition =  transform.GetChild(2).GetChild(1).GetChild(0).transform.position;
          Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
          Vector2 bowDirection = mousePosition - bowPosition;
          transform.GetChild(2).GetChild(1).transform.right = Sagitarrius_direction * bowDirection;*/
    }

    /*public void direction_control()
    {
        Sagitarrius_direction = bmc_class.Sagitarrius_direction; 
    }*/
    public void LeftSide()
    {
        Sagitarrius_direction = -1;
    }

    public void RightSide()
    {
        Sagitarrius_direction = 1;

    }

    public void okyonusorgulama()
    {
        if (bm.Android_or_Windows == 0 ) //Android 
        {
            
            if (Sagitarrius_direction == 1)
            {
                if (0 <= result && result <= 1)
                {
                    vec = new Vector2(1, (float)result/1);
                    transform.right = Sagitarrius_direction * vec * bow_dr_carpan;
                }
                else if (result <= 0 && result >= -1)
                {
                    vec = new Vector2(1, (float)result / 1);
                    transform.right = Sagitarrius_direction * vec * bow_dr_carpan;
                }
            }

            else if (Sagitarrius_direction == -1)
            {
                if (0 <= result && result <= 1)
                {
                    vec = new Vector2(-1, (float)result / 1);
                    transform.right =  vec ;
                }

                else if (result <= 0 && result >= -1)
                {
                    vec = new Vector2(-2.55f, (float)result / 1);
                    transform.right =  vec ;
                }
            }

        }
    
        else if (bm.Android_or_Windows == 1 ) //Windows
        {
            if (Sagitarrius_direction == 1)
            {
                float derece = Mathf.Abs(deltay) / (deltax);
                if (0 <= derece && derece <= 1)
                {
                    transform.right = Sagitarrius_direction * bowDirection * bow_dr_carpan;
                }
            }
            else if (Sagitarrius_direction == -1)
            {
                float derece = Mathf.Abs(deltay) / (deltax);
                if (derece <= 0 && derece >= -1)
                {
                    transform.right = Sagitarrius_direction * bowDirection * bow_dr_carpan;
                }
            }
        }
        
    }
    public void Throw_an_arrow()
    {
        /*GameObject new_arrow = Instantiate(arrow, shoot_point.position, shoot_point.rotation);
        new_arrow.GetComponent<Rigidbody2D>().velocity = transform.GetChild(2).GetChild(1).GetChild(1).transform.right * launch_force;*/
        if (attackdelayer == false)
        {
            if (cs.current_form_id == 2)
            {
                FindObjectOfType<AudioManager>().Play("attackSagittarius");
                animBow.SetBool("idle", false);
                animBow.SetBool("attack", true);

                GameObject new_arrow = Instantiate(arrowOBJ, shoot_point.position, shoot_point.rotation);
                new_arrow.GetComponent<Rigidbody2D>().velocity = transform.right * launch_force;
                Invoke("stopArrowAnim", 0.05f);
                //stopArrowAnim();
                attackdelayer = true;
                Invoke("attackdelaytime", 0.5f);
            }
            else
            {
                //
            }
        }
        
        //animBow.SetBool("attack", false);
        
    }
    public void attackdelaytime()
    {
        attackdelayer = false;
    }

    public void stopArrowAnim()
    {
        animBow.SetBool("idle", true);
        animBow.SetBool("attack", false);
    }
}///////////
