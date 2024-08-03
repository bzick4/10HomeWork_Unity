using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private float springForce, motorForce, limitsMax;
    [SerializeField]private GameObject blockElementLeft, blockElementRight;
    private HingeJoint hingeJoint;

    private void Update()
    {
        KeyPut();
    }

    void BlockElement()
    {
        hingeJoint = blockElementLeft.GetComponent<HingeJoint>();
        hingeJoint = blockElementRight.GetComponent<HingeJoint>();
        hingeJoint.useSpring = true;
        JointSpring blockSpring = hingeJoint.spring;
        blockSpring.spring = springForce;
    }

    public void KeyPut()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("KKKKKKKKK");
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("LLLLLLLLLL");
        }
    }
    
    
    
}
