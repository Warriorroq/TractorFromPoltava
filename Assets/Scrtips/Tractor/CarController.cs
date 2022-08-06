using System;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float _horizontalInput;
    private float _verticalInput;
    private float _currentSteerAngle;
    private float _currentbreakForce;
    private bool _isBreaking;
    
    [SerializeField] private float _motorForce;
    [SerializeField] private float _breakForce;
    [SerializeField] private float _maxSteerAngle;

    [SerializeField] private WheelData _frontLeftWheel;
    [SerializeField] private WheelData _frontRightWheel;
    [SerializeField] private WheelData _rearLeftWheel;
    [SerializeField] private WheelData _rearRightWheel;
    private Rigidbody _carRigidBody;
    [SerializeField] private Vector3 _centerOfMass;

    private void Awake()
    {
        _carRigidBody = GetComponent<Rigidbody>();
        _carRigidBody.centerOfMass = _centerOfMass;
    }

    private void Update()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }


    private void GetInput()
    {
        _horizontalInput = Input.GetAxis(HORIZONTAL);
        _verticalInput = Input.GetAxis(VERTICAL);
        _isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        var force = _motorForce;
        _frontLeftWheel.wheelCollider.motorTorque = _verticalInput* force;
        _frontRightWheel.wheelCollider.motorTorque = _verticalInput* force;
        _currentbreakForce = _isBreaking ? _breakForce : 0f;
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        _frontRightWheel.wheelCollider.brakeTorque = _currentbreakForce;
        _frontLeftWheel.wheelCollider.brakeTorque = _currentbreakForce;
        _rearLeftWheel.wheelCollider.brakeTorque = _currentbreakForce;
        _rearRightWheel.wheelCollider.brakeTorque = _currentbreakForce;
    }

    private void HandleSteering()
    {
        _currentSteerAngle = _maxSteerAngle * _horizontalInput;
        _frontLeftWheel.wheelCollider.steerAngle = _currentSteerAngle;
        _frontRightWheel.wheelCollider.steerAngle = _currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(_frontLeftWheel);
        UpdateSingleWheel(_frontRightWheel);
        UpdateSingleWheel(_rearRightWheel);
        UpdateSingleWheel(_rearLeftWheel);
    }

    private void UpdateSingleWheel(WheelData wheel)
    {
        Vector3 pos;
        Quaternion rot;
        wheel.wheelCollider.GetWorldPose(out pos, out rot);
        wheel.meshTransform.rotation = rot;
        wheel.meshTransform.position = pos;
    }
    [Serializable]
    public struct WheelData
    {
        public WheelCollider wheelCollider;
        public Transform meshTransform;
    }
}
