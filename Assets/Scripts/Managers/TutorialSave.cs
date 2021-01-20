using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("TutorialSeen") && PlayerPrefs.GetString("TutorialSeen") == "true")
        {
            this.gameObject.SetActive(false);
        }
    }
}
