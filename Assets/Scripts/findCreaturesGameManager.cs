using UnityEngine;

public class findCreaturesGameManager : MonoBehaviour
{
    #region Serialized
    [SerializeField]
    GameObject[] creatureModelsArray;
    [SerializeField]
    UnityEngine.UI.Image[] imagesOnScreen;
    GameObject[] checkedCreaturesArray;
    #endregion

    #region Private
    GameObject TargetsCreatureModel;
    int index;
    LevelManager levelManager = LevelManager.s_instance;
    #endregion

    void Start()
    {
        index = 0;
    }

    void Update()
    {
       //checkIfGameFinished();
    }

    void checkIfGameFinished() {
        for (int i = 0; i < creatureModelsArray.Length; i++) {
            if (creatureModelsArray[i] == null) {
                return;
            }
            if (creatureModelsArray[i].activeSelf && checkedCreaturesArray[i] != creatureModelsArray[i]) {
                imagesOnScreen[i].gameObject.SetActive(false);
                checkedCreaturesArray[i] = creatureModelsArray[i];
                Debug.Log("Thisssss");
                index++;
            }
        }

        if (index >= creatureModelsArray.Length) {
            levelManager.changeLevelState(LevelState.LevelFinished);
        }


        Debug.Log("Index: " + index);

    }
}
