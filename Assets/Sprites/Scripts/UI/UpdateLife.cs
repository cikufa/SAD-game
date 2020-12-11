using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLife : MonoBehaviour
{
    private void Start()
    {
        EventBroker.updateLifeInUi += IsHit;
    }

    void IsHit(int life)
    {
        GetComponent<Text>().text = life.ToString();
    }

    private void OnDestroy()
    {
        EventBroker.updateLifeInUi -= IsHit;
    }
}
