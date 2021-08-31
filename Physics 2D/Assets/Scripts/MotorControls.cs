using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorControls : MonoBehaviour
{
    [SerializeField] float motorStrengthMult;

    WheelJoint2D wheel;
    JointMotor2D motor;

    void Start()
    {
        wheel = GetComponent<WheelJoint2D>();
        motor = wheel.motor;
    }
    
    void Update()
    {
        motor.motorSpeed = Input.GetAxis("Velocity") * motorStrengthMult;
        wheel.motor = motor;
    }
}
