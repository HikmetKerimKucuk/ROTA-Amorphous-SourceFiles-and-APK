using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class revardedAds : MonoBehaviour
{
    // Start is called before the first frame update
    private RewardBasedVideoAd rAd;
    public string id = "";
    public Button rewardButton;
    public Button continuebutton;
    public Text adsText;

    public GameObject DeathScreen;
    //public GameObject Player;

    PlayerEntity pe;
    public bool yumos;

    void Start()
    {
        //DeathScreen.gameObject.SetActive(false);
        continuebutton.interactable = false;
        rAd = RewardBasedVideoAd.Instance;
        rewardButton.interactable = false;
        rAd.OnAdRewarded += VideoRewarded;
        rAd.OnAdClosed += VideoClosed;
        this.RequestAds();
        adsText.text = "Reklam" +"\n Yukleniyor";
        pe = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEntity>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rAd.IsLoaded())
        {
            rewardButton.interactable = true;
            adsText.text = "Reklam"+ "\n izle";
        }
        else
        {
            rewardButton.interactable = false;
            adsText.text = "Reklam" + "\n Yukleniyor";
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            //continueGameFunction();
            yumos = true;
        }
        //deathFunction();
    }

    private void RequestAds()
    {
        AdRequest request = new AdRequest.Builder().Build();
        this.rAd.LoadAd(request, id);
    }
    public void ShowAds()
    {
        this.rAd.Show();
    }

    private void Reward()
    {
        Debug.Log("DEVAMMMMKEEEEEĞĞĞ");

        //pe.reklamizlendimi = true;
        //SaveSystem.SavePlayer(pe);
        
    }

    private void VideoRewarded(object sender, EventArgs e)
    {
        //Reward(); Debug.Log("DEVAMMMMKEEEEEĞĞĞ");

        yumos = true;
        continuebutton.interactable = true;
        rewardButton.interactable = false;
    }

    private void VideoClosed(object sender, EventArgs e)
    {
        //Invoke("RequestAds", 3f);
        RequestAds();
    }

    public void continueGameFunction()
    {
        if (yumos == true)
        {
           Time.timeScale = 1.0f;
            pe.playerHealth = 700;
            pe.playerMana = 700;
            //pe.gameObject.SetActive(true);
            continuebutton.interactable = false;
            DeathScreen.SetActive(false);
        }
        
    }

    /*public void ClickPlayButton()
    {
        //oyun stopke
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    
    }*/

    /*public void deathFunction()
    {
        if (pe.playerHealth <= 0)
        {
            DeathScreen.gameObject.SetActive(true);
            if (Time.timeScale == 1.0)
                Time.timeScale = 0.0f;
            else
                Time.timeScale = 0.0f;

            
        }

        
    }*/
   /* public void  fero()
    {
        DeathScreen.gameObject.SetActive(true);
    }*/



}///////
