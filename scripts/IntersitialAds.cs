using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersitialAds : MonoBehaviour
{
    Bird bird;
    private InterstitialAd _interstitialAd;

    // AdMob Interstitial Ad Unit ID
#if UNITY_ANDROID
    private string _adUnitId = "ca-app-pub-1369010337660048/5513378952"; // Test Ad ID
#elif UNITY_IPHONE
    private string _adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
    private string _adUnitId = "unused";
#endif

    public void Start()
    {
        bird = FindAnyObjectByType<Bird>();
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus =>
        {
            Debug.Log("AdMob Initialized.");
            LoadInterstitialAd();
        });
    }

    /// <summary>
    /// Loads an interstitial ad.
    /// </summary>
    public void LoadInterstitialAd()
    {
        // Clean up the old ad before loading a new one.
        if (_interstitialAd != null)
        {
            _interstitialAd.Destroy();
            _interstitialAd = null;
        }

        Debug.Log("Loading the interstitial ad.");

        // Create our request used to load the ad.
        var adRequest = new AdRequest();

        // Send the request to load the ad.
        InterstitialAd.Load(_adUnitId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                if (error != null || ad == null)
                {
                    Debug.LogError("Interstitial ad failed to load with error: " + error);
                    return;
                }

                Debug.Log("Interstitial ad loaded successfully.");

                // Assign the loaded ad to the instance variable
                _interstitialAd = ad;

                // Register event handlers
                RegisterEventHandlers(_interstitialAd);
            });
    }

    /// <summary>
    /// Shows the interstitial ad.
    /// </summary>
    public void ShowInterstitialAd()
    {
        if (_interstitialAd != null && _interstitialAd.CanShowAd())
        {
            Debug.Log("Showing interstitial ad.");
            _interstitialAd.Show();
        }
        else
        {
            Debug.LogError("Interstitial ad is not ready yet.");
            bird.RestartGame();
        }
    }

    /// <summary>
    /// Registers event handlers for the interstitial ad.
    /// </summary>
    private void RegisterEventHandlers(InterstitialAd interstitialAd)
    {
        interstitialAd.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Interstitial ad closed.");
            LoadInterstitialAd(); // Reload the ad for the next time
            bird.RestartGame();
        };

        interstitialAd.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Interstitial ad failed to open: " + error);
            LoadInterstitialAd(); // Reload ad in case of failure
            bird.RestartGame();
        };
    }

    // Optional: Handle the application pause and resume to prevent potential issues with ad loading
    void OnApplicationPause(bool isPaused)
    {
        if (isPaused && _interstitialAd != null)
        {
            _interstitialAd.Destroy();
            _interstitialAd = null;
        }
    }
}
