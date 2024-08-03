using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Car : MonoBehaviour
{
    // [SerializeField] private GameObject carBody; // Корпус машины
    // [SerializeField] private GameObject[] wheels; // Массив колес
    // [SerializeField] private float _motorForce,_springForce ,_damperForce;
    // private HingeJoint[] wheelJoints;
    // public bool isCar { get; private set; }
    //
    // private void Start()
    // {
    //     wheelJoints = GetComponent<HingeJoint[]>();
    // }
    //
    // public void Motor()
    // {
    //     Rigidbody carRigidbody = carBody.GetComponent<Rigidbody>();
    //     wheelJoints = new HingeJoint[wheels.Length];
    //     for (int i = 0; i < wheels.Length; i++)
    //     {
    //         HingeJoint hinge = wheels[i].AddComponent<HingeJoint>();
    //         hinge.connectedBody = carRigidbody; // Соединение с корпусом машины
    //         JointMotor motor = hinge.motor;
    //         motor.force = _motorForce;
    //         motor.targetVelocity = 1000; // Настройка скорости вращения
    //         hinge.motor = motor;
    //         hinge.useMotor = true;
    //         wheelJoints[i] = hinge;
    //         
    //         JointSpring spring = hinge.spring;
    //         spring.spring = _springForce;
    //         spring.damper = _damperForce;
    //         spring.targetPosition = 0; // Целевая позиция пружины
    //         hinge.spring = spring;
    //         hinge.useSpring = true;
    //     }
    // }
    //
    // public void Go()
    // {
    //     // Управление машиной
    //     float move = Input.GetAxis("Vertical"); // Получение ввода от пользователя
    //
    //     foreach (HingeJoint hinge in wheelJoints)
    //     {
    //         JointMotor motor = hinge.motor;
    //         motor.targetVelocity = move * _motorForce;
    //         hinge.motor = motor;
    //     }
    // }

    public GameObject carBody; // Куб, который будет корпусом машины
    public GameObject wheel1; // Первое колесо
    public GameObject wheel2; // Второе колесо
    public float motorForce = 1000f; // Сила мотора
    public float springForce = 5000f; // Сила пружины
    public float damperForce = 500f; // Сила демпфирования
    public bool isCar { get; private set; }

    private HingeJoint hinge1;
    private HingeJoint hinge2;

    void Start()
    {
        Rigidbody carRigidbody = carBody.GetComponent<Rigidbody>();

        // Настройка первого колеса
        hinge1 = wheel1.AddComponent<HingeJoint>();
        hinge1.connectedBody = carRigidbody; // Соединение с корпусом машины
        JointMotor motor1 = hinge1.motor;
        motor1.force = motorForce;
        motor1.targetVelocity = 1000; // Настройка скорости вращения
        hinge1.motor = motor1;
        hinge1.useMotor = true;

        // Настройка второго колеса
        hinge2 = wheel2.AddComponent<HingeJoint>();
        hinge2.connectedBody = carRigidbody; // Соединение с корпусом машины
        JointMotor motor2 = hinge2.motor;
        motor2.force = motorForce;
        motor2.targetVelocity = 1000; // Настройка скорости вращения
        hinge2.motor = motor2;
        hinge2.useMotor = true;

        // Настройка подвески для первого колеса
        SpringJoint spring1 = wheel1.AddComponent<SpringJoint>();
        spring1.connectedBody = carRigidbody;
        spring1.spring = springForce;
        spring1.damper = damperForce;
        spring1.anchor = Vector3.zero;
        spring1.autoConfigureConnectedAnchor = false;
        spring1.connectedAnchor = wheel1.transform.localPosition;

        // Настройка подвески для второго колеса
        SpringJoint spring2 = wheel2.AddComponent<SpringJoint>();
        spring2.connectedBody = carRigidbody;
        spring2.spring = springForce;
        spring2.damper = damperForce;
        spring2.anchor = Vector3.zero;
        spring2.autoConfigureConnectedAnchor = false;
        spring2.connectedAnchor = wheel2.transform.localPosition;
    }

    public void StartRotate()
    {
        isCar = true;
    }
    
    public void StopRotate()
    {
        isCar = false;
    }
    
    private void FixedUpdate()
    {
        if (isCar)
        {
            float move = Input.GetAxis("Horizontal"); // Получение ввода от пользователя

            JointMotor motor1 = hinge1.motor;
            motor1.targetVelocity = move * motorForce;
            hinge1.motor = motor1;

            JointMotor motor2 = hinge2.motor;
            motor2.targetVelocity = move * motorForce;
            hinge2.motor = motor2;
        }
    }
}
