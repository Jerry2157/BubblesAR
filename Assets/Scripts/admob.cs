using UnityEngine;
using System.Collections;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
public class admob : MonoBehaviour {

	private BannerView bannerView;
	private InterstitialAd interstitial;
	private int a;
	private int b;

	void Start()
	{


        PlayerPrefs.SetInt("checkinter", 1);
        Invoke("RequestBanner",0.1f);
		Invoke ("ShowBanner", 1.0f);
		Invoke ("RequestInterstitial", 0.5f);
		//InvokeRepeating ("checkban", 0.2f,0.1f);
		InvokeRepeating ("checkinter", 2.1f,0.1f);
		Invoke ("reset", 3.1f);
	}

    

	private void RequestBanner()
		{
		#if UNITY_EDITOR
		string adUnitId = "unused";
#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-1097069017114775/7797635486";
#elif UNITY_IPHONE
		string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
#else
		string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Top);
		// Register for ad events.

		// Load a banner ad.
		bannerView.LoadAd(createAdRequest());
		//print ("se creo el ad");
		}

	private void RequestInterstitial()
		{
		#if UNITY_EDITOR
		string adUnitId = "unused";
#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-1097069017114775/6379670088";
#elif UNITY_IPHONE
		string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
#else
		string adUnitId = "unexpected_platform";
#endif

        // Create an interstitial.
        interstitial = new InterstitialAd(adUnitId);
		// Register for ad events.

		// Load an interstitial ad.
		interstitial.LoadAd(createAdRequest());
		}

		// Returns an ad request with custom ad targeting.
	private AdRequest createAdRequest()
		{
		return new AdRequest.Builder()
		//Borrar estas lineas cuando entren a produccion (Publiquen)

		//Fin de borrar
		.AddKeyword("game")
		.SetGender(Gender.Male)
		.SetBirthday(new System.DateTime(2000,06,10))
		.TagForChildDirectedTreatment(false)
		.AddExtra("color_bg", "9B30FF")
		.Build();

		}

	public void ShowInterstitial(){
		if (interstitial.IsLoaded()){
		    interstitial.Show();
			print ("se mostro inter");
		}
		else{
	        print("Interstitial is not ready yet.");
			Invoke ("ShowInterstitial", 0.5f);
		}
	}

	public void ShowBanner ()
		{

		bannerView.Show ();
		print ("se mostro banner ad");
		}

		public void HideBanner()
		{
		bannerView.Hide ();
		print ("se oculto el banner");
		}

		public void checkban(){
		a = PlayerPrefs.GetInt ("checkbanner");
		if (a == 1) {
			HideBanner ();
			a = 0;
			PlayerPrefs.SetInt ("checkbanner",0);
		}
		}
		public void checkinter(){
			b = PlayerPrefs.GetInt ("checkinter");
			if (b == 1) {
			    ShowInterstitial ();
			b = 0;
			PlayerPrefs.SetInt ("checkinter",0);
			}
		}
		public void reset(){
		Scene scene = SceneManager.GetActiveScene();
		if (scene.name == "Game-c#") {
			HideBanner ();
			bannerView.Destroy();
		}
		}
		public void OnDestroy(){
		HideBanner ();
		bannerView.Destroy();
		}
		public void OnDisabled(){
		HideBanner ();
		bannerView.Destroy();
		}


}
