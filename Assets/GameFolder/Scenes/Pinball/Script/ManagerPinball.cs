using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPinball : MonoBehaviour
{
    [SerializeField] private SpringStart _springStart;
    [SerializeField] private Block _blockLeft, _blockRight;

    private void Start()
    {
        _springStart.StartLaunch();
    }

    private void Update()
    {
        KeyDown();
        KeyUp();
    }

    private void ButtonStart()
    {
        _springStart.StartLaunch();
    }

    private void KeyDown()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _blockRight.BlockOn();
            Debug.Log("Right Arrow");
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _blockLeft.BlockOn();
            Debug.Log("Left Arrow");
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log($"нажал down");
            _springStart.TransormSpring();
        }
    }

    private void KeyUp()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            _blockRight.BlockOff();
            _blockRight.GetComponent<Rigidbody>.isKinematic = false;
            Debug.Log("righ off");
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _blockLeft.BlockOff();
            _blockLeft.GetComponent<Rigidbody>.isKinematic = false;
            Debug.Log("Left off");
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Debug.Log($"отпустил down");
            _springStart.SpringTo();
        }
    }
}

