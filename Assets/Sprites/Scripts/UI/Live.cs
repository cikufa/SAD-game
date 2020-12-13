using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Live : MonoBehaviour
{
    public Color offColor;
    public Color onColor;

    public void SetOff()
    {
        GetComponent<Image>().color = offColor;
        GetComponent<Animator>().enabled = false;
        GetComponent<RectTransform>().localScale = new Vector3(.55f, .55f, 1);
    }

    public void SetOn()
    {
        GetComponent<Image>().color = onColor;
        GetComponent<Animator>().enabled = true;
        GetComponent<RectTransform>().localScale = new Vector3(.6f, .6f, 1);
    }
}
