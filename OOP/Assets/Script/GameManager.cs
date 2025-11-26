using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Gameplay,
        Paused,
        GameOver
    }

    public GameState currentState;

    public GameState previoussState;

    [Header("UI")]
    public GameObject pauseScreen;

    void Awake()
    {
      DisableScreen();  
    }

    void Update()
    {
        
      switch (currentState)
        {
            case GameState.Gameplay:
                CheckForPauseAndResume();
                break;
            case GameState.Paused:
                CheckForPauseAndResume();
                break;
            case GameState.GameOver: break;

                default:
                Debug.LogWarning("STATE DOES NOT EXIST");
                    break;
        }
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
    }

    public void PauseGame()
    {
        if (currentState != GameState.Paused)
        {
            previoussState = currentState;
            ChangeState(GameState.Paused);
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
            Debug.Log("Game Paused");
        }
    }
    public void ResumeGame()
    {
        if (currentState == GameState.Paused) 
        {
            ChangeState(previoussState);
            Time.timeScale = 1f;
            pauseScreen.SetActive(false);
            Debug.Log("Game is Paused");
        }
    }

    void CheckForPauseAndResume()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState == GameState.Paused)
            {
                ResumeGame();
            }
            else { PauseGame(); }
        }
    }

    void DisableScreen()
    {
        pauseScreen.SetActive(false);
    }
}
