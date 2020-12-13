using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void OnClickRestart()
    {
        //GameManager.Instance.TogglePause();
        EventBroker.CallRetryLevel();
        transform.parent.gameObject.SetActive(false);
    }
}
