using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // Read arrow key input
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Build direction vector
        Vector2 dir = new Vector2(x, y);

        // Normalize to ensure constant speed
        if (dir.magnitude > 0)
            dir = dir.normalized;

        // Apply movement
        transform.position += (Vector3)(dir * moveSpeed * Time.deltaTime);
    }
}
