using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float speed = 10;
    public Vector3 direction = Vector3.up;
    public Vector2 velocity = Vector2.zero;

    private Vector2 screenBounds;

    private float halfHeight;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        direction = transform.rotation * direction;
        halfHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed * Time.deltaTime;
        transform.position += (Vector3) velocity;

        if (IsOutOfBounds())
        {
            Destroy(this.gameObject);
        }
    }

    private bool IsOutOfBounds()
    {
        Vector3 currentPosition = transform.position;
        return currentPosition.x + halfHeight < -screenBounds.x
                || currentPosition.x - halfHeight > screenBounds.x
                || currentPosition.y + halfHeight < -screenBounds.y
                || currentPosition.y - halfHeight > screenBounds.y;
    }
}
