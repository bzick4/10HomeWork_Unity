using System.Collections;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private float _motorForce=500, _targetVelocity, _limitsMax, _limitsMin;
    
    private HingeJoint _hingeJoint;

    private void Start()
    {
        _hingeJoint = GetComponent<HingeJoint>();
    }

    private void UseMotor()
    {
        _hingeJoint.useMotor = true;
        JointMotor blockMotor = _hingeJoint.motor;
        blockMotor.force = _motorForce;
        blockMotor.targetVelocity = _targetVelocity;
        _hingeJoint.motor = blockMotor;
    }

    private void UseLimits()
    {
        _hingeJoint.useLimits = true;
        JointLimits blockLimits = _hingeJoint.limits;
        blockLimits.max = _limitsMax;
        blockLimits.min = _limitsMin; 
        _hingeJoint.limits=blockLimits;
    }

    public void BlockOn()
    {
        UseMotor();
        UseLimits();
    }

    public void BlockOff()
    {
        _hingeJoint.useMotor = false;
    }
}
