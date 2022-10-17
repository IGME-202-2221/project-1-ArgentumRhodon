using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloaterMovement : MonoBehaviour
{
    private GameObject target;
    private Vector3 targetPosition;

    // The acceleration constant affects how fast the object accelerates
    public float speed;

    public Vector2 direction = Vector2.up;
    public Vector2 velocity = Vector2.zero;

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

        direction = targetPosition - transform.position;
        // This vector is used for movement calculations, so it must be normalized
        direction.Normalize();

        velocity = direction * speed;

        transform.position += (Vector3)velocity * Time.deltaTime;
    }
}
