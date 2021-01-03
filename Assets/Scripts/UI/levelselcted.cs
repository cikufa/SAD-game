using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelselcted : MonoBehaviour
{
    public int level;
    public void OnClickSelectedLevel()
    {
        GameManager.Instance.OnLevelSelectedButtonClickedInMenu(level);
    }
}
