using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public int SceneID;
    public GameObject InfoPanel;
    public GameObject MainPanelle;
    public GameObject WarningPanelle;

    public GameObject Sound;
    public bool ftPermission;
    public bool pcounter = true;
    public bool isMuted;

    public Text soundButton;

    public bool boolLockLEVEL1;
    public bool boolLockLEVEL2;
    public bool boolLockLEVEL3;
    public bool boolLockLEVEL4;
    public bool boolLockLEVEL5;
    public bool boolLockLEVEL6;

    void Start()
    {
        //lp =
        
        FindObjectOfType<AudioManagerStart>().Play("MainTheme");
       // playFirstTime(ftPermission);
        // = 1;
    }

    public void playFirstTime(bool value)
    {
        FindObjectOfType<AudioManagerStart>().Play("MainTheme");
    }

    // Update is called once per frame
    void Update()
    {
       /* if (pcounter ==true)
        {
            FindObjectOfType<AudioManagerStart>().Play("MainTheme");
            pcounter = false;
        }*/
    }

    public void ClickContinueGameButton()
    {//
        //SceneManager.LoadScene(6);
        //levelsPanel lp = new levelsPanel();
        //SceneManager.LoadScene(lp.);
        //GameObject thePlayer = GameObject.Find("Canvaske");
        //levelsPanel lp = thePlayer.GetComponent<levelsPanel>();

        //SceneManager.LoadScene(playerScript.boolLockLEVEL1);
        //gameData data = saveNloadSystem.LoadPlayer();
        FindObjectOfType<AudioManagerStart>().Stop("MainTheme");
        LaodPGameData();
        if (boolLockLEVEL6 == false)
        {
            Debug.Log("konktar");
            SceneManager.LoadScene(6);
        }

        else if (boolLockLEVEL5 == false)
        {
            SceneManager.LoadScene(15);
        }

        else if (boolLockLEVEL4 == false)
        {
            SceneManager.LoadScene(12);
        }

        else if (boolLockLEVEL3 == false)
        {
            SceneManager.LoadScene(13);
        }

        else if (boolLockLEVEL2 == false)
        {
            SceneManager.LoadScene(9);
        }

        else if (boolLockLEVEL1 == false)
        {
            SceneManager.LoadScene(8);
        }

        else
        {
            Debug.Log("blank space");
        }


        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene(SceneID);



    }

    public void ClickPlayNewGameButton(bool value)
    {
        //oyun stopke
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        WarningPanelle.gameObject.SetActive(value);
        
        //SceneManager.LoadScene(8);

    }

    public void yesNoQuestionResult(bool value)
    {
        if (value)
        {
            levelsPanel lp = new levelsPanel();
            lp.boolLockLEVEL2 = true;
            lp.boolLockLEVEL3 = true;
            lp.boolLockLEVEL4 = true;
            lp.boolLockLEVEL5 = true;
            lp.boolLockLEVEL6 = true;
            lp.SaveGameData();

            FindObjectOfType<AudioManagerStart>().Stop("MainTheme");
            SceneManager.LoadScene(8);
        }
        else
        {
            WarningPanelle.gameObject.SetActive(false);
        }
    }

    public void ClickShowAllLevelsButton(bool value)
    {
        if (value == true)
        {
            SceneManager.LoadScene(7);
        }
        if (value == false)
        {
            SceneManager.LoadScene(0);
        }
        //oyun stopke
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        

    }
    public void ClickSoundOnnOffButton()
    {
        //bool value;
        //value = 
        //buton rengi solsun
        // sesi kapatsın
        Color coco = new Color(1, 0, 1, 1);
        Color coco2 = new Color(1, 0, 1, 0.3f);
        //Debug.LogError("asdfas    " + soundButton.color);
        if (soundButton.color == coco)
        {
            FindObjectOfType<AudioManagerStart>().Pause("MainTheme");
            soundButton.color = coco2;
        }

        else if (soundButton.color == coco2)
        {
            FindObjectOfType<AudioManagerStart>().Play("MainTheme");
            soundButton.color = coco;

        }


        Debug.Log("sesi kapat/aç");
    }

    public void ClickInfoButton(bool value)
    {
        MainPanelle.gameObject.SetActive(!value);
        InfoPanel.gameObject.SetActive(value);
    }

    public void ClickExitGameButton()
    {
        //SceneManager.LoadScene(3);
        Application.Quit();
    }
    public void ClickBackButton(int sceneno)
    {
        SceneManager.LoadScene(sceneno);
        
    }

    public void LaodPGameData()
    {
        gameData data = saveNloadSystem.LoadPlayer();


        boolLockLEVEL1 = data.boolLockLEVEL1;
        boolLockLEVEL2 = data.boolLockLEVEL2;
        boolLockLEVEL3 = data.boolLockLEVEL3;
        boolLockLEVEL4 = data.boolLockLEVEL4;
        boolLockLEVEL5 = data.boolLockLEVEL5;
        boolLockLEVEL6 = data.boolLockLEVEL6;
        //lastDungeonID = data.lastDungeonID;

    }







}//////
