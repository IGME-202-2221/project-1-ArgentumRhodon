using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public bool healthAtOrBelowZero;

    private void Update()
    {
        healthAtOrBelowZero = health <= 0;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
