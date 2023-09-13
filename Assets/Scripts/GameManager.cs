using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager s_instance;
    public GameObject canvas;
   
    GameState m_gameState;
    int levelIndex;

    private void Awake() {
        if(s_instance != null && s_instance != this) {
            Destroy(this);
        } else {
            s_instance = this;
        }
        m_gameState = GameState.None;
    }

    void Update()
    {
        if(m_gameState == GameState.GameOver) {
            // gameOver();
        }
        if(m_gameState == GameState.GameFinished) {
            gameFinished();
        }
    }

    public void loadMainMenu() {
        //SceneManager.LoadScene("MainMenu");
    }

    void gameFinished() {

    }

    public void changeGameSate(GameState t_newState) {
        if (m_gameState == t_newState) {
            return;
        }
        m_gameState = t_newState;
        switch (m_gameState) {
            case GameState.None:
                break;
            case GameState.LoadMenu:
                loadMainMenu();
                break;
            case GameState.Pause:
                break;
            case GameState.Playing:
                break;
            case GameState.GameOver:
                break;
            case GameState.GameFinished:
                break;
            default:
                throw new UnityException("Invalid Game State");
        }
    }

    public void changeScene() {
        levelIndex = SceneManager.GetActiveScene().buildIndex;
        //Debug.Log("Manager ChangeScene");

        if (SceneManager.GetActiveScene().name == "Game") {
            m_gameState = GameState.GameFinished;
            //Debug.Log("Corutina!!!!");
            //StartCoroutine(openCredits());
            return;
        }

        
        if (levelIndex < SceneManager.sceneCountInBuildSettings - 1) {
            levelIndex++;
            SceneManager.LoadScene(levelIndex);
        }

        //else {
        //    m_gameState = GameState.GameFinished;
        //}
    }

    public GameState getGameState() { return m_gameState; }

    public void exitGame() {
        Application.Quit();
    }

}

public enum GameState {
    None,
    LoadMenu,
    Pause,
    Playing,
    GameOver,
    GameFinished
}