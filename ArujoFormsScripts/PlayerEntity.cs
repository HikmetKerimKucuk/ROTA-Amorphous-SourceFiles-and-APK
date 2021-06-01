using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerEntity : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerHealth;
    public float playerMana;

    public int attack_button;
    public float hiz;
    Vector3 currenteu;
    //float damage;

    BasicMovements bm;
    InGamePanelsBehaviors igpb;
    CharSwitcher cs;
    DungeonEntity de;
    public revardedAds DeathScreen;

    bool firstTime;
    bool firstTimeS;
    bool endSound;

    public void yes_attack()
    {
        attack_button = 1;
    }
    public void no_attack()
    {
        attack_button = 0;
    }

    void Start()
    {
        Time.timeScale = 1.0f;
        bm = GameObject.FindGameObjectWithTag("Player").GetComponent<BasicMovements>();
        igpb = GameObject.FindGameObjectWithTag("gamecanvas").GetComponent<InGamePanelsBehaviors>();
        cs = GameObject.FindGameObjectWithTag("Player").GetComponent<CharSwitcher>();
        //DeathScreen = GameObject.FindGameObjectWithTag("deathpanel").GetComponent<revardedAds>();

        firstTime = true;
        firstTimeS = true;
        playerHealth = 1000;
        playerMana = 1000;

        hiz = 0;
        //damage = 0;
        attack_button = 0;
        endSound = false;
    }

    // Update is called once per frame
    void Update()
    {
        //DeathScreen.gameObject.SetActive(false);
        increaseManaAmountbyTime();
        decraseHealthAmountbyTime();
        defaultAttack();

        igpb.SetHealth(playerHealth, 1000);
        igpb.SetMana(playerMana, 1000);


        if (playerMana <= 0)
        {
            WhenManaRunOut();
        }
        consumeMana();
        deathFunction();
    }

    public void deathFunction()
    {
        if (playerHealth <= 0)
        {
            //gameObject.SetActive(false);
            if (!DeathScreen.gameObject.activeInHierarchy)
            {
                FindObjectOfType<AudioManager>().Play("playerDeath");
            }
            DeathScreen.gameObject.SetActive(true);
            

            if (Time.timeScale == 1.0)
                Time.timeScale = 0.0f;
            else
                Time.timeScale = 0.0f;

            
            //igpb.InGameMenu.SetActive(true);
        }

    }

    public void WhenManaRunOut()
    {
        //cs.current_form_id = 0;
        //cs.switch_avatar(0);
        //cs.avatar_switching_function(0);
        //cs.current_form_id = 0;
        //cs.switch_avatar(0);
        cs.useSkillButton(666);

    }

    public void defaultAttack()
    {
        if (bm.Android_or_Windows == 0) //Android 
        {
            if (attack_button == 1)
            {
                hiz = 20;

                if (cs.current_form_id == 0) //Default Form Attack
                {
                    if (firstTime)
                    {
                        FindObjectOfType<AudioManager>().Play("attackDefault");
                        firstTime = false;
                    }

                    gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    currenteu += new Vector3(0, 0, 50) * Time.deltaTime * hiz;
                    gameObject.transform.GetChild(1).transform.eulerAngles = currenteu;

                }
                else if (cs.current_form_id == 1) // Scorpio Attack
                {
                    if (firstTime)
                    {
                        FindObjectOfType<AudioManager>().Play("attackScorpio");
                        firstTime = false;
                    }
                    Vector3 vv = new Vector3(0, 0, 0);
                    gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    currenteu += new Vector3(0, 0, 50) * Time.deltaTime * hiz;
                    gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).transform.eulerAngles = currenteu;
                    gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).transform.eulerAngles = vv;
                    bm.attackAnimScorpio(true);
                }
                else if (cs.current_form_id == 3) // Gemini Attack
                {
                    if (firstTime)
                    {
                        FindObjectOfType<AudioManager>().Play("attackDefault");
                        firstTime = false;
                    }
                    gameObject.transform.GetChild(4).gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    currenteu += new Vector3(0, 0, 50) * Time.deltaTime * hiz;
                    gameObject.transform.GetChild(4).transform.eulerAngles = currenteu;
                }

            }


            else
            {
                hiz = 0;

                if (cs.current_form_id == 0) //Default Form Attack
                {
                    FindObjectOfType<AudioManager>().Stop("attackDefault");
                    FindObjectOfType<AudioManager>().Stop("attackScorpio");
                    firstTime = true;
                    gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.SetActive(false);
                }
                else if (cs.current_form_id == 1) // Scorpio Attack
                {

                    gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.SetActive(false);
                    bm.attackAnimScorpio(false);
                    //bm.animScorpio.SetBool("idle", true);
                    FindObjectOfType<AudioManager>().Stop("attackDefault");
                    FindObjectOfType<AudioManager>().Stop("attackScorpio");
                    firstTime = true;
                }

                else if (cs.current_form_id == 3) // Gemini Attack
                {
                    FindObjectOfType<AudioManager>().Stop("attackDefault");
                    FindObjectOfType<AudioManager>().Stop("attackScorpio");
                    firstTime = true;
                    gameObject.transform.GetChild(4).gameObject.transform.GetChild(1).gameObject.SetActive(false);
                }



            }

        }

        else if (bm.Android_or_Windows == 1) //Windows
        {
            if (Input.GetKey(KeyCode.P))
            {
                hiz = 20;

                if (cs.current_form_id == 0) //Default Form Attack
                {
                    gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    currenteu += new Vector3(0, 0, 50) * Time.deltaTime * hiz;
                    gameObject.transform.GetChild(1).transform.eulerAngles = currenteu;

                }
                else if (cs.current_form_id == 1) // Scorpio Attack
                {
                    gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    currenteu += new Vector3(0, 0, 50) * Time.deltaTime * hiz;
                    gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).transform.eulerAngles = currenteu;
                    bm.attackAnimScorpio(true);
                }
                else if (cs.current_form_id == 3) // Gemini Attack
                {
                    gameObject.transform.GetChild(4).gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    currenteu += new Vector3(0, 0, 50) * Time.deltaTime * hiz;
                    gameObject.transform.GetChild(4).transform.eulerAngles = currenteu;
                }
            }

            if (Input.GetKeyUp(KeyCode.P))
            {
                hiz = 0;

                if (cs.current_form_id == 0) //Default Form Attack
                {
                    gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.SetActive(false);
                }
                else if (cs.current_form_id == 1) // Scorpio Attack
                {
                    gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.SetActive(false);
                    bm.attackAnimScorpio(false);
                }

                else if (cs.current_form_id == 3) // Gemini Attack
                {
                    gameObject.transform.GetChild(4).gameObject.transform.GetChild(1).gameObject.SetActive(false);
                }
            }
        }

    }

    //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
    public void increaseManaAmountbyTime()
    {
        if (playerMana >= -100 && playerMana < 1000)
        {
            if (cs.current_form_id == 0)
            {
                playerMana += 0.2f;
            }

        }

    }
    public void decraseHealthAmountbyTime()
    {
        if (playerHealth > 0 && playerHealth <= 1000)
        {
            if (cs.current_form_id == 1)
            {
                playerHealth += 0.15f;
            }
            else
            {
                playerHealth += 0.05f;

            }
        }
    }
    //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
    void OnCollisionEnter2D(Collision2D nesne)
    {
        if (nesne.gameObject.tag == "movable_spike")
        {
            Debug.Log("visible spike değiyor");
            playerHealth = playerHealth - 50;

        }

        if (nesne.gameObject.tag == "visiblespikes" || nesne.gameObject.tag == "unvisiblespikes")
        {
            if (cs.current_form_id != 3)
            {
                Debug.Log("visible spike değiyor");
                playerHealth = playerHealth - 30;
            }


        }

        if (nesne.gameObject.tag == "skilldiamond")
        {
            FindObjectOfType<AudioManager>().Play("diaSound");
            nesne.gameObject.SetActive(false);
            /*for (int i = 0; i < 2000; i++)
            {
                nesne.gameObject.transform.localScale = new Vector3(nesne.gameObject.transform.localScale.x - 0.001f, nesne.gameObject.transform.localScale.y - 0.001f);
                if (nesne.gameObject.transform.localScale.x <= 0.3f)
                {
                    nesne.gameObject.SetActive(false);
                    Debug.Log("atta dia");
                }
            }*/


        }

        /*if (nesne.gameObject.tag == "enemy")
        {
            nesne.gameObject.SetActive(false);

        }*/

        // XXX PLAYER HASAR ALMA ATAMALARI XXX//
        if (nesne.gameObject.tag == "bats" && cs.current_form_id != 3)
        {
            hasarAl(1.2f);
        }

        /*if (nesne.gameObject.tag == "meleeblade" && cs.current_form_id != 3)
        {
            hasarAl(20);
        }*/
        // XXX PLAYER HASAR ALMA ATAMALARI XXX//





        if (nesne.gameObject.tag == "nextdungeon")
        {
            FindObjectOfType<AudioManager>().Play("endSound");
            Invoke("levelEndDelayer", 1.5f);

        }

    }

    void levelEndDelayer()
    {
        endSound = true;
    }

    //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
    public void hasarAl(float damage_miktari)
    {
        playerHealth = playerHealth - damage_miktari;
    }

    void OnCollisionStay2D(Collision2D nesne)
    {
        if (nesne.gameObject.tag == "visiblespikes")
        {
            FindObjectOfType<AudioManager>().Play("unvisiblespike");
            Debug.Log("visible spike değiyor");
            hasarAl(0.2f);

        }

        if (nesne.gameObject.tag == "unvisiblespikes")
        {
            Debug.Log("unvisible spike meydana çıktı");
            hasarAl(0.2f);

        }

        if (nesne.gameObject.tag == "nextdungeon")
        {
            if (endSound)
            {
                if (nesne.gameObject.name == "Dungeon0Gate")
                {
                    levelsPanel lp = new levelsPanel();
                    //lp.boolLockLEVEL2 = true;
                    lp.boolLockLEVEL3 = true;
                    lp.boolLockLEVEL4 = true;
                    lp.boolLockLEVEL5 = true;
                    lp.boolLockLEVEL6 = true;
                    lp.SaveGameData();
                    //lp.LaodPGameData();
                    Debug.Log("kızılay  " + lp.boolLockLEVEL2);
                    SceneManager.LoadScene(7);
                }
                else if (nesne.gameObject.name == "Dungeon1Gate")
                {
                    levelsPanel lp = new levelsPanel();
                    //lp.boolLockLEVEL2 = true;
                    //lp.boolLockLEVEL3 = true;
                    lp.boolLockLEVEL4 = true;
                    lp.boolLockLEVEL5 = true;
                    lp.boolLockLEVEL6 = true;
                    lp.SaveGameData();
                    //lp.LaodPGameData();
                    Debug.Log("kızılay  " + lp.boolLockLEVEL2);
                    SceneManager.LoadScene(7);
                }
                else if (nesne.gameObject.name == "Dungeon2Gate")
                {
                    levelsPanel lp = new levelsPanel();
                    //lp.boolLockLEVEL2 = true;
                    //lp.boolLockLEVEL3 = true;
                    //lp.boolLockLEVEL4 = true;
                    lp.boolLockLEVEL5 = true;
                    lp.boolLockLEVEL6 = true;
                    lp.SaveGameData();
                    //lp.LaodPGameData();
                    Debug.Log("kızılay  " + lp.boolLockLEVEL2);
                    SceneManager.LoadScene(7);
                }
                else if (nesne.gameObject.name == "Dungeon3Gate")
                {
                    levelsPanel lp = new levelsPanel();
                    //lp.boolLockLEVEL2 = true;
                    //lp.boolLockLEVEL3 = true;
                    //lp.boolLockLEVEL4 = true;
                    //lp.boolLockLEVEL5 = true;
                    lp.boolLockLEVEL6 = true;
                    lp.SaveGameData();
                    //lp.LaodPGameData();
                    Debug.Log("kızılay  " + lp.boolLockLEVEL2);
                    SceneManager.LoadScene(7);
                }
                else if (nesne.gameObject.name == "Dungeon4Gate")
                {
                    levelsPanel lp = new levelsPanel();
                    //lp.boolLockLEVEL2 = true;
                    //lp.boolLockLEVEL3 = true;
                    //lp.boolLockLEVEL4 = true;
                    //lp.boolLockLEVEL5 = true;
                    //lp.boolLockLEVEL6 = true;
                    lp.SaveGameData();
                    //lp.LaodPGameData();
                    Debug.Log("kızılay  " + lp.boolLockLEVEL2);
                    SceneManager.LoadScene(7);
                }



                else if (nesne.gameObject.name == "Dungeon5Gate")
                {
                    levelsPanel lp = new levelsPanel();
                    startPanel sp = new startPanel();
                    //lp.boolLockLEVEL2 = true;
                    //lp.boolLockLEVEL3 = true;
                    //lp.boolLockLEVEL4 = true;
                    //lp.boolLockLEVEL5 = true;
                    //lp.boolLockLEVEL6 = true;

                    lp.SaveGameData();
                    //lp.LaodPGameData();
                    Debug.Log("kızılay  " + lp.boolLockLEVEL2);
                    //sp.InfoPanel.SetActive(true);
                    SceneManager.LoadScene(0);
                }
                /*levelsPanel lp = new levelsPanel();
                //lp.boolLockLEVEL2 = true;
                lp.boolLockLEVEL3 = true;
                lp.boolLockLEVEL4 = true;
                lp.boolLockLEVEL5 = true;
                lp.boolLockLEVEL6 = true;
                lp.SaveGameData();
                //lp.LaodPGameData();
                Debug.Log("kızılay  " + lp.boolLockLEVEL2);
                SceneManager.LoadScene(3);*/
            }


        }




    /*if (nesne.gameObject.tag == "movable_spike")
    {
        Debug.Log("visible spike değiyor");
        can = can - 50 ;
    *
    }*/
}

    public void selfshrink()
    {
        if (true)
        {

        }
    }

    void OnTriggerEnter2D(Collider2D nesne) // when player enter the field
    {

        if (nesne.gameObject.tag == "fireball" && cs.current_form_id != 3)
        {
            hasarAl(20);
        }
        if (nesne.gameObject.tag == "meteroid" && cs.current_form_id != 3)
        {
            FindObjectOfType<AudioManager>().Play("meteorHit");
            hasarAl(5);
        }
        if (nesne.gameObject.tag == "meleeblade" && cs.current_form_id != 3)
        {
            //FindObjectOfType<AudioManager>().Play("unvisiblespike");
            hasarAl(20);
        }
        /*if (nesne.gameObject.tag == "meleeblade" )
        {
            playerHealth += 20;
        }*/

    }


    //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

    public void consumeMana()
    {
        if (cs.current_form_id != 0)
        {
            if (cs.current_form_id == 3)//gemini
            {
                playerMana -= 0.5f;
            }
            if (cs.current_form_id == 1)//scorpio
            {
                playerMana -= 0.3f;
            }
            if (cs.current_form_id == 2)//sagittarius
            {
                playerMana -= 0.1f;
            }
        }

        

    }  


}///////////
