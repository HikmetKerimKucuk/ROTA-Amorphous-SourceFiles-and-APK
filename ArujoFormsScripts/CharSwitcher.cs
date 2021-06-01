using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Arujo_form;
    public GameObject Scorpion_form;
    public GameObject Sagittarius_form;
    public GameObject Gemini_form;

    public int current_form_id;

    BasicMovements bm;
    PlayerEntity mt;
    GeminiSkill gs;

    public bool longpress;
    public float timeCounter;

    int charid;
    void Start()
    {
        charid = 0;
        mt = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEntity>();
        bm = GameObject.FindGameObjectWithTag("Player").GetComponent<BasicMovements>();
        //gs = GameObject.FindGameObjectWithTag("gemini").GetComponent<GeminiSkill>();
        current_form_id = 0;
        

        
    }

    public void presske(bool value)
    {
        //Invoke("",2.2f);
        longpress = value;
    }

    // Update is called once per frame
    void Update()
    {
        //avatar_switching_function(charid);

        if (longpress == true)
        {
            timeCounter += 0.09f;
        }
        if (longpress == false)
        {
            timeCounter = 0;
        }
        if (timeCounter > 2.0f)
        {
            FindObjectOfType<AudioManager>().Play("formTransition");
            Debug.Log("df");
            current_form_id = 0;
            charid = 0;
            switch_avatar(0);
           
        }

    }

    public void useSkillButton(int charID)
    {
        if (mt.playerMana >= 100)
        {
                charid = charID;
            avatar_switching_function(charid);
        }
        if (charID == 666)
        {
            avatar_switching_function(0);
        }
        
        
    }

    public void switch_avatar(int avatar_form_id)
    {
        switch (avatar_form_id)
        {
            case 0://ARUJO
                bm.flipCharacter = false;
                Arujo_form.gameObject.SetActive(true);
                Scorpion_form.gameObject.SetActive(false);
                Sagittarius_form.gameObject.SetActive(false);
                Gemini_form.gameObject.SetActive(false);
                break;

            case 1://SCORPİO
                bm.flipCharacter = true;
                Arujo_form.gameObject.SetActive(false);
                Scorpion_form.gameObject.SetActive(true);
                Sagittarius_form.gameObject.SetActive(false);
                Gemini_form.gameObject.SetActive(false);
                break;

            case 2://SAGİTTARİUS
                bm.flipCharacter = true;
                Arujo_form.gameObject.SetActive(false);
                Scorpion_form.gameObject.SetActive(false);
                Sagittarius_form.gameObject.SetActive(true);
                Gemini_form.gameObject.SetActive(false);
                break;

            case 3://GEMINI
                bm.flipCharacter = false;
                Arujo_form.gameObject.SetActive(false);
                Scorpion_form.gameObject.SetActive(false);
                Sagittarius_form.gameObject.SetActive(false);
                Gemini_form.gameObject.SetActive(true);
                break;

        }
    }


    public void avatar_switching_function( int whichCharacter)
    {
        if (bm.Android_or_Windows == 0) //Android
        {
            if (whichCharacter == 0) //arujo
            {
                FindObjectOfType<AudioManager>().Play("formTransition");
                switch_avatar(0);
                current_form_id = 0;
            }

            if (current_form_id != 1 && whichCharacter == 1) //scorpio
            {
                FindObjectOfType<AudioManager>().Play("formTransition");
                mt.playerMana -= 100;
                switch_avatar(1);
                current_form_id = 1;

            }

            if (current_form_id != 2 && whichCharacter == 2) // sagittarius
            {
                FindObjectOfType<AudioManager>().Play("formTransition");
                mt.playerMana -= 100;
                switch_avatar(2);
                current_form_id = 2;
            }

            if (current_form_id != 3 && whichCharacter == 3) // gemini
            {
                FindObjectOfType<AudioManager>().Play("formTransition");
                mt.playerMana -= 100;
                switch_avatar(3);
                current_form_id = 3;
                //gs.BecameGemini();
            }
        }

        //8888888888888888888888888888888888888888888888888888

        else if (bm.Android_or_Windows == 1) //Windows
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) //arujo
            {
                switch_avatar(0);
                current_form_id = 0;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2)) //scorpio
            {
                if (mt.playerMana >= 100)
                {
                    mt.playerMana -= 100;
                    switch_avatar(1);
                    current_form_id = 1;
                }

            }

            if (Input.GetKeyDown(KeyCode.Alpha3)) // sagittarius
            {
                if (mt.playerMana >= 100)
                {
                    mt.playerMana -= 100;
                    switch_avatar(2);
                    current_form_id = 2;
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha4)) // gemini
            {
                if (mt.playerMana >= 100)
                {
                    mt.playerMana -= 100;
                    switch_avatar(3);
                    current_form_id = 3;
                }
            }

        }

        
    }

    


}//////////
