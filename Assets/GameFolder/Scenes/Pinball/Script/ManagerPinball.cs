using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPinball : MonoBehaviour
{
    [SerializeField] private SpringStart _springStart;
    private void Start()
    {
        _springStart.StopLaunch();
    }

    private void ButtonStart()
    {
        _springStart.StartLaunch();
    }
    
}
