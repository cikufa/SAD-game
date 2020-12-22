using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public GameObject Player;
    public Transform startingPoint;

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
    }

    public void CheckPointIsTriggered(int childCount, CheckPoint checkPoint)
    {
        if(childCount > currCheckpoint_number)
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

    private void OnDestroy()
    {
        EventBroker.RetryLevel -= RespawnPlayer;
    }
}
