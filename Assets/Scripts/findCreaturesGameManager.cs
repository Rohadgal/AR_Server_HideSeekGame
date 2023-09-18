using System.Collections;
using UnityEngine;

public class findCreaturesGameManager : MonoBehaviour
{
    #region Serialized
    [SerializeField]
    GameObject[] creatureModelsArray;
    [SerializeField]
    GameObject[] imagesOnScreen;
    GameObject[] checkedCreaturesArray;
   // [SerializeField]
    //ParticleController[] particleController;
    [SerializeField]
    GameObject canvasWinImage;
    #endregion
    #region Private
   // LevelManager levelManager = LevelManager.s_instance;
    GameManager gameManager = GameManager.s_instance;
    int index;
    #endregion

    void Start()
    {
        GameManager.OnGameFinished += HandleGameFinished;

        index = 0;
        checkedCreaturesArray = new GameObject[creatureModelsArray.Length];
        for(int i = 0; i < checkedCreaturesArray.Length; i++) {
            checkedCreaturesArray[i] = null;
        }
        for(int i = 0; i < imagesOnScreen.Length; i++) {
            Debug.Log("Image Object name: " + imagesOnScreen[i].name);
            Debug.Log("Creatures Model name: " + creatureModelsArray[i].name);
        }
    }

    void Update()
    {
       checkIfGameFinished();
    }

    void checkIfGameFinished() {

        if(index >= creatureModelsArray.Length) {
            Debug.Log("Game Finished");
            canvasWinImage.SetActive(true);
            StartCoroutine(Restart());
           gameManager.changeGameSate(GameState.GameFinished);
            return;
        }

        for(int i = 0;i < creatureModelsArray.Length; i++) {
            GameObject obj = creatureModelsArray[i];

            if(obj.activeSelf && checkedCreaturesArray[i] == null) {
                checkedCreaturesArray[i] = obj;
                imagesOnScreen[i].SetActive(false);
                index++;
            }
        }

    }

    private void OnDestroy() {
        // Unsubscribe from the event when the script is destroyed.
        GameManager.OnGameFinished -= HandleGameFinished;
    }

    private void HandleGameFinished() {
        StartCoroutine(Restart());
    }

    IEnumerator Restart() {
        yield return new WaitForSeconds(3f);
        gameManager.changeGameSate(GameState.LoadMenu);
    }
}
