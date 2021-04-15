using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Advertisements : MonoBehaviour, IUnityAdsListener
{


    private string gameId = "4006653";
    bool testMode = true;

    public string placementIdBanner = "bannerad1";
    public string placementIdInterstitial = "video";
    public string placementIdRewardVideo = "rewardvideo1";

    // Start is called before the first frame update
    void Start()
    {
        // this is the listener for the ad services
        Advertisement.AddListener(this);

        Advertisement.Initialize(gameId, testMode);

        // Run the banner as a coroutine after initialization is done for adverts
        StartCoroutine(ShowBannerWhenInitialized());
    }

    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        // Load banner using my placementID
        Advertisement.Banner.Show(placementIdBanner);
    }


    public void ShowInterstitialAd()
    {
        // check if UnityAds is ready before calling the show method
        if (Advertisement.IsReady())
        {
            Advertisement.Show(placementIdInterstitial);
        }
        else
        {
            Debug.Log("Interstitial ad not ready at the moment!");
        }
    }

    public void ShowRewardedVideo()
    {
        if (Advertisement.IsReady(placementIdRewardVideo))
        {
            Advertisement.Show(placementIdRewardVideo);
        }
        else
        {
            Debug.Log("Interstitial ad not ready at the moment!");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
    }

    public void OnUnityAdsDidError(string message)
    {
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Special code to stop your game or music
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            // method here that rewards the user 10gems
            Debug.Log("YAY you watched the full ad");
        }
        else if (showResult == ShowResult.Skipped)
        {
            Debug.Log("boo you skipped the ad");
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.Log("woops... the ad didn't show");
        }
    }

    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }
}