using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonEntity : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Diamond;
    public GameObject DungeonGate;

    
    public GameObject DungeonSkill;
    /*public GameObject SagittariusButton;
    public GameObject TaurusButton;
    public GameObject PiscesButton;
    public GameObject GeminiButton;
    public GameObject VirgoButton;*/

    //levelsPanel lp;
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("levelMusic");
        //lp = GameObject.GetComponent<levelsPanel>();
        if (gameObject.tag == "dungeontilemap")
        {
            /*TaurusButton.gameObject.SetActive(true);
            VirgoButton.gameObject.SetActive(true);
            PiscesButton.gameObject.SetActive(true);
            GeminiButton.gameObject.SetActive(true);
            SagittariusButton.gameObject.SetActive(false);
            ScorpioButton.gameObject.SetActive(false);*/
            DungeonSkill.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Diamond.activeInHierarchy == true)
        {
            DungeonGate.gameObject.SetActive(false);
        }
        if (Diamond.activeInHierarchy == false)
        {
            DungeonGate.gameObject.SetActive(true);
            DungeonSkill.gameObject.SetActive(false);
            
        }
    }

    public void shrinkDiamond()
    {
        for (int i = 0; i < 200; i++)
        {
            Diamond.gameObject.transform.localScale = new Vector3(Diamond.gameObject.transform.localScale.x - 0.01f, Diamond.gameObject.transform.localScale.y - 0.01f);
        }

        
    }

    public void soundSet(bool value)
    {
        if (value == false)
        {
            FindObjectOfType<AudioManager>().Play("levelMusic");
        }
        if (value == true)
        {
            FindObjectOfType<AudioManager>().Stop("levelMusic");
        }
        
    }

    


}///////////
