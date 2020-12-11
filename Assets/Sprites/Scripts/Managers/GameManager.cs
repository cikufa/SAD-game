using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    private string _currentLevelName = string.Empty;
    public string CurrentLevelName
    {
        get { return _currentLevelName; }
    }

    private List<AsyncOperation> _asyncOperations;

    [SerializeField]
    private GameObject[] systemPrefabs;
    private List<GameObject> _instancedSystemPrefabs;

    public enum GameState { PREGAME,PLAYING,PAUSED}        //PreGame: before loading a level
    private GameState currGameState = GameState.PREGAME;
    public GameState CurrGameState
    {
        get { return currGameState; }
        private set { currGameState = value; }
    }

    private void Start()
    {
        DontDestroyOnLoad(this);

        _asyncOperations = new List<AsyncOperation>();
        _instancedSystemPrefabs = new List<GameObject>();

        InstantiateSystemprefabs();

        LoadLevel("Map1");
        UpdateState(GameState.PLAYING);
    }

    public void LoadLevel(string levelName)
    {      
        if(_asyncOperations.Count != 0)
        {
            Debug.LogWarning("[GameManager] already loading a scene.");
            return;
        }
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName);   
        if(ao == null)
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

    public void ReplayLevel()
    {
        LoadLevel(_currentLevelName);
    }

}
