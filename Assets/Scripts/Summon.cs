using UnityEngine;

public class Summon : MonoBehaviour
{
    float timer = 0f;
    float height = 0.05f;
    Vector3 defaultPosition = new Vector3(0, 0.1f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float newY = Mathf.Sin(Time.time);
        transform.position = new Vector3 (transform.position.x, newY, transform.position.z) * height;
        transform.Rotate(Vector3.up * 50 * Time.deltaTime, Space.World);
        /*if(timer > 5f) {
            Debug.LogError("this");
            gameObject.SetActive(false);
            timer = 0f;
            transform.position = defaultPosition;
        }*/
    }
}
