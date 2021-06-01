using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelsPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject LockLEVEL1;
    public GameObject LockLEVEL2;
    public GameObject LockLEVEL3;
    public GameObject LockLEVEL4;
    public GameObject LockLEVEL5;
    public GameObject LockLEVEL6;

    public bool boolLockLEVEL1;
    public bool boolLockLEVEL2; 
    public bool boolLockLEVEL3;
    public bool boolLockLEVEL4;
    public bool boolLockLEVEL5;
    public bool boolLockLEVEL6;

   // public int lastDungeonID;
    void Start()
    {
        
        Debug.Log("hhhh");
        /*LockLEVEL1.gameObject.SetActive(boolLockLEVEL1);
        LockLEVEL2.gameObject.SetActive(boolLockLEVEL2);
        LockLEVEL3.gameObject.SetActive(boolLockLEVEL3);
        LockLEVEL4.gameObject.SetActive(boolLockLEVEL4);
        LockLEVEL5.gameObject.SetActive(boolLockLEVEL5);
        LockLEVEL6.gameObject.SetActive(boolLockLEVEL6);*/
    }

    // Update is called once per frame
    void Update()
    {
        LaodPGameData();
        /*LockLEVEL2.gameObject.SetActive(boolLockLEVEL2);
        LockLEVEL3.gameObject.SetActive(boolLockLEVEL3);
        LockLEVEL4.gameObject.SetActive(boolLockLEVEL4);
        LockLEVEL5.gameObject.SetActive(boolLockLEVEL5);
        LockLEVEL6.gameObject.SetActive(boolLockLEVEL6);*/
    }

    public void LoadDUNGEON(int dungeonID)
    {
        //InGamePanelsBehaviors igpb = new InGamePanelsBehaviors();
        //igpb.sceneID = dungeonID;
        SceneManager.LoadScene(dungeonID);
        FindObjectOfType<AudioManagerStart>().Stop("MainTheme");
    }
    public void backToMainMenu()
    {
        //FindObjectOfType<startPanel>().ftPermission = false;
        FindObjectOfType<AudioManagerStart>().Pause("MainTheme");
        SceneManager.LoadScene(0);
        

    }

    public void breakTheNextLevelBlock()
    {

    }


    public void SaveGameData()
    {
        saveNloadSystem.SavePlayer(this);
        Debug.Log("SAVELEDİM");



    }
    public void LaodPGameData()
    {
        gameData data = saveNloadSystem.LoadPlayer();

        LockLEVEL1.gameObject.SetActive(data.boolLockLEVEL1);
        LockLEVEL2.gameObject.SetActive(data.boolLockLEVEL2);
        LockLEVEL3.gameObject.SetActive(data.boolLockLEVEL3);
        LockLEVEL4.gameObject.SetActive(data.boolLockLEVEL4);
        LockLEVEL5.gameObject.SetActive(data.boolLockLEVEL5);
        LockLEVEL6.gameObject.SetActive(data.boolLockLEVEL6);

        boolLockLEVEL1 = data.boolLockLEVEL1;
        boolLockLEVEL2 = data.boolLockLEVEL2;
        boolLockLEVEL3 = data.boolLockLEVEL3;
        boolLockLEVEL4 = data.boolLockLEVEL4;
        boolLockLEVEL5 = data.boolLockLEVEL5;
        boolLockLEVEL6 = data.boolLockLEVEL6;
        //lastDungeonID = data.lastDungeonID;

    }


}//////
