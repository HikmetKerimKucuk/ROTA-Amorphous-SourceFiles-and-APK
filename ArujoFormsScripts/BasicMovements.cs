using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovements : MonoBehaviour
{
    Rigidbody2D arujo_rbody;
    public GameObject Sagittarius;
    public GameObject Scorpio;

    public float arujo_form_speed;
    public float arujo_form_jumpforce;
    public float fallMultiplier ;
    public float lowJumpMultiplier ;

    public bool player_isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    public float rememberGroundedFor;
    float lastTimeGrounded;

    public int defaultAdditionalJumps = 1;
    int additionalJumps;

    public float x = 0;
    float last_direction = 1;
    public float my_player_scale;

    //public Transform SpaceBG;
    

    public float hiz;
    Vector3 currenteu;
    public bool flipCharacter;
    
    public Animator animScorpio;
    public Animator animSagittarius;

    public int move_button;
    public int jump_button;

    public int Android_or_Windows;
    //if int=0 means >>> android
    //if int=1 means >>> windows
    public bool jumpPermission_forAndroid;
    int jumpCounter;
    public int batDeathCount;


    CharSwitcher cs;
    void Start()
    {
        cs = GameObject.FindGameObjectWithTag("Player").GetComponent<CharSwitcher>();

        flipCharacter = false;
        hiz = 20;
        //skill = true;
        
        arujo_rbody = GetComponent<Rigidbody2D>();
        my_player_scale = 1;
        move_button = 0;
        jump_button = 0;
        jumpPermission_forAndroid = true;

        jumpCounter = 0;
        batDeathCount = 0;
        isGroundedChecker = GameObject.FindWithTag("Player").transform.GetChild(0);
    }

    void Update()
    {
        Move();
        Jump();
        BetterJump();
        DoubleJump();
        CheckIfGrounded();

        transform.localScale = new Vector2(last_direction, 1); 

       /* if (Input.GetKey(KeyCode.P))
        {
            defaultAttack(true);
            saldirScorpio(true);
            saldirSagittarius(true);
            animSagittarius.SetBool("idle", false);
            animScorpio.SetBool("idle", false);
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            defaultAttack(false);
            //gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.SetActive(false);
            saldirScorpio(false);
            animSagittarius.SetBool("idle", false);
            animScorpio.SetBool("idle", false);
            saldirSagittarius(false);
        }
       */
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            animSagittarius.SetBool("move", false);
            animScorpio.SetBool("move", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //animSagittarius.SetBool("move", false);
            animScorpio.SetBool("idle", false);
            animScorpio.SetBool("jump", true);

            animSagittarius.SetBool("idle", false);
            animSagittarius.SetBool("jump", true);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            //animSagittarius.SetBool("move", false);
            animScorpio.SetBool("idle", false);
            animScorpio.SetBool("jump", false);

            animSagittarius.SetBool("idle", false);
            animSagittarius.SetBool("jump", false);
        }

    }

    public void lefttt()
    {
        move_button = -1;

        if (cs.current_form_id == 0 || cs.current_form_id == 3) //default + gemini
        {
            FindObjectOfType<AudioManager>().Play("moveDefault");

        }
        else if (cs.current_form_id == 1) //scorpio
        {
            FindObjectOfType<AudioManager>().Play("moveScorpio");
        }
        else if (cs.current_form_id == 2) //sagittarius
        {
            FindObjectOfType<AudioManager>().Play("moveSagittarius");
        }

        //FindObjectOfType<AudioManager>().Play("moveDefault");
        /*animScorpio.SetBool("move", true);
        animScorpio.SetBool("idle", false);*/

        animSagittarius.SetBool("move", true);
        animSagittarius.SetBool("idle", false);
    }

    public void righttt()
    {
        move_button = 1;

        if (cs.current_form_id == 0 || cs.current_form_id == 3) //default + gemini
        {
            FindObjectOfType<AudioManager>().Play("moveDefault");
        }
        else if (cs.current_form_id == 1) //scorpio
        {
            FindObjectOfType<AudioManager>().Play("moveScorpio");
        }
        else if (cs.current_form_id == 2) //sagittarius
        {
            FindObjectOfType<AudioManager>().Play("moveSagittarius");
        }

        //FindObjectOfType<AudioManager>().Play("moveDefault");
        /*animScorpio.SetBool("move", true);
        animScorpio.SetBool("idle", false);*/

        animSagittarius.SetBool("move", true);
        animSagittarius.SetBool("idle", false);

    }
    public void nomove()
    {
        move_button = 0;

        if (cs.current_form_id == 0 || cs.current_form_id == 3) //default + gemini
        {
            FindObjectOfType<AudioManager>().Stop("moveDefault");
            FindObjectOfType<AudioManager>().Stop("moveScorpio");
            FindObjectOfType<AudioManager>().Stop("moveSagittarius");
        }
        else if (cs.current_form_id == 1) //scorpio
        {
            FindObjectOfType<AudioManager>().Stop("moveDefault");
            FindObjectOfType<AudioManager>().Stop("moveScorpio");
            FindObjectOfType<AudioManager>().Stop("moveSagittarius");
        }
        else if (cs.current_form_id == 2) //sagittarius
        {
            FindObjectOfType<AudioManager>().Stop("moveDefault");
            FindObjectOfType<AudioManager>().Stop("moveScorpio");
            FindObjectOfType<AudioManager>().Stop("moveSagittarius");
        }

        //FindObjectOfType<AudioManager>().Stop("moveDefault");

        animSagittarius.SetBool("move", false);
        animSagittarius.SetBool("idle", true);

        animScorpio.SetBool("move", false);
        animScorpio.SetBool("idle", true);
    }
    public void jumppp()
    {
        jumpCounter++;
        jump_button = 1;

        if (jumpCounter <2)
        {
            if (cs.current_form_id == 0|| cs.current_form_id == 3) //default + gemini
            {
                FindObjectOfType<AudioManager>().Play("jumpDefault");
            }
            else if (cs.current_form_id == 1) //scorpio
            {
                FindObjectOfType<AudioManager>().Play("jumpScorpio");
            }
            else if (cs.current_form_id == 2) //sagittarius
            {
                FindObjectOfType<AudioManager>().Play("jumpSagittarius");
            }
            
        }
        

        animScorpio.SetBool("idle", false);
        animScorpio.SetBool("jump", true);

        animSagittarius.SetBool("idle", false);
        animSagittarius.SetBool("move", false);
        animSagittarius.SetBool("jump", true);
    }
    public void no_jumppp()
    {
        jump_button = 0;

        //Invoke("soundDelay", 0.2f);
        //FindObjectOfType<AudioManager>().Stop("jumpSound");
        animScorpio.SetBool("idle", true);
        animScorpio.SetBool("jump", false);

        animSagittarius.SetBool("idle", true);
        animSagittarius.SetBool("jump", false);
    }
    void Move()
    {

        if (Android_or_Windows == 0) // Android
        {
            if (GetComponent<Rigidbody2D>().bodyType != RigidbodyType2D.Static)
            {
                x = move_button;

                float moveBy = x * arujo_form_speed;

                //arujo_rbody.velocity = new Vector2(moveBy, arujo_rbody.velocity.y);
                // float last_direction = -1;

                if (x < 0)
                {
                    //transform.localScale = new Vector2(-1, 1); // normalde-1,1
                    my_player_scale = -1;
                    arujo_rbody.velocity = new Vector2(moveBy, arujo_rbody.velocity.y);
                    //last_direction = -1;
                    devrilGit(5);

                    Sagittarius.transform.localScale = new Vector2(-1, 1);
                    Scorpio.transform.localScale = new Vector2(-1, 1);

                    animScorpio.SetBool("move", true);
                    animScorpio.SetBool("idle", false);

                    animSagittarius.SetBool("idle", false);
                    animSagittarius.SetBool("move", true);
                    //samc_class.Sagitarrius_direction = 1;
                    //Sagitarrius_direction = 1;
                    //SpaceBG.position = new Vector3(SpaceBG.position.x - 0.1f, SpaceBG.position.y, SpaceBG.position.z);
                }
                else if (x > 0)
                {
                    my_player_scale = 1;
                    //transform.localScale = new Vector2(1, 1); // normalde 1,1
                    arujo_rbody.velocity = new Vector2(moveBy, arujo_rbody.velocity.y);
                    //last_direction = 1;
                    devrilGit(-5);

                    animScorpio.SetBool("idle", false);
                    animScorpio.SetBool("move", true);

                    animSagittarius.SetBool("idle", false);
                    animSagittarius.SetBool("move", true);
                    //samc_class.Sagitarrius_direction = -1;
                    // Sagitarrius_direction = -1;
                    Sagittarius.transform.localScale = new Vector2(1, 1);
                    Scorpio.transform.localScale = new Vector2(1, 1);

                    //SpaceBG.position = new Vector3(SpaceBG.position.x + 0.1f, SpaceBG.position.y, SpaceBG.position.z);
                }

                else if (x == 0)
                {
                    animScorpio.SetBool("move", false);
                    animSagittarius.SetBool("move", false);
                    //animSagittarius.SetBool("idle", true);
                    //animScorpio.SetBool("idle", true);
                }
            }
        }


        else if (Android_or_Windows == 1) // Windows
        {
            x = Input.GetAxisRaw("Horizontal");

            float moveBy = x * arujo_form_speed;

            if (x < 0)
            {
                arujo_rbody.velocity = new Vector2(moveBy, arujo_rbody.velocity.y);
                animScorpio.SetBool("move", true);
                animScorpio.SetBool("idle", false);

                animSagittarius.SetBool("move", true);
                animSagittarius.SetBool("idle", false);
                Sagittarius.transform.localScale = new Vector2(-1, 1);
                Scorpio.transform.localScale = new Vector2(-1, 1);
                devrilGit(5);
                /* if (flipCharacter == true)
                 {
                 last_direction = -1;

             }*/

                //samc_class.Sagitarrius_direction = 1;
                //Sagitarrius_direction = 1;
            }
            else if (x > 0)
            {
                animSagittarius.SetBool("idle", false);
                animSagittarius.SetBool("move", true);

                animScorpio.SetBool("idle", false);
                animScorpio.SetBool("move", true);
                //my_player_scale = 1;
                //transform.localScale = new Vector2(1, 1); // normalde 1,1
                Sagittarius.transform.localScale = new Vector2(1, 1);
                Scorpio.transform.localScale = new Vector2(1, 1);
                arujo_rbody.velocity = new Vector2(moveBy, arujo_rbody.velocity.y);
                last_direction = 1;
                devrilGit(-5);
                /* if (flipCharacter == true)
                 {
                     last_direction = -1;
                 }*/
                //samc_class.Sagitarrius_direction = -1;
                // Sagitarrius_direction = -1;

            }
            else if (x == 0)
            {
                animSagittarius.SetBool("idle", true);
                //animScorpio.SetBool("idle", true);
            }
        }
        /*
        Hocam dönem sonu ödevimiz vize notunun %20sine mi denk düşüyor yoksa dönem sonu genel notumuzun %20sine mi tekabül edecek.

        */
    }

    void Jump()
    {
        if (Android_or_Windows == 0) // Android
        {
            if (jump_button == 1 && (player_isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor || additionalJumps > 0))
            {
                if (GetComponent<Rigidbody2D>().bodyType != RigidbodyType2D.Static)
                {
                    if (player_isGrounded)
                    {
                        arujo_rbody.velocity = new Vector2(arujo_rbody.velocity.x, arujo_form_jumpforce);
                        additionalJumps--;
                        animScorpio.SetBool("idle", false);
                        jump_button = 0;
                    }
                    
                    //animScorpio.SetBool("jump", true);

                   /* animSagittarius.SetBool("idle", false);
                   if (!player_isGrounded && jumpPermission_forAndroid)
                   {
                        Debug.Log("kramp");
                        arujo_rbody.velocity = new Vector2(arujo_rbody.velocity.x, arujo_form_jumpforce);
                        //additionalJumps--;
                        animScorpio.SetBool("idle", false);
                        //animScorpio.SetBool("jump", true);

                        animSagittarius.SetBool("idle", false);
                        jumpPermission_forAndroid = false;
                  }*/
                    


                }
            }
            else if (jump_button == 0)
            {

            }
        }

        else if (Android_or_Windows == 1) // Windows
        {
            if (Input.GetKeyDown(KeyCode.Space) && (player_isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor || additionalJumps > 0))
            {
                if (GetComponent<Rigidbody2D>().bodyType != RigidbodyType2D.Static)
                {
                    arujo_rbody.velocity = new Vector2(arujo_rbody.velocity.x, arujo_form_jumpforce);
                    additionalJumps--;
                    animScorpio.SetBool("idle", false);
                    //animScorpio.SetBool("jump", true);

                    animSagittarius.SetBool("idle", false);

                }
            }
        }
    }

    public void DoubleJump()
    {
        if (jump_button == 1 && !player_isGrounded && jumpPermission_forAndroid)
        {
            arujo_rbody.velocity = new Vector2(arujo_rbody.velocity.x, arujo_form_jumpforce*0.9f);
            //additionalJumps--;
            animScorpio.SetBool("idle", false);
            //animScorpio.SetBool("jump", true);

            animSagittarius.SetBool("idle", false);
            jumpPermission_forAndroid = false;
        }
    }

    public void jumpPermission(bool value)
    {
        //jumpPermission_forAndroid = value;
    }

    void BetterJump()
    {
        if (Android_or_Windows == 0) // Android
        {
            if (GetComponent<Rigidbody2D>().bodyType != RigidbodyType2D.Static)
            {
                if (jumpPermission_forAndroid == true)
                {
                    arujo_rbody.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1)* Time.deltaTime;
                }
                else if (jumpPermission_forAndroid == false && arujo_rbody.velocity.y < 0)
                {
                    arujo_rbody.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1)* Time.deltaTime;
                }
            }
        }

        else if (Android_or_Windows == 1) // Windows
        {
            if (GetComponent<Rigidbody2D>().bodyType != RigidbodyType2D.Static)
            {
                if (arujo_rbody.velocity.y < 0)
                {
                    arujo_rbody.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
                }
                else if (arujo_rbody.velocity.y > 0 && jump_button != 1)
                {
                    arujo_rbody.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
                }
            }
        }
        
    }

    void CheckIfGrounded()
    {
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);

        if (colliders != null)
        {
            jumpPermission_forAndroid = true;
            player_isGrounded = true;
            additionalJumps = defaultAdditionalJumps;
            jumpCounter = 0;
            //FindObjectOfType<AudioManager>().Stop("jumpSound");
            //animScorpio.SetBool("jump", false);
            //Invoke("soundDelay", 0.2f);

        }
        else
        {
            if (player_isGrounded)
            {
                
                lastTimeGrounded = Time.time;
                
            }
            player_isGrounded = false;
            //FindObjectOfType<AudioManager>().Stop("jumpSound");
            //Invoke("soundDelay", 0.2f);
            //jumpPermission_forAndroid = false;
        }
    }
   

    public void attackAnimScorpio(bool value)
    {
        if (value == true)
        {
            animScorpio.SetBool("idle", false);
            animScorpio.SetBool("attack", value);
        }
        else
        {
            //animScorpio.SetBool("idle", true);
            animScorpio.SetBool("attack", false);
        }
        
    }
    public void attackAnimSagittarius(bool value)
    {
        animSagittarius.SetBool("idle", !value);
        animSagittarius.SetBool("attack", value);
    }


    void OnTriggerEnter2D(Collider2D nesne) // when player enter the field
    {
        /* if (nesne.gameObject.tag == "bats")
         {
             Debug.Log("yarasa adam bak buraya");
             hasarAl(50);
             //Invoke("destroy_arrow", 0.5f);
         }*/

    }

    public void devrilGit(int direction)
    {
        currenteu += new Vector3(0, 0, direction) * Time.deltaTime * hiz;
        //transform.eulerAngles = currenteu;
        gameObject.transform.GetChild(1).transform.eulerAngles = currenteu;
        gameObject.transform.GetChild(4).transform.eulerAngles = currenteu;
    }

    void soundDelay()
    {
        FindObjectOfType<AudioManager>().Stop("jumpSound");
    }

}//////
