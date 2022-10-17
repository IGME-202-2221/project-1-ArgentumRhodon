using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetDroneMovement : MonoBehaviour
{
    private GameObject target;
    private Vector3 targetPosition;

    // The acceleration constant affects how fast the object accelerates
    public float accelerationConstant;
    public float maximumSpeed;

    public Vector2 direction = Vector2.up;
    public Vector2 velocity = Vector2.zero;
    public Vector2 acceleration;

    void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        // The movement I have coded below should make all drones' flight paths
        // be pretty similar, loosly grouping them together into a fleet of sorts.
        // It also causes the drones to circle the player. This last behavior is 
        // unintended, but it fits.
        targetPosition = target.transform.position;

        // Make the ship face the player
        direction = targetPosition - transform.position;
        // This vector is used for movement calculations, so it must be normalized
        direction.Normalize();

        // Set acceleration in the direction being faced
        acceleration = accelerationConstant * direction;

        // Maximum velocity clamp
        if(velocity.magnitude >= maximumSpeed)
        {
            // Velocity is clamped to a magnitude of maximum speed;
            velocity *= maximumSpeed / velocity.magnitude;
        }

        velocity += acceleration * Time.deltaTime;

        transform.position += (Vector3)velocity * Time.deltaTime;

        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }
}