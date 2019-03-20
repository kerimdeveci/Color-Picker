/* 
*Copyright (c) FoxGame
*/

using GoogleMobileAds.Api;
using System;
using UnityEngine;

public class AdsManager : MonoBehaviour {

	public static AdsManager instance;
	BannerView bannerView;
	public InterstitialAd interstitial;
	AdRequest requestBanner;
	AdRequest requestInterstitial;
#if UNITY_ANDROID
	public string AppID;
	public string BannerId;
	public string InterstitialId;
#elif UNITY_IOS
	public string AppID="ca-app-pub-1501030234998564~3021770463";
	public string BannerId="ca-app-pub-3940256099942544/6300978111";
	public string InterstitialId="ca-app-pub-3940256099942544/1033173712";
#else
	public string AppID;
	public string BannerId;
	public string InterstitialId;
#endif

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			Set();
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
		
	}

	void Start()
	{
		ShowBanner();
		RequestInterstitial();
	}

	void Update()
	{

	}

	public void Set()
	{
		//realTimeSinceStartup = Time.realtimeSinceStartup;
		MobileAds.Initialize(AppID);
		bannerView = new BannerView(BannerId, AdSize.SmartBanner, AdPosition.Bottom);
		requestBanner = new AdRequest.Builder().Build();
		RequestInterstitial();
	}

	public void RequestInterstitial()
	{
		interstitial = new InterstitialAd(InterstitialId);
		requestInterstitial = new AdRequest.Builder().Build();
		interstitial.LoadAd(requestInterstitial);


		// Called when an ad request has successfully loaded.
		interstitial.OnAdLoaded += HandleOnAdLoaded;
		// Called when an ad request failed to load.
		interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
		// Called when an ad is shown.
		interstitial.OnAdOpening += HandleOnAdOpened;
		// Called when the ad is closed.
		interstitial.OnAdClosed += HandleOnAdClosed;
		// Called when the ad click caused the user to leave the application.
		interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

	}

	//--------------------gecis-----------------------
	public void HandleOnAdLoaded(object sender, EventArgs args)
	{
		Debug.Log("Gecis Yuklendi");
	}

	public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		Debug.Log("Gecis Yuklenemedi message: "
							+ args.Message);
	}

	public void HandleOnAdOpened(object sender, EventArgs args)
	{
		Debug.LogFormat("Gecis acildi");

	}

	public void HandleOnAdClosed(object sender, EventArgs args)
	{

		Debug.Log("Gecis Kapatildi");

		if (!interstitial.IsLoaded())
		{
			RequestInterstitial();
		}
	}

	public void HandleOnAdLeavingApplication(object sender, EventArgs args)
	{
		Debug.Log("gecis tiklama uygulamayı kapatti");
	}
	//--------------------gecis-----------------------


	// Called when an ad request has successfully loaded.
	void HandleAdLoaded(object sender, EventArgs e)
	{
		Debug.Log(" Banner Reklam Yuklendi");

	}
	// Called when an ad request failed to load.
	void HandleAdFailedToLoad(object sender, EventArgs e)
	{
		Debug.Log("Banner Yuklenemedi");

		Invoke("ShowBanner", 10);
	}
	// Called when an ad is clicked.
	void HandleAdOpened(object sender, EventArgs e)
	{
		Debug.Log("Reklama Tiklandi");
	}
	// Called when the user is about to return to the app after an ad click.
	void HandleAdClosing(object sender, EventArgs e)
	{
		Debug.Log("Reklam Kapandi");

	}
	// Called when the user returned from the app after an ad click.
	void HandleAdClosed(object sender, EventArgs e)
	{
		Debug.Log("Oyuna Devam");

	}
	// Called when the ad click caused the user to leave the application.
	void HandleAdLeftApplication(object sender, EventArgs e)
	{
		Debug.Log("Reklama Tiklandi uygulamadan cikildi");

	}
	public void ShowBanner()
	{

		bannerView.LoadAd(requestBanner);
		bannerView.Show();
		bannerView.OnAdLoaded -= HandleAdLoaded;
		bannerView.OnAdFailedToLoad -= HandleAdFailedToLoad;
		bannerView.OnAdOpening -= HandleAdOpened;
		bannerView.OnAdClosed -= HandleAdClosed;

		// Called when an ad request has successfully loaded.
		bannerView.OnAdLoaded += HandleAdLoaded;
		// Called when an ad request failed to load.
		bannerView.OnAdFailedToLoad += HandleAdFailedToLoad;
		// Called when an ad is clicked.
		bannerView.OnAdOpening += HandleAdOpened;
		// Called when the user returned from the app after an ad click.
		bannerView.OnAdClosed += HandleAdClosed;
	}

	public void ShowInterstitial()
	{
		if (interstitial.IsLoaded())
		{
			interstitial.Show();
		}
		else
		{
			RequestInterstitial();
		}

	}

	public void Show_Banner()
	{
		if (bannerView != null)
		{
			Debug.Log("Show current banner");
			bannerView.Show();
		}
	}

	public void Hide_Banner()
	{
		if (bannerView != null)
		{
			Debug.Log("Hide current banner");
			bannerView.Hide();
		}
	}
}



