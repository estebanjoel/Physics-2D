using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceScript : MonoBehaviour
{
    [SerializeField] Color usedColor;

    bool isTouched = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isTouched)
        {
            if (collision.tag == "Player")
            {
                isTouched = true;
                GameObject.Find("GameManager").GetComponent<GameManagerScript>().AddPoint(this.gameObject);
                GetComponent<SpriteRenderer>().color = usedColor;
            }
        }

        else
        {
            if (collision.tag == "Player")
            {
                GameObject.Find("GameManager").GetComponent<GameManagerScript>().GameOver();
            }
        }
    }
}
