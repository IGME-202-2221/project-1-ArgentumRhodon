using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidableObject : MonoBehaviour
{
    public bool isCurrentlyColliding = false;
    public List<CollidableObject> collidingObjects = new List<CollidableObject>();

    public void RegisterCollision(CollidableObject collidingObject)
    {
        isCurrentlyColliding = true;
        collidingObjects.Add(collidingObject);
    }

    public void ResetCollision()
    {
        isCurrentlyColliding = false;
        collidingObjects.Clear();
    }
}
