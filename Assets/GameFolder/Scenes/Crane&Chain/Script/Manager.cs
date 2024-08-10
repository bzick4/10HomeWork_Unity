using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
 [SerializeField] private Crane _crane;
 [SerializeField] private Car _frontWheel, _backWheels;
 private void Start()
 {
  _crane.StopRotate();
  _frontWheel.StopRotate();
  _backWheels.StopRotate();
 }

 public void ButtonStart()
 {
  _crane.StartRotate();
  _frontWheel.StartRotate();
  _backWheels.StartRotate();
 }
 
}
