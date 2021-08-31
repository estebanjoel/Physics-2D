using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCenter : MonoBehaviour
{
    [SerializeField] float addedEdge;

    void Update()
    {
        GameObject[] planets = GameObject.FindGameObjectsWithTag("Planet");

        Vector2 center = Vector2.zero;

        foreach (GameObject planet in planets)
        {
            center += new Vector2(planet.transform.position.x, planet.transform.position.y);
        }

        center /= planets.Length;

        float distance;
        float maxDistance = 0;

        foreach(GameObject planet in planets)
        {
            distance = Vector2.Distance(center, planet.transform.position);
            if (maxDistance < distance)
                maxDistance = distance;
        }

        Camera.main.transform.position = new Vector3(center.x, center.y, -10);
        Camera.main.orthographicSize = maxDistance * addedEdge;
    }
}
