using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    List<CollidableObject> collidableObjects = new List<CollidableObject>();

    // Update is called once per frame
    void Update()
    {
        collidableObjects = FindObjectsOfType<CollidableObject>().ToList<CollidableObject>();

        foreach (CollidableObject collidableObject in collidableObjects)
        {
            collidableObject.ResetCollision();
        }

        for (int i = 0; i < collidableObjects.Count; i++)
        {
            for (int j = i + 1; j < collidableObjects.Count; j++)
            {
                if (DetectAABBCollision(collidableObjects[i], collidableObjects[j]))
                {
                    collidableObjects[i].RegisterCollision(collidableObjects[j]);
                    collidableObjects[j].RegisterCollision(collidableObjects[i]);
                }
            }
        }
    }

    private bool DetectAABBCollision(CollidableObject objectA, CollidableObject objectB)
    {
        Bounds objectABounds = objectA.GetComponent<SpriteRenderer>().bounds;
        Bounds objectBBounds = objectB.GetComponent<SpriteRenderer>().bounds;

        return objectBBounds.min.x < objectABounds.max.x
                && objectBBounds.max.x > objectABounds.min.x
                && objectBBounds.min.y < objectABounds.max.y
                && objectBBounds.max.y > objectABounds.min.y;
    }
}
