using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TakeBulletDamage : MonoBehaviour
{
    public GameObject bulletThatDoesDamage;
    private SpriteRenderer spriteRenderer;
    public bool tookBulletDamage;

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
        if(collision.collidingObjects.Count == 0)
        {
            return;
        }

        foreach (CollidableObject collidingObject in collision.collidingObjects)
        {
            if(collidingObject == null)
            {
                continue;
            }

            if (collidingObject.CompareTag(bulletThatDoesDamage.tag))
            {
                GetComponent<Health>().TakeDamage(1);
                tookBulletDamage = true;
            }
        }

        if (tookBulletDamage)
        {
            spriteRenderer.color = Color.red;
            tookBulletDamage = false;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
    }
}
