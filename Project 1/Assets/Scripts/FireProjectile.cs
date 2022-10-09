using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    public GameObject projectile;
    public bool hasReleased = true;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && hasReleased)
        {
            CreateProjectile();
            hasReleased = false;
        }
        if(Input.GetMouseButtonUp(0))
        {
            hasReleased = true;
        }
    }

    public void CreateProjectile()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }
}
