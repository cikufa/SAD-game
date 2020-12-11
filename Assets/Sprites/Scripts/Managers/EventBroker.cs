using System;

public class EventBroker
{
    public static Action GameEnded;
    public static event Action DisableOtherBoosts, CountDownStarted, CountDownFinished, StartTimer, StopTimer, Respawning, RespawnEnded, Collect;
    public static event Action<int> UpdateCollectables, AllCollectables, SetMaxTime;
    public static event Action<int> DetonateDynamite;
    public static event Action ShowAdvertisementMenu, RespawningForCameraPath;
    public static event Action<bool> AdvertisementResult;
    public static event Action StartDrift, StopDrift;
    public static event Action StopBoostParticle;

    //Collision Score
    public static Action OnCollision;

    //UI
    public static Action LFromMenu;

    //ButtonAB reset after respawn
    public static Action ResetButton;

    //whether star has reached its destination
    public static Action StarReached;

    //fired when a level ends and all stars have reached their destination
    public static Action<int> AddTireAndEnergyItem;
    public static Action UpdateEconomyInfo;
    public static Action noStarsObtained;

    public static void CallGameEnded()
    {
        GameEnded?.Invoke();
    }

    public static void CallDisableOtherBoosts()
    {
        DisableOtherBoosts?.Invoke();
    }

    public static void CallCountDownFinished()
    {
        CountDownFinished?.Invoke();
    }

    public static void CallCountDownStarted()
    {
        CountDownStarted?.Invoke();
    }

    public static void CallStartTimer()
    {
        StartTimer?.Invoke();
    }

    public static void CallStopTimer()
    {
        StopTimer?.Invoke();
    }

    public static void CallRespawning()
    {
        Respawning?.Invoke();
    }

    public static void CallRespawnEnded()
    {
        RespawnEnded?.Invoke();
    }

    //UI
    public static void CallLFromMenu()
    {
        LFromMenu?.Invoke();
    }

    //ButtonAB
    public static void CallResetButton()
    {
        ResetButton?.Invoke();
    }

    public static void CallCollect()
    {
        Collect?.Invoke();
    }

    public static void CallRespawningForCameraPath()
    {
        RespawningForCameraPath?.Invoke();
    }

    public static void CallUpdateCollectables(int collected)
    {
        UpdateCollectables?.Invoke(collected);
    }

    public static void CallAdvertisementResult(bool choice)
    {
        AdvertisementResult?.Invoke(choice);
    }

    public static void CallAllCollectables(int allCollectables)
    {
        AllCollectables?.Invoke(allCollectables);
    }

    public static void CallSetMaxTime(int maxTime)
    {
        SetMaxTime?.Invoke(maxTime);
    }

    public static void CallDetonateDynamite(int dynamiteId)
    {
        DetonateDynamite?.Invoke(dynamiteId);
    }

    public static void CallShowAdvertisementMenu()
    {
        ShowAdvertisementMenu?.Invoke();
    }

    public static void CallOnCollision()
    {
        OnCollision?.Invoke();
    }

    public static void CallStartDrift()
    {
        StartDrift?.Invoke();
    }

    public static void CallStopDrift()
    {
        StopDrift?.Invoke();
    }

    public static void CallStarReached()
    {
        StarReached?.Invoke();
    }

    public static void CallAddTireAndEnergyItem(int starNum)
    {
        AddTireAndEnergyItem?.Invoke(starNum);
    }

    public static void CallNoStarsObtained()
    {
        noStarsObtained?.Invoke();
    }

    public static void CallStopBoostParticle()
    {
        StopBoostParticle?.Invoke();
    }

    public static void CallUpdateEconomyInfo()
    {
        UpdateEconomyInfo?.Invoke();
    }
}
