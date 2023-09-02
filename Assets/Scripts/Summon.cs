using UnityEngine;

public class Summon : MonoBehaviour
{
    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 2f) {
            Debug.LogError("this");
            gameObject.SetActive(false);
            timer = 0f;
        }
    }
}
