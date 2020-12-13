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
        ManageLifes(life);
    }

    void ManageLifes(int life)
    {
        if(life >= 3)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<Live>().SetOn();
            }
        }

        if(life == 2)
        {
            transform.GetChild(0).GetComponent<Live>().SetOff();
            transform.GetChild(1).GetComponent<Live>().SetOn();
            transform.GetChild(2).GetComponent<Live>().SetOn();

        }

        if(life == 1)
        {
            transform.GetChild(0).GetComponent<Live>().SetOff();
            transform.GetChild(1).GetComponent<Live>().SetOff();
            transform.GetChild(2).GetComponent<Live>().SetOn();
        }

        if(life <= 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<Live>().SetOff();
            }
        }
    }

    private void OnDestroy()
    {
        EventBroker.updateLifeInUi -= IsHit;
    }
}
