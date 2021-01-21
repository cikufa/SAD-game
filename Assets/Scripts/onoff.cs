using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Cinemachine;

public class onoff : MonoBehaviour
{
    public GameObject l;

    public GameObject parent;
    AIPath p;

    public CinemachineVirtualCamera cinemachine;
    private GameObject player;

    [Space]
    public GameObject joystick;
    public GameObject brake;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    public void OnOff()
    {
        l.SetActive(true);
        Invoke("off", 0.1f);
    }

    public void off()
    {
        l.SetActive(false);
    }

    public void on()
    {
        l.SetActive(true);
        p = parent.GetComponent<AIPath>();
        p.enabled = true;
        Invoke("camera", 1f);

    }

    public void camera()
    {
        cinemachine.m_Follow = player.transform;
        cinemachine.m_Lens.OrthographicSize = 16;
        joystick.SetActive(true);
        brake.SetActive(true);
    }
}
