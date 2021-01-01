using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToSetting : MonoBehaviour
{
    public Transform setting;

    public void ToSettingMenu()
    {
        setting.gameObject.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
