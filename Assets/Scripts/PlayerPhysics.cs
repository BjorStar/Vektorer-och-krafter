using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    [Header("Physics")]
    public float gravity = -9.81f;
    public float frictionCoefficient = 0.3f;

    private Vector2 velocity;
    private Vector2 previousPosition;

    private bool airborne = false;
    private bool sliding = false;

    [Header("Platform")]
    public Transform platform;
    public float platformWidth = 6f;

    void Update()
    {
        previousPosition = transform.position;

        if (airborne)
        {
            ApplyGravity();
            Move();
            CheckLanding();
        }
        else if (sliding)
        {
            ApplyFriction();
            Move();
            CheckSlideOff();
        }
    }

    // Called by Slingshot.cs
    public void Launch(Vector2 initialVelocity)
    {
        velocity = initialVelocity;
        airborne = true;
        sliding = false;
    }

    void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;
    }

    void Move()
    {
        transform.position += (Vector3)(velocity * Time.deltaTime);
    }

    void CheckLanding()
    {
        float platformY = platform.position.y;
        float x = transform.position.x;

        bool crossedPlatform =
            previousPosition.y > platformY &&
            transform.position.y <= platformY &&
            x >= platform.position.x - platformWidth / 2 &&
            x <= platform.position.x + platformWidth / 2;

        if (crossedPlatform)
        {
            transform.position = new Vector2(transform.position.x, platformY);
            velocity = new Vector2(velocity.x, 0);

            airborne = false;
            sliding = true;
        }
    }

    void ApplyFriction()
    {
        float frictionAccel = frictionCoefficient * Mathf.Abs(gravity);

        if (velocity.x > 0)
            velocity.x -= frictionAccel * Time.deltaTime;
        else if (velocity.x < 0)
            velocity.x += frictionAccel * Time.deltaTime;

        if (Mathf.Abs(velocity.x) < 0.01f)
        {
            velocity.x = 0;
            sliding = false;
            Win();
        }
    }

    void CheckSlideOff()
    {
        float x = transform.position.x;

        if (x < platform.position.x - platformWidth / 2 ||
            x > platform.position.x + platformWidth / 2)
        {
            Lose();
        }
    }

    void Win()
    {
        Debug.Log("MISSION COMPLETE!");
    }

    void Lose()
    {
        Debug.Log("FAILED — Restarting");
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }
}
