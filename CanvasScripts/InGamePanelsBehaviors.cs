using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGamePanelsBehaviors : MonoBehaviour
{
    public GameObject SkillPanel;
    public bool isActive;

    public Slider healthSlider;
    public Color Low;
    public Color High;

    public Slider manahSlider;
    public Color LowMana;
    public Color HighMana;


    public GameObject PauseButton;
    public GameObject ResumeButton;
    public GameObject SettingsButton;
    public GameObject BackToMenuButton;
    public GameObject RetryButton;
    public GameObject InGameMenu;

    public Image DarkHole;
    public Button soundButton;

    public Button savebutton;
    public bool skill;
    //startPanel sp;
    //public int sceneID;

    PlayerEntity pe;
    Vector3 currenteu;

    void Start()
    {
        skill = true;
        pe = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEntity>();
        //sp = GameObject.FindSceneObjectsOfType<uı>().ge
        InGameMenu.SetActive(false);

    }

    void Update()
    {
        //ClickPauseButton();
        currenteu += new Vector3(0, 0, -50) * Time.deltaTime * 1;
        //DarkHole.transform.eulerAngles = new Vector3(DarkHole.transform.rotation.x, DarkHole.transform.rotation.y, DarkHole.transform.rotation.z + 0.1f);
        DarkHole.transform.eulerAngles = currenteu;
        if (skill == false)
        {
            SkillPanel.SetActive(false);
        }

    }

    public void Open_Close()
    {
        if (skill == true)
        {
            if (SkillPanel != null)
            {
                isActive = SkillPanel.activeSelf;
                SkillPanel.SetActive(!isActive);
            }
        }
    }

    public void ClickPauseButton()
    {
        //oyun stopke
        FindObjectOfType<AudioManager>().Play("pauseClick");
        PauseButton.SetActive(false);
        InGameMenu.SetActive(true);
        savebutton.interactable = false;
        //EditorApplication.isPaused = true;
        if (Time.timeScale == 1.0)
            Time.timeScale = 0.0f;
        else
            Time.timeScale = 1.0f;
    }
    public void ClickResumeButton()
    {
        FindObjectOfType<AudioManager>().Play("resumeClick");
        //EditorApplication.isPaused = true;
        //oyun devamke
        InGameMenu.SetActive(false);
        PauseButton.SetActive(true);
        //pe.reklamizlendimi = false;

        if (Time.timeScale == 0.0)
            Time.timeScale = 1.0f;
        else
            Time.timeScale = 0.0f;

    }
    public void ClickBackToMenuButton()
    {
        // İLERLEMEYİ KAYIT ALTINA AL
        //MAŞN SCENEYE YONLENDIR
        Debug.Log("menuye gidiyosun melihhh");
        /*levelsPanel lp = new levelsPanel();
        lp.boolLockLEVEL2 = true;
        lp.boolLockLEVEL3 = true;
        lp.boolLockLEVEL4 = true;
        lp.boolLockLEVEL5 = true;
        lp.boolLockLEVEL1 = true;
        lp.SaveGameData();*/
        //sp.ClickInfoButton(true);
        SceneManager.LoadScene(0);

    }

    public void ClickSettingsButton()
    {
        //bool value;
        //value = 
        //buton rengi solsun
        // sesi kapatsın
        if (soundButton.image.color == Color.red)
        {
            FindObjectOfType<AudioManager>().mute = false;
            FindObjectOfType<DungeonEntity>().soundSet(false);
            soundButton.image.color = Color.white;

        }

        else if (soundButton.image.color == Color.white)
        {
            FindObjectOfType<AudioManager>().mute = true;
            FindObjectOfType<DungeonEntity>().soundSet(true);
            soundButton.image.color = Color.red;
        }


        Debug.Log("sesi kapat/aç");


    }
   
    public void ClickRetryButton(int sceneID)
    {
        //buton rengi solsun
        // sesi kapatsın
        Debug.Log("yendiien başladın oyuna");
        SceneManager.LoadScene(sceneID);

        if (Time.timeScale == 0.0)
            Time.timeScale = 1.0f;
        else
            Time.timeScale = 1.0f;



    }

    public void SetHealth(float health, float maxHealth)
    {
        //healthSlider.gameObject.SetActive(health <= maxHealth);
        healthSlider.gameObject.SetActive(true);
        healthSlider.value = health;
        healthSlider.maxValue = maxHealth;

        healthSlider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, healthSlider.normalizedValue);
    }

    public void SetMana(float mana, float maxmana)
    {
        //manahSlider.gameObject.SetActive(mana <= maxmana);
        manahSlider.gameObject.SetActive(true);
        manahSlider.value = mana;
        manahSlider.maxValue = maxmana;

        manahSlider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(LowMana, HighMana, manahSlider.normalizedValue);
    }

    

}////////
