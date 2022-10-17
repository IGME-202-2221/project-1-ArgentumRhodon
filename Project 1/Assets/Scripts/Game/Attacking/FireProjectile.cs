using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    public GameObject projectile;
    public TimedAttack attackTimer;
    public Transform projectileOrigin;

    protected virtual void Update()
    {
        if (attackTimer.canAttack)
        {
            CreateProjectile();
        }
    }

    public void CreateProjectile()
    {
        if(projectileOrigin == null)
        {
            Instantiate(projectile, transform.position, transform.rotation);
        }
        else
        {
            Instantiate(projectile, projectileOrigin.position, projectileOrigin.rotation);
        }
    }
}
