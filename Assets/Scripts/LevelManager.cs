using UnityEngine;
//using UnityEngine.Playables;


public class LevelManager : MonoBehaviour {
    public static LevelManager s_instance;

    LevelState m_levelState;

    private void Awake() {
        if (FindObjectOfType<LevelManager>() != null &&
            FindObjectOfType<LevelManager>().gameObject != gameObject) {
            Destroy(gameObject);
        } else {
            s_instance = this;
        }
    }

    private void Start() {
        GameManager.s_instance.changeGameSate(GameState.Playing);
        //PlayerManager.instance.ChangePlayerState(PlayerState.Idle);
    }

    private void Update() {
        if (m_levelState == LevelState.LevelFinished) {
            GameManager.s_instance.changeScene();
            Debug.Log("LLegamos aca");
        }
        if (m_levelState == LevelState.GameOver) {
            GameManager.s_instance.changeGameSate(GameState.GameOver);
        }
    }

    public void changeLevelState(LevelState state) {
        m_levelState = state;
    }

}


public enum LevelState {
    None,
    Pause,
    Continue,
    LevelFinished,
    GameOver
}
