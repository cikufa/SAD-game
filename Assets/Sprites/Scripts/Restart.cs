using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void OnClickRestartLevel()
    {
        //GameManager.Instance.TogglePause();
        //EventBroker.CallRetryLevel();
        PlayerPrefs.SetString("checkpointIsValid", "false");
        transform.parent.gameObject.SetActive(false);
        GameManager.Instance.ReplayLevel();
    }

    public void OnClickLoadCheckpoint()
    {
        //GameManager.Instance.TogglePause();
        EventBroker.CallRetryLevel();
        transform.parent.gameObject.SetActive(false);
    }
}
