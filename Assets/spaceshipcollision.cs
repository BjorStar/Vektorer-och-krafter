using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceshipCollision : MonoBehaviour
{
    public Transform meteor;
    public float hitDistance = 1f;

    void Update()
    {
        if (Vector3.Distance(transform.position, meteor.position) < hitDistance)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
