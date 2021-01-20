using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackInMenu : MonoBehaviour
{
    public Transform main;

    public void BackToMain()
    {
        main.gameObject.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
