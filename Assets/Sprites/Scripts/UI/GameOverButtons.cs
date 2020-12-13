using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverButtons : MonoBehaviour
{
    public GameObject withCheckpoint;
    public GameObject withoutCheckpoint;

    void Start()
    {
        if (PlayerPrefs.HasKey("checkpointIsValid") && PlayerPrefs.GetString("checkpointIsValid") == "true")
        {
            withCheckpoint.SetActive(true);
        }
        else
        {
            withoutCheckpoint.SetActive(true);
        }
    }
    
}
