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

    public Vector2 direction = Vector2.up;
    private Vector2 movementInput;

    private Vector2 screenBounds;
    private float halfHeight;

    private Vector3 mousePosition;

    void Start()
    {
        /*Fetch the bounds of the main camera's view as a Vector.
        screenBounds.x and screenBounds.y represent the global coordinates
        of the camera's top right corner.*/
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        // Account for the object's apparent dimensions inherited from the sprite.
        halfHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    void Update()
    {
        // Make the ship face the mouse
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePosition - transform.position;

        // Acceleration
        acceleration = accelerationConstant * movementInput;

        // Maximum velocity
        if (Mathf.Abs(velocity.magnitude) >= maximumVelocity)
        {
            acceleration = Vector2.zero;
        }

        velocity += acceleration * Time.deltaTime;

        // Deceleration
        if(acceleration.magnitude == 0)
        {
            velocity *= decelerationConstant;
            // Set velocity to zero once the velocity is negligible.
            if(Mathf.Abs(velocity.magnitude) <= 0.001f)
            {
                velocity = Vector2.zero;
            }
        }

        transform.position += (Vector3)velocity * Time.deltaTime;

        // Keep the player within the camera's view (mostly).
        ClampPosition();

        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }

    public void OnMove(InputAction.CallbackContext moveContext)
    {
        movementInput = moveContext.ReadValue<Vector2>();
    }

    /// <summary>
    /// Keeps the player within the bounds of the screen by looping
    /// you around the camera view.
    /// </summary>
    private Vector3 loopPosition;
    private void ClampPosition()
    {
        loopPosition = transform.position;

        // Possible directions: up, down, left, right
        // Loop to right side from left
        if (loopPosition.x - halfHeight < -screenBounds.x
            || loopPosition.x + halfHeight > screenBounds.x)
        {
            velocity.x = 0;
        }
        // Loop from bottom to top
        if (loopPosition.y - halfHeight < -screenBounds.y
            || loopPosition.y + halfHeight > screenBounds.y)
        {
            velocity.y = 0;
        }

        // Apply loop reposition
        transform.position = loopPosition;
    }
}
