using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public string objectThatDoesDamage;
    private SpriteRenderer spriteRenderer;
    public bool tookDamage;

    private CollidableObject collision;
    // Start is called before the first frame update

    void Start()
    {
        collision = GetComponent<CollidableObject>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collision.collidingObjects.Count == 0)
        {
            return;
        }

        foreach (CollidableObject collidingObject in collision.collidingObjects)
        {
            if(collidingObject == null)
            {
                continue;
            }

            if (collidingObject.CompareTag(objectThatDoesDamage))
            {
                GetComponent<Health>().TakeDamage(1);
                tookDamage = true;
            }
        }

        if (tookDamage)
        {
            spriteRenderer.color = Color.red;
            tookDamage = false;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
    }
}
