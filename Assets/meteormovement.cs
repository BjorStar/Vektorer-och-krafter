using UnityEngine;

public class MeteorMovement : MonoBehaviour
{
    public Transform pluto;
    public Transform saturn;
    public float speed = 3f;

    private Transform target;

    void Start()
    {
        target = saturn; // Start moving toward Saturn
    }

    void Update()
    {
        // Move toward current target
        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        // If reached target, switch
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            target = (target == saturn) ? pluto : saturn;
        }
    }
}
