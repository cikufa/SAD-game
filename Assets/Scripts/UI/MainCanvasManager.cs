using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasManager : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject win;
    public GameObject joystick;
    public GameObject brake;

    private void Start()
    {
        EventBroker.GameOver += GameOver;
        //EventBroker.win += Win;
    }

    void GameOver()
    {
        gameOver.SetActive(true);
        joystick.SetActive(false);
        brake.SetActive(false);
    }

    //void Win()
    //{
    //    win.SetActive(true);
    //}

    private void OnDestroy()
    {
        EventBroker.GameOver -= GameOver;
        //EventBroker.win -= Win;
    }
}
