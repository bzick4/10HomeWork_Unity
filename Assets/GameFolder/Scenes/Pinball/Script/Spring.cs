using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class SpringStart : MonoBehaviour
{
    [SerializeField] private Transform targetPoint;
    [SerializeField] private float speed, springForce;
    [SerializeField] private GameObject launch, pointSpring;
    public bool isStart { get; private set; }
    private SpringJoint springJoint;
    
    private void Update()
    {
        Key();
        TransormSpring();
    }

    public void StartLaunch()
    {
        isStart = true;
    }

    public void StopLaunch()
    {
        isStart = false;
    }
    
    public void SpringTo()
    {
            springJoint = launch.GetComponent<SpringJoint>();
            
            springJoint.spring = springForce;
            
            Rigidbody pointSpringRb = pointSpring.GetComponent<Rigidbody>();
            springJoint.connectedBody = pointSpringRb;
            
            springJoint.autoConfigureConnectedAnchor = false;
            springJoint.connectedAnchor = Vector3.zero;
            springJoint.anchor = Vector3.zero;
    }

    private void TransormSpring()
    {
        Vector3 direction = (targetPoint.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        Debug.Log("Move ON");    
    }
    public void Key()
    {
        // if (Input.GetKeyDown(KeyCode.DownArrow))
        // {
        //     Debug.Log("нажал");
        //     TransormSpring();
        // }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        { 
            Debug.Log("отпустил");
            SpringTo();
        }
    }

   
}
