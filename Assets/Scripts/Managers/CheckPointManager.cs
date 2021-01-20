using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckPointManager : MonoBehaviour
{
    public GameObject Player;
    public Transform startingPoint;

    //public Transform itemsParent;
    public List<Transform> items;
    Dictionary<GameObject, Transform> itemsDictionary;
    public Transform newItemsForCheckpoint;


    [Space]
    public CheckPoint currCheckPoint;

    PlayerController playerRef;

    int currCheckpoint_number = -1;     //child number
    Vector2 currCheckpoint_Position;


    private void Awake()
    {
        if (PlayerPrefs.HasKey("checkpointIsValid") && PlayerPrefs.GetString("checkpointIsValid") == "true" && PlayerPrefs.HasKey("CheckPointNum"))
        {
            currCheckpoint_number = PlayerPrefs.GetInt("CheckPointNum");
            currCheckPoint = transform.GetChild(currCheckpoint_number).GetComponent<CheckPoint>();
            currCheckpoint_Position.x = PlayerPrefs.GetFloat("CheckPointX");
            currCheckpoint_Position.y = PlayerPrefs.GetFloat("CheckPointY");


            playerRef = Instantiate(Player, currCheckPoint.transform.position, Quaternion.identity).GetComponent<PlayerController>();
            playerRef.life = PlayerPrefs.GetInt("Lives");
            EventBroker.CallUpdateLifeInUi(playerRef.life);
        }
        else
        {
            playerRef = Instantiate(Player, startingPoint.position, Quaternion.identity).GetComponent<PlayerController>();
        }

    }

    private void Start()
    {
        EventBroker.RetryLevel += RespawnPlayer;
        itemsDictionary = new Dictionary<GameObject, Transform>();
        for (int i = 0; i < items.Count; i++)
        {
            GameObject g = Instantiate(items[i].gameObject, items[i].transform.position, Quaternion.identity, newItemsForCheckpoint);
            g.SetActive(false);
            itemsDictionary.Add(g, g.transform);
            Debug.Log(g.name);
        }
    }

    public void CheckPointIsTriggered(int childCount, CheckPoint checkPoint)
    {
        if (childCount > currCheckpoint_number)
        {
            currCheckPoint = checkPoint;
            currCheckpoint_number = childCount;
            currCheckpoint_Position = new Vector2(checkPoint.transform.position.x, checkPoint.transform.position.y);
            GameManager.Instance.SaveProgress(currCheckpoint_Position, currCheckpoint_number, playerRef.life);

        }
        //else: its one of the previous checkpoints
    }

    void RespawnPlayer()
    {

        if (currCheckpoint_number != -1)     //player has reached some checkpoint
        {
            //playerRef = Instantiate(Player, transform.GetChild(currCheckpoint_number).position, Quaternion.identity).GetComponent<PlayerController>();
            playerRef.gameObject.SetActive(true);
            playerRef.life = PlayerPrefs.GetInt("Lives");
            EventBroker.CallUpdateLifeInUi(playerRef.life);
            playerRef.transform.position = transform.GetChild(currCheckpoint_number).position;
            playerRef.hasLost = false;
            RespawnItems();

        }
        else
        {
            //playerRef = Instantiate(Player, startingPoint.position, Quaternion.identity).GetComponent<PlayerController>();
            playerRef.gameObject.SetActive(true);
            playerRef.life = 3;
            EventBroker.CallUpdateLifeInUi(playerRef.life);
            playerRef.transform.position = startingPoint.position;
            playerRef.hasLost = false;
        }
    }

    void RespawnItems()
    {
        int i = 0;
        foreach (GameObject item in itemsDictionary.Keys)
        {
            if (!items[i].gameObject.activeSelf)
            {
                items[i] = Instantiate(item, itemsDictionary[item].position, Quaternion.identity).transform;
                items[i].gameObject.SetActive(true);
            }
            i++;
        }

        //for (int i = 0; i < itemsParent.childCount; i++)
        //{
        //    if (!itemsParent.GetChild(i).gameObject.activeSelf)
        //    {
        //        itemsParent.GetChild(i).gameObject.SetActive(true);
        //    }
        //}
    }

    private void OnDestroy()
    {
        EventBroker.RetryLevel -= RespawnPlayer;
    }
}
