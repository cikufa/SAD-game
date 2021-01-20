using System;

public class EventBroker
{
    public static Action GameOver, RetryLevel,explode;
    public static Action<int> updateLifeInUi;

    public static Action startAim, endAim;

    public static void CallGameOver()
    {
        GameOver?.Invoke();
    }

    //public static void CallWin()
    //{
    //    win?.Invoke();
    //}

    public static void CallUpdateLifeInUi(int life)
    {
        updateLifeInUi?.Invoke(life);
    }

    public static void CallRetryLevel()
    {
        RetryLevel?.Invoke();
    }

    public static void CallExplode()
    {
        explode?.Invoke();
    }

    public static void CallStartAim()
    {
        startAim?.Invoke();
    }

    public static void CallendAim()
    {
        endAim?.Invoke();
    }

}
