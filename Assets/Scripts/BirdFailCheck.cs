using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdFailCheck : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -10f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
