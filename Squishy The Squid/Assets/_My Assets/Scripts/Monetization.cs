using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Monetization : MonoBehaviour, IUnityAdsListener
{
    public bool rewardCoin = false;
    public bool rewardLife = false;
    string GooglePlay_ID = "3570526";
    bool TestMode = true;

    string myPlacementId = "rewardedVideo";

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(GooglePlay_ID, TestMode);
    }
    public void PlaySkipableAd()
    {
        Advertisement.Show();
    }

    public void PlayRewardedAd()
    {
        Advertisement.Show(myPlacementId);
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            // Reward the user for watching the ad to completion.
            if(rewardLife == true)
            {
                PlayerProperties playerProperties = GameObject.FindObjectOfType<PlayerProperties>();
                playerProperties.SecondChance();
            }
            if(rewardCoin == true)
            {
                Debug.Log("TODO Add coin(s)");
            }
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, show the ad:
        if (placementId == myPlacementId)
        {
            
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }
}
