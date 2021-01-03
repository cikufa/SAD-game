using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class puaseManager : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseCanvasPanel;
    public void OnClickReplaytLevel()
    {
        PlayerPrefs.SetString("checkpointIsValid", "false");
        PauseCanvasPanel.SetActive(false);
        GameManager.Instance.ReplayLevel();
    }
    public void pause()
    {
        PauseCanvasPanel.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
}
    public void resume()
    {
        PauseCanvasPanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void OnClickHome()
    {
        PauseCanvasPanel.SetActive(false);
        Time.timeScale = 1f;
        GameManager.Instance.forHome();
        //SceneManager.LoadScene("Menu");
    }
    public void OnClickSound()
    {
        if (AudioListener.volume != 0)
        {
            AudioListener.volume = 0f;
        }
        else
            AudioListener.volume = 3f;
    }

}
