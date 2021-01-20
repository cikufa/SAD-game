using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLvl : MonoBehaviour
{
    string mapNumberToLoad;

    private void Start()
    {
        //GameManager.Instance.mapNumber++;
        Invoke("Calculate", .5f);
        
    }

    void Calculate()
    {
        PlayerPrefs.SetString("checkpointIsValid", "false");
        mapNumberToLoad = GameManager.Instance.mapNumber >= 3 ? string.Empty : "Map" + (GameManager.Instance.mapNumber + 1).ToString();
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

    public void OnClickBackToMenu()
    {
        GameManager.Instance.LoadLevel("Menu");
    }
}
