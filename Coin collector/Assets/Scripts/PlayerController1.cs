using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour // Player movement controller component
{
    public GameObject FinishLine; // an object bound to the Finish line game object in Unity Inspector
    Vector2 Velocity; // Current movement vector (x used for horizontal speed)
    float Speed; // Movement speed scalar

    void Start() // Runs once when the object is enabled
    {
        Speed = 2; // Set movement speed
        Velocity = new Vector2(0, 0); // Initialize velocity to zero (not moving)
    }

    // Update is called once per frame // Unity per-frame update callback
    void Update() // Runs every frame
    {
        Debug.Log("The distance to Finish: " + Vector2.Distance(transform.position, FinishLine.transform.position));

        if(Keyboard.current.rightArrowKey.isPressed == true)  // If Right Arrow is held
            Velocity.x = Speed;        // Move to the right
        else if(Keyboard.current.leftArrowKey.isPressed == true)  // Else if Left Arrow is held
            Velocity.x = -Speed;  // Move to the left
        else // If neither left nor right is held
            Velocity.x = 0; // Stop horizontal movement

        transform.Translate(Velocity * Time.deltaTime); //Add velocity to the position vector (makes the Player move according to Velocity per second) 
    }
}