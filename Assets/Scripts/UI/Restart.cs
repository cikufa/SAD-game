using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject joystick;
    public GameObject brake;

    public void OnClickRestartLevel()
    {
        //GameManager.Instance.TogglePause();
        //EventBroker.CallRetryLevel();
        PlayerPrefs.SetString("checkpointIsValid", "false");
        gameOverPanel.SetActive(false);
        GameManager.Instance.ReplayLevel();
    }

    public void OnClickLoadCheckpoint()
    {
        //GameManager.Instance.TogglePause();
        EventBroker.CallRetryLevel();
        gameOverPanel.SetActive(false);
        joystick.SetActive(true);
        brake.SetActive(true);
    }
}
