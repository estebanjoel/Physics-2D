using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        

        if (col.tag == "BBall")
        {
            if (col.name != "Player")
            {
                GameObject.Find("BiliardManager").GetComponent<BiliardManagerScript>().AddPoint(col.gameObject);
            }

            else
            {
                GameObject.Find("BiliardManager").GetComponent<BiliardManagerScript>().GameOver();
            }
        }
    }
}
