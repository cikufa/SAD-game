using System;

public class EventBroker
{
    public static Action GameOver,win;
    public static Action<int> updateLifeInUi;

    public static void CallGameOver()
    {
        GameOver?.Invoke();
    }

    public static void CallWin()
    {
        win?.Invoke();
    }

    public static void CallUpdateLifeInUi(int life)
    {
        updateLifeInUi?.Invoke(life);
    }

}
