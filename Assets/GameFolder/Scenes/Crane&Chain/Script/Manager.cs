using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
 [SerializeField] private Crane _crane;
 private void Start()
 {
  _crane.StopRotate();
  
 }

 public void ButtonStart()
 {
  _crane.StartRotate();
  
 }
 
}
