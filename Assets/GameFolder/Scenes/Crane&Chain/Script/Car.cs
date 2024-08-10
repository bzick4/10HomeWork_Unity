using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Car : MonoBehaviour
{
    
    [SerializeField] private float _wheelsMotor, _target;
    
    public bool isCar { get; private set; }

    private HingeJoint hingeWheel;

    void Start()
    {
        hingeWheel = GetComponent<HingeJoint>();
    }

    private void FixedUpdate()
    {
        StartWheels();
    }
    
    public void StartWheels()
    {
        if (isCar==true)
        {
            hingeWheel.useMotor = true;
            JointMotor wheelMotor = hingeWheel.motor;
            wheelMotor.force = _wheelsMotor;
            wheelMotor.targetVelocity = _target;
            hingeWheel.motor = wheelMotor;
        }
    }
    
    public void StartRotate()
    {
        isCar = true;
    }
    
    public void StopRotate()
    {
        isCar = false;
    }
    
   
}
