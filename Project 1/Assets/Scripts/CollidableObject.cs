using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidableObject : MonoBehaviour
{
    public bool isCurrentlyColliding = false;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCurrentlyColliding)
        {
            spriteRenderer.color = Color.blue;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
    }

    public void RegisterCollision()
    {
        isCurrentlyColliding = true;
    }

    public void ResetCollision()
    {
        isCurrentlyColliding = false;
    }
}
