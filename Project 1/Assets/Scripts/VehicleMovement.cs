using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.Rendering;

public class VehicleMovement : MonoBehaviour
{
    public float speed = 1;
    public Vector2 direction = Vector3.right;
    public Vector2 velocity = Vector3.zero;
    private Vector2 movementInput;

    private Vector2 screenBounds;
    private float halfHeight;

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
        // Update initial direction and velocity values for the frame and apply them.
        direction = movementInput;
        velocity = direction * speed * Time.deltaTime;
        transform.position += (Vector3)velocity;

        // Keep the player within the camera's view (mostly).
        LoopPosition();

        // Maintain last direction's rotation
        if(direction != Vector2.zero)
        {
            // Rotates the game object based on movement direction
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }

    }

    public void OnMove(InputAction.CallbackContext moveContext)
    {
        movementInput = moveContext.ReadValue<Vector2>();
    }

    /// <summary>
    /// Keeps the player within the bounds of the screen by looping
    /// you around the camera view.
    /// </summary>
    private void LoopPosition()
    {
        Vector3 loopPosition = transform.position;

        // Possible directions: up, down, left, right
        // Loop to right side from left
        if(loopPosition.x + halfHeight < -screenBounds.x)
        {
            loopPosition.x = screenBounds.x + halfHeight;
        }
        // Loop to left side from right
        if (loopPosition.x - halfHeight > screenBounds.x)
        {
            loopPosition.x = -screenBounds.x - halfHeight;
        }
        // Loop from bottom to top
        if (loopPosition.y + halfHeight < -screenBounds.y)
        {
            loopPosition.y = screenBounds.y + halfHeight;
        }
        // Loop from top to bottom
        if (loopPosition.y - halfHeight > screenBounds.y)
        {
            loopPosition.y = -screenBounds.y - halfHeight;
        }

        // Apply loop reposition
        transform.position = loopPosition;
    }
}
