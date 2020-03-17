using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdManager : MonoBehaviour, IUnityAdsListener
{
    private string gameId = "3500900",
        rewardVid = "rewardedVideo",
        normalVid = "video",
        bannerid = "gameBanner", 
        skipVid = "skipVideo",
        buyVid = "buyVideo",
        getMoreCoinsVid = "getMoreCoinsVid";
    private SaveSystem saveSystem;
    private LevelController levelController;
    private ShopLogic shopLogic;
    private void Awake()
    {
        saveSystem = GetComponent<SaveSystem>();
        levelController = GetComponent<LevelController>();
        shopLogic = GetComponent<ShopLogic>();
        Advertisement.Initialize(gameId, true);
        StartCoroutine(ShowBannerWhenReady());
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    }
    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(bannerid))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(bannerid);
    }
    public void normalAd()
    {
        if (Random.Range(0, 100) > 53 && Random.Range(0,100) < 54)
        {
            if (Advertisement.IsReady(normalVid))
            {
                Advertisement.AddListener(this);
                Advertisement.Show(normalVid);
            }
        } else
        {
            saveSystem.SaveLvlData();
            saveSystem.SaveCoinData();
            levelController.NextLvl();
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            if (placementId == normalVid)
            {
                saveSystem.SaveLvlData();
                saveSystem.SaveCoinData();
                levelController.NextLvl();
            }
            if (placementId == skipVid)
            {
                saveSystem.SaveLvlData();
                saveSystem.SaveCoinData();
                levelController.NextLvl();
            }
            if (placementId == buyVid)
            {
                shopLogic.BuyBackPack();
            }
            if (placementId == getMoreCoinsVid)
            {
                saveSystem.localCoin += 50;
                saveSystem.SaveCoinData();
                saveSystem.SaveLvlData();
                levelController.NextLvl();
            }
        }
        else if (showResult == ShowResult.Skipped)
        {
        }
        else if (showResult == ShowResult.Failed)
        {
        }
        Advertisement.RemoveListener(this);
    }
    public void OnUnityAdsReady(string placementId)
    {
        Advertisement.AddListener(this);
        Advertisement.Show(placementId);
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
//Создать новые айдишники done
//Сделать проверку каждого айдишника done
//после проверки вставить функционал 
