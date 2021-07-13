using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private Player _player;
    private UI_Manager _uiManager;
    private LevelCamera _levelCamera;
    ObstacleCapsule _obstacleCapsule;
    
    private void Awake()
    {
        Instance = this;

        if (State != GameState.InGame)
        {
            State = GameState.Menu;
        }

        _player = FindObjectOfType<Player>();
        _uiManager = FindObjectOfType<UI_Manager>();
        _levelCamera = FindObjectOfType<LevelCamera>();
        _obstacleCapsule = FindObjectOfType<ObstacleCapsule>();
        //default events:

    }
    
    //add fade effect later on to scene laoding
    // public SceneFader fade;
    
    public enum GameState
    {
        Menu,InGame,LevelEnd
    }
    public GameState State;
    
    //THE FUNCTION CALLED WHEN WE CLICK A BUTTON
    public void OnButtonClick()
    {
        string buttonName=EventSystem.current.currentSelectedGameObject.name;

        switch (buttonName)
        {
            case "Level1":
                SceneManager.LoadScene("LEVEL1");
                SetInGame();
                break;
            case "Level2":
                SceneManager.LoadScene("LEVEL2");
                SetInGame();
                break;
            case "Level3":
                SceneManager.LoadScene("LEVEL3");
                SetInGame();
                break;
            case "GoToMainMenu":
                SceneManager.LoadScene("MAINMENU");
                SetMenu();
                break;
        }
    }
    
    public event Action  OnInGame, OnLevelEnd;

    public void SetMenu()
    {
        Instance.State = GameState.Menu;
    }
    public void SetInGame()
    {
        Instance.State = GameState.InGame;
    }
    public void SetLevelEnd()
    {
        Instance.State = GameState.LevelEnd;
        // State = GameState.LevelEnd;
    }
    private void Update()
    {
        switch (State)
        {
            case GameState.InGame:
                OnInGame += _player.MovePlayer;
                OnInGame += _player.JoystickPlayer;
                OnInGame += _levelCamera.LevelCamMove;
                // OnInGame += _obstacleCapsule.MoveCapsule;
                break;
            case GameState.LevelEnd:
                OnLevelEnd += _uiManager.ActivateUI;
                OnLevelEnd += _player.StopPlayer;
                // OnLevelEnd += _player.GetScore;
                break;
            case GameState.Menu:
                break;
        }
    }

    private void FixedUpdate()
    {
        switch (State)
        {
            case GameState.InGame:
                OnInGame?.Invoke();
                break;
            case GameState.LevelEnd:
                OnLevelEnd?.Invoke();
                break;
            case GameState.Menu:
                break;
        }
    }
}
