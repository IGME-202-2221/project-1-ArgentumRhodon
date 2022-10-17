using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float speed;
    public Vector3 direction = Vector3.up;
    public Vector2 velocity = Vector2.zero;


    void Start()
    {
        direction = transform.rotation * direction;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed * Time.deltaTime;
        transform.position += (Vector3) velocity;
    }
}
