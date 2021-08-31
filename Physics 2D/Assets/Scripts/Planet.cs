using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] Vector2 startingVelocity;

    Rigidbody2D rb;

    const float G = 6.67f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = startingVelocity;
    }

    void FixedUpdate()
    {
        GameObject[] planets = GameObject.FindGameObjectsWithTag("Planet");

        Vector2 force = Vector2.zero;

        foreach(GameObject planet in planets)
        {
            Vector2 direction = planet.transform.position - transform.position;

            Vector2 newForce = direction.normalized * G * (rb.mass * planet.GetComponent<Rigidbody2D>().mass) / (direction.x* direction.x * direction.y * direction.y);

            if(!float.IsNaN(newForce.x) && !float.IsNaN(newForce.y))
                force += newForce;
        }

        rb.AddForce(force);
    }
}
