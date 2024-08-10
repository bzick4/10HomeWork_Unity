using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class SpringStart : MonoBehaviour
{
    [SerializeField] private Transform targetPoint;//for TransormTo
    /// <summary>
    /// for SpringTo
    /// </summary>
    [SerializeField] private float speed, springForce, damp;
     private SpringJoint springJoint;
    public bool isStart { get; private set; }

    private void Start()
    {
        springJoint = GetComponent<SpringJoint>();
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
        springJoint.spring = springForce;
        springJoint.damper = damp;
    }

    public void TransormSpring()
    {
        springJoint.spring = 0f;
        Vector3 direction = (targetPoint.position - transform.position).normalized; 
        transform.position += direction * speed * Time.deltaTime;
        Debug.Log($"Move ON ");
    }
    
}
