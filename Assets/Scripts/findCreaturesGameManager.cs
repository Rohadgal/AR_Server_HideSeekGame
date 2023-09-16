using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;

public class findCreaturesGameManager : MonoBehaviour
{
    #region Serialized
    [SerializeField]
    GameObject[] creatureModelsArray;
    [SerializeField]
    GameObject[] imagesOnScreen;
    GameObject[] checkedCreaturesArray;
    #endregion

    #region Private
    LevelManager levelManager = LevelManager.s_instance;
    int index;
    #endregion

    void Start()
    {
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
        //for (int i = 0; i < creatureModelsArray.Length; i++) {
        //    if (creatureModelsArray[i] == null) {
        //        return;
        //    }
        //    if (creatureModelsArray[i].activeSelf && checkedCreaturesArray[i] != creatureModelsArray[i]) {
        //        imagesOnScreen[i].gameObject.SetActive(false);
        //        checkedCreaturesArray[i] = creatureModelsArray[i];
        //        Debug.Log("Thisssss");
        //        index++;
        //    }
        //}

        //if (index >= creatureModelsArray.Length) {
        //    levelManager.changeLevelState(LevelState.LevelFinished);
        //}


        //Debug.Log("Index: " + index);

    }
}
