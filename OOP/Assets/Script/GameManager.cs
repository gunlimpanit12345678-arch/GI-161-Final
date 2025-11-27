using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public enum GameState
    {
        Gameplay,
        Paused,
        GameOver
    }

    public GameState currentState;
    public GameState previousState;

    [Header("UI")]
    public GameObject pauseScreen;
    public GameObject resultsScreen;

    public bool isGameOver = false;

    void Awake()
    {
        // Singleton setup
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

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

            case GameState.GameOver:
                // GameOver handled in GameOver() — no need to do anything here
                break;

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
            previousState = currentState;
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
            ChangeState(previousState);
            Time.timeScale = 1f;
            pauseScreen.SetActive(false);

            Debug.Log("Game Resumed");
        }
    }

    void CheckForPauseAndResume()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState == GameState.Paused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    void DisableScreen()
    {
        pauseScreen.SetActive(false);
        resultsScreen.SetActive(false);
    }

    public void GameOver()
    {
        if (isGameOver) return;   // ป้องกันการเรียกซ้ำ

        isGameOver = true;
        Time.timeScale = 0f;

        ChangeState(GameState.GameOver);
        DisplayResults();

        Debug.Log("Game Over");
    }

    void DisplayResults()
    {
        resultsScreen.SetActive(true);
    }
}

