﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    public void PlayGame()
    {
        GameManager.Instance.OnPlayButtonClickedInMenu();
    }
}
