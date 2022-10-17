using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float accelerationConstant;
    public float decelerationConstant;
    public float maximumVelocity;

    public Vector2 acceleration = Vector2.zero;
    public Vector2 velocity = Vector2.zero;
    private Vector2 movementInput;

    void Update()
    {
        // Acceleration
        acceleration = accelerationConstant * movementInput;

        // Maximum velocity
        if (Mathf.Abs(velocity.magnitude) >= maximumVelocity)
        {
            acceleration = Vector2.zero;
        }

        velocity += acceleration * Time.deltaTime;

        // Deceleration in y
        if (acceleration.y == 0f)
        {
            velocity.y *= decelerationConstant;
            if (Mathf.Abs(velocity.y) <= 0.001f)
            {
                velocity.y = 0f;
            }
        }
        // Deceleration in x
        if (acceleration.x == 0f)
        {
            velocity.x *= decelerationConstant;
            if (Mathf.Abs(velocity.x) <= 0.001f)
            {
                velocity.x = 0f;
            }
        }

        transform.position += (Vector3)velocity * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext moveContext)
    {
        movementInput = moveContext.ReadValue<Vector2>();
    }
}
