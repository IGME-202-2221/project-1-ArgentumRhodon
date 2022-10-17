using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireProjectile : FireProjectile
{
    // Update is called once per frame
    protected override void Update()
    {
        if(Input.GetMouseButton(0) && attackTimer.canAttack)
        {
            CreateProjectile();
        }
    }
}
