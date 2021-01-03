using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SetFollow : MonoBehaviour
{
    private GameObject player;
    public CinemachineVirtualCamera cinemachine;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cinemachine.m_Follow = player.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
