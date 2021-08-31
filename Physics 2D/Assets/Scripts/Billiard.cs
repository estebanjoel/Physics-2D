using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Billiard : MonoBehaviour
{
    [SerializeField] float speed = 10, minSpeed = .3f;
    [SerializeField] GameObject arrow;
    [SerializeField] float arrowSizeMultiplier;

    Vector2 direction;
    Rigidbody2D rb;
    new AudioSource audio;
    float zAngle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {

        if ((Input.GetAxis("Horizontal") > .5f || Input.GetAxis("Horizontal") < -.5f) || (Input.GetAxis("Vertical") > .5f || Input.GetAxis("Vertical") < -.5f))
        {
            direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
            zAngle = Mathf.Acos(direction.x) * Mathf.Rad2Deg;
            if (direction.y < 0)
                zAngle -= zAngle * 2;

            arrow.SetActive(true);
            arrow.transform.rotation = Quaternion.Euler(0, 0, zAngle - 90);
            arrow.GetComponent<SpriteRenderer>().size = new Vector2(GetComponent<SpriteRenderer>().size.x, arrowSizeMultiplier * Input.GetAxis("Velocity"));
        }

        else
        {
            arrow.SetActive(false);
        }

        if(Input.GetAxisRaw("Fire2") == 1 && rb.velocity.x < minSpeed && rb.velocity.x > -minSpeed && rb.velocity.y < minSpeed && rb.velocity.y > -minSpeed)
        {
            rb.velocity = direction * speed * Input.GetAxis("Velocity");
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Hole")
        {
            audio.Play();
        }
    }
}
