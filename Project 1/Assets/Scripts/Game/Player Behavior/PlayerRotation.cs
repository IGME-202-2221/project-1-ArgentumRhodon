using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public Vector2 direction = Vector2.up;
    private Vector3 mousePosition;

    // Update is called once per frame
    void Update()
    {
        // Make the ship face the mouse
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePosition - transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }
}
