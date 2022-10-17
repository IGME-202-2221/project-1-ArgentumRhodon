using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private Vector2 screenBounds;
    private float halfHeight;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        halfHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOutOfBounds())
        {
            Destroy(gameObject);
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
