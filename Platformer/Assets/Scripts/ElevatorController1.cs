using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    Vector2 Velocity;
    float Speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Speed = 1; //initializing the speed to 2 (elevator going upwards)
        Velocity = new Vector2(0, Speed);  //sets the y-component of the Velocity vector to Speed
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 1) //if the y-position of the elevator is  higher than 1, change the direction to down (negative y)
            Velocity.y = -Speed;
        if(transform.position.y < -4) //if the y-position of the elevator is  less than -4, change the direction to up (positive y)
            Velocity.y = Speed;

        transform.Translate(Velocity * Time.deltaTime);  //Add velocity to the position vector (makes the elevator move according to Velocity) 
    }
}
