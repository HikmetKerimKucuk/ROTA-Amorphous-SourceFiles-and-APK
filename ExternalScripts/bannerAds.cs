using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class bannerAds : MonoBehaviour
{
    private BannerView bannerReklami;
    AdRequest reklamistegi;
    void Start()
    {
        bannerReklami = new BannerView("ca-ap-pub-3940256099942544/6300978111", AdSize.Banner, AdPosition.Bottom);

        reklamistegi = new AdRequest.Builder().Build();
        //bannerReklami.LoadAd(reklamistegi);
        // bannerReklami.Show();


    }

    // Update is called once per frame
    void Update()
    {

    }
    public void showBannerAds()
    {
        if (reklamistegi!=null)
        {
            bannerReklami.LoadAd(reklamistegi);
            bannerReklami.Show();
            Debug.Log("banner geldi");
        }
        
        

    }
    public void hideBannerAds()
    {
        bannerReklami.Hide();
        Debug.Log("banner gg");
    }


}///////

