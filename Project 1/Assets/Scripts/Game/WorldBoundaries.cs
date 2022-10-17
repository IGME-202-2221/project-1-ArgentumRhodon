using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBoundaries : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 clampPosition = transform.position;
        clampPosition.x = Mathf.Clamp(clampPosition.x, -screenBounds.x + objectWidth, screenBounds.x - objectWidth);
        clampPosition.y = Mathf.Clamp(clampPosition.y, -screenBounds.y + objectHeight, screenBounds.y - objectHeight);
        transform.position = clampPosition;
    }
}
