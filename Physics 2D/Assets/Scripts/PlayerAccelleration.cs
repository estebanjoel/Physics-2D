using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAccelleration : MonoBehaviour
{
    [SerializeField] float maxSpeed = 10, accelleration = 3;

    [SerializeField] Text velocityText;
    [SerializeField] Image handle;

    float speed;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity += new Vector2(accelleration * Input.GetAxis("Velocity") * Time.deltaTime, rb.velocity.y);
        if (rb.velocity.x > maxSpeed)
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);

        if (rb.position.x > Camera.main.orthographicSize * Camera.main.aspect)
        {
            rb.position = new Vector2(-Camera.main.orthographicSize * Camera.main.aspect, rb.position.y);
        }

        speed = rb.velocity.x;

        velocityText.text = "Velocity: " + (Mathf.Floor(speed * 10)) / 10;
        handle.rectTransform.anchoredPosition = new Vector2(17 + (speed / maxSpeed) * 600, handle.rectTransform.anchoredPosition.y);
    }
}
