using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketPoint : MonoBehaviour
{
    [SerializeField] Text points;
    int point = 0;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            point++;
            points.text = "Points: " + point;
        }
    }
}
