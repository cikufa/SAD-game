using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{

    private string _currentLevelName = string.Empty;
    public string CurrentLevelName
    {
        get { return _currentLevelName; }
    }

    private List<AsyncOperation> _asyncOperations;

    [SerializeField]
    //Toggle audioToggle;
    private GameObject[] systemPrefabs;
    private List<GameObject> _instancedSystemPrefabs;

    public enum GameState { PREGAME, PLAYING, PAUSED }        //PreGame: before loading a level
    private GameState currGameState = GameState.PREGAME;
    public GameState CurrGameState
    {
        get { return currGameState; }
        private set { currGameState = value; }
    }

    public int mapNumber = 1;
    //public int levelNumber = 1;



    public AudioClip gamePlayMusic;
    public AudioClip MenuMusic;


    private void Start()
    {
        /*
        if (AudioListener.volume == 0)
        {
            audioToggle.isOn = false;
        }
        */

        DontDestroyOnLoad(this);

        _asyncOperations = new List<AsyncOperation>();
        _instancedSystemPrefabs = new List<GameObject>();

        InstantiateSystemprefabs();

        LoadLevel("Menu");
        UpdateState(GameState.PREGAME);
    }
    /*
    public OnLevelSelectionButtonClickedInMenu()
    {
        switch (levelname)
        {
            case level1:
                mapNumber = 1;
            case level2:
                mapNumber = 2;
            case level3:
                mapNumber = 3;
        }
            LoadLevel("Map" + mapNumber.ToString());
        }
    */



    public void OnContinueButtonClickedInMenu()
    {
        //LoadData
        if (PlayerPrefs.HasKey("Map"))
        {
            mapNumber = PlayerPrefs.GetInt("Map");
            LoadLevel("Map" + mapNumber.ToString());
        }
        else
        {
            LoadLevel("Map1");
        }

        UpdateState(GameState.PLAYING);
    }
    public void OnLevelSelectedButtonClickedInMenu(int levelNumber)
    {
        PlayerPrefs.SetString("checkpointIsValid", "false");
        LoadLevel("Map" + levelNumber.ToString());
        UpdateState(GameState.PLAYING);
    }

    public void OnPlayButtonClickedInMenu()
    {
    LoadLevel("Map1");
    UpdateState(GameState.PLAYING);
    }

    public void LoadLevel(string levelName)
    {
        if (_asyncOperations.Count != 0)
        {
            Debug.LogWarning("[GameManager] already loading a scene.");
            return;
        }
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to load scene " + levelName);
            return;
        }

        _asyncOperations.Add(ao);
        ao.completed += OnLoadComplete;
    }

    //public void LoadNextLevel()
    //{
    //    if (_asyncOperations.Count != 0)
    //    {
    //        Debug.LogWarning("[GameManager] already loading a scene.");
    //        return;
    //    }
    //    int NextLvlBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;       
    //    AsyncOperation ao = SceneManager.LoadSceneAsync(NextLvlBuildIndex);
    //    if (ao == null)
    //    {
    //        Debug.LogError("[GameManager] Unable to load scene " + NextLvlBuildIndex + "=BUILD INDEX");
    //        return;
    //    }

    //    _asyncOperations.Add(ao);
    //    ao.completed += OnLoadComplete;
    //}

    private void OnLoadComplete(AsyncOperation ao)
    {
        _currentLevelName = SceneManager.GetActiveScene().name;
        UpdateState(GameState.PLAYING);
        _asyncOperations.Remove(ao);
        Debug.Log("Load Complete.");
        if ((_currentLevelName == "Map1" || _currentLevelName == "Map2" || _currentLevelName == "Map3") /*&& !puaseManager.GameIsPaused*/)
        {
            string lvlNum = "";
            lvlNum += _currentLevelName[3];
            mapNumber = int.Parse(lvlNum);
            PlayerPrefs.SetInt("Map", mapNumber);

            GetComponent<AudioSource>().clip = gamePlayMusic;
            GetComponent<AudioSource>().Play();
        }
        else if(_currentLevelName == "Menu" /* && !puaseManager.GameIsPaused*/)
        {
            GetComponent<AudioSource>().clip = MenuMusic;
            GetComponent<AudioSource>().Play();
        }
        else if (_currentLevelName == "levelcompletion1" || _currentLevelName == "levelcompletion2" || _currentLevelName == "levelcompletion3")
        {
            GetComponent<AudioSource>().Stop();
        }
    }

    private void InstantiateSystemprefabs()
    {
        for (int i = 0; i < systemPrefabs.Length; i++)
        {
            _instancedSystemPrefabs.Add(Instantiate(systemPrefabs[i]));
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        _instancedSystemPrefabs.Clear();
    }

    void UpdateState(GameState newState)
    {
        currGameState = newState;
        switch (currGameState)
        {
            case GameState.PREGAME:
                break;
            case GameState.PLAYING:
                if(Time.timeScale == 0)
                {
                    Time.timeScale = 1;
                }
                break;
            case GameState.PAUSED:
                Time.timeScale = 0;
                break;
            default:
                break;
        }
    }

    public void TogglePause()
    {
        if (currGameState == GameState.PLAYING)
        {
            UpdateState(GameState.PAUSED);
        }
        else if (currGameState == GameState.PAUSED)
        {
            UpdateState(GameState.PLAYING);
        }
    }
    public void forHome()
    {
        LoadLevel("Menu");
    }

    public void ReplayLevel()
    {
        LoadLevel(_currentLevelName);
    }

    public void SaveProgress(Vector2 checkPointPos,int checkPointNum, int lives)
    { 
        PlayerPrefs.SetString("checkpointIsValid", "true");
        PlayerPrefs.SetInt("CheckPointNum", checkPointNum);     //child number of checkpoint
        PlayerPrefs.SetFloat("CheckPointX", checkPointPos.x);
        PlayerPrefs.SetFloat("CheckPointY", checkPointPos.y);
        PlayerPrefs.SetInt("Lives", lives);
    }

}
