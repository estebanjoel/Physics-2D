using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float maxSpeed = 10, accelleration = 5;
    [SerializeField] GameObject arrow;

    Vector2 direction;
    Rigidbody2D rb;
    float zAngle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if ((Input.GetAxis("Horizontal") >.5f || Input.GetAxis("Horizontal") < -.5f) || (Input.GetAxis("Vertical") > .5f || Input.GetAxis("Vertical") < -.5f))
        {
            direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
            zAngle = Mathf.Acos(direction.x) * Mathf.Rad2Deg;
            if (direction.y < 0)
                zAngle -= zAngle*2;

            arrow.SetActive(true);
            arrow.transform.rotation = Quaternion.Euler(0, 0, zAngle - 90);
        }

        else
        {
            arrow.SetActive(false);
        }

        if(rb.velocity.magnitude< maxSpeed)
            rb.velocity += accelleration * Input.GetAxis("Velocity") * Time.fixedDeltaTime * direction;

        else
            rb.velocity = direction * maxSpeed;

        if (rb.position.x < -Camera.main.orthographicSize * Camera.main.aspect)
        {
            rb.position = new Vector2(Camera.main.orthographicSize * Camera.main.aspect, rb.position.y);
        }

        else if (rb.position.x > Camera.main.orthographicSize * Camera.main.aspect)
        {
            rb.position = new Vector2(-Camera.main.orthographicSize * Camera.main.aspect, rb.position.y);
        }

        if (rb.position.y < -Camera.main.orthographicSize)
        {
            rb.position = new Vector2(rb.position.x, Camera.main.orthographicSize);
        }

        else if (rb.position.y > Camera.main.orthographicSize)
        {
            rb.position = new Vector2(rb.position.x, -Camera.main.orthographicSize);
        }

    }
}
