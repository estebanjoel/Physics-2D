using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    [SerializeField] Transform player;

    void Update()
    {
        transform.position = offset + player.position;
    }
}
