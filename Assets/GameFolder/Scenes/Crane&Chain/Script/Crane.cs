using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour
{
    [SerializeField] public float speed = 0; // скорость
    public bool isStartRotate { get; private set; }
    private Rigidbody rbCrane;
   
    

    public void StartRotate()
    {
        isStartRotate = true;
    }

    public void StopRotate()
    {
        isStartRotate = false;
    }
    private void FixedUpdate()
    {
        if (isStartRotate)
        {
            transform.Rotate(0,speed * Time.deltaTime,0);
            
        }
    }

}
