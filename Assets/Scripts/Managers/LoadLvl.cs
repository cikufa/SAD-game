using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLvl : MonoBehaviour
{
    string mapNumberToLoad;

    private void Start()
    {
        GameManager.Instance.mapNumber++;
        PlayerPrefs.SetString("checkpointIsValid", "false");
        mapNumberToLoad = GameManager.Instance.mapNumber >= 3 ? string.Empty : "Map"+GameManager.Instance.mapNumber .ToString();
        //nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        GameManager.Instance.SaveProgress();
    }


    public void OnClickLoadNewLvl()
    {       
        if (mapNumberToLoad != string.Empty)
        {
            GameManager.Instance.LoadLevel(mapNumberToLoad);
        }
        else
        {
            Debug.Log("No more maps.");
        }
    }
}
