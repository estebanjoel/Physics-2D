using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallThrower : MonoBehaviour
{
    [SerializeField] int trajectorySteps;
    [SerializeField] float strength;
    [SerializeField] float timeBtwShoots;
    [SerializeField] float directionMult;
    [SerializeField] float timeBtwCircles;
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject ball;
    [SerializeField] GameObject circle;

    Vector3 direction;
    bool canShoot;
    float zAngle;
    float time;

    GameObject[] trajectory;
    

    void Start()
    {
        trajectory = new GameObject[trajectorySteps];
        
    }

    void Update()
    {
        time += Time.deltaTime;

        if (Input.GetAxis("Horizontal")<-.3f || Input.GetAxis("Horizontal") > .3f || Input.GetAxis("Vertical")<-.3f || Input.GetAxis("Vertical")>.3f)
        {
            direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * strength;
            canShoot = true;
        }

        else
        {
            direction = Vector2.down;
            canShoot = false;
        }

        zAngle = Mathf.Acos(direction.normalized.x) * Mathf.Rad2Deg;
        if (direction.y < 0)
            zAngle -= zAngle * 2;
        arrow.transform.rotation = Quaternion.Euler(0, 0, zAngle - 90);

        for(int i=0; i < trajectorySteps; i++)
        {
            Destroy(trajectory[i]);
        }

        for(int i=0; i < trajectorySteps; i++)
        {
            trajectory[i] = Instantiate(circle, transform.position + new Vector3(direction.x * timeBtwCircles * i, direction.y * timeBtwCircles * i + Physics2D.gravity.y * timeBtwCircles * timeBtwCircles * i * i * .5f, -1), Quaternion.identity);

        }

        if(Input.GetAxisRaw("Fire2") == 1 && time>timeBtwShoots && canShoot)
        {
            time = 0;
            GameObject go = Instantiate(ball, transform.position + direction.normalized * directionMult + Vector3.back, Quaternion.identity);
            go.GetComponent<Rigidbody2D>().velocity = direction;
            Destroy(go, 3);
        }
    }
}
