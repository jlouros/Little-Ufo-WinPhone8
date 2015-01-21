using UnityEngine;

public class GameController : ScriptableObject
{
    private static GameController instance;
    private GameController() { }

    public static GameController TreeInstance
    {
        get
        {
            if (instance == null)
                instance = ScriptableObject.CreateInstance<GameController>();

            return instance;
        }
    }

    public enum GameState
    {
        Start,
        Playing,
        Lost
    }

    public int Score;
    public GameState CurrentState;
    public bool PlayerDestroyed;
    public string DeadCause;


    public void GameLoaded()
    {
        CurrentState = GameState.Start;
    }

    public void NavigateMainMenuScreen()
    {
        CurrentState = GameState.Start;
        Application.LoadLevel(0);
    }

    public void NavigateGameScreen()
    {
        CurrentState = GameState.Playing;
        PlayerDestroyed = false;
        Score = 0;

        Application.LoadLevel(1);
    }

    public void NavigateGameOverScreen()
    {
        CurrentState = GameState.Lost;

        Application.LoadLevel(2);
    }

    public void GenericInputListener()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HandleBackButton();
        }
    }

    public void HandleBackButton()
    {
        switch (CurrentState)
        {
            case GameState.Start:
                Application.Quit();
                break;
            case GameState.Playing:
                Pause();
                break;
            case GameState.Lost:
                NavigateMainMenuScreen();
                break;
        }
    }

    private void Pause()
    {
        Debug.Log("Pausing");

    }
}