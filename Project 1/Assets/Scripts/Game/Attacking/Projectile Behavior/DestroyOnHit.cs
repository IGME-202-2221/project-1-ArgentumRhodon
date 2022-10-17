using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHit : MonoBehaviour
{
    public List<string> objectsThatDestroy = new List<string>();
    private CollidableObject collision;
    // Start is called before the first frame update

    void Start()
    {
        collision = GetComponent<CollidableObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collision.collidingObjects.Count == 0)
        {
            return;
        }

        foreach(string objectThatDestroys in objectsThatDestroy)
        {
            foreach(CollidableObject collidingObject in collision.collidingObjects)
            {
                if (collidingObject.CompareTag(objectThatDestroys))
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
