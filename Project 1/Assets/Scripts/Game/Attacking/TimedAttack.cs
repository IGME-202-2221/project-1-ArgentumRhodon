using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedAttack : MonoBehaviour
{
    public bool canAttack = false;

    public float fireRate;
    [SerializeField] // For debugging if necessary
    private float attackTimer;

    // Start is called before the first frame update
    void Start()
    {
        // This makes it so that enemies don't all attack at once
        attackTimer = Random.value;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTimer <= 0f)
        {
            attackTimer = 1 / fireRate;
            canAttack = false;
        }

        if (attackTimer > 0f)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0f)
            {
                canAttack = true;
                attackTimer = 0f;
            }
        }
    }
}
