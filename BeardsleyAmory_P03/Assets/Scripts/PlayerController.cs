using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FPSInput))]
[RequireComponent(typeof(FPSMotor))]
[RequireComponent(typeof(ParticleSystem))]

public class PlayerController : MonoBehaviour
{
    FPSInput _input = null;
    FPSMotor _motor = null;

    [SerializeField] float _movementSpeed = 0.1f;
    [SerializeField] float _sprintMult = 3f;
    [SerializeField] float _turnSpeed = 6f;
    [SerializeField] float _jumpStrength = 10f;
    [SerializeField] ParticleSystem _gunBurst = null;
    [SerializeField] AudioSource _gunSound = null;

    private void Awake()
    {
        _input = GetComponent<FPSInput>();
        _motor = GetComponent<FPSMotor>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        _input.MoveInput += OnMove;
        _input.RotateInput += OnRotate;
        _input.JumpInput += OnJump;
        _input.SprintOnInput += OnSprintOn;
        _input.SprintOffInput += OnSprintOff;
        _input.ShootInput += OnShoot;
    }

    private void OnDisable()
    {
        _input.MoveInput -= OnMove;
        _input.RotateInput -= OnRotate;
        _input.JumpInput -= OnJump;
        _input.SprintOnInput -= OnSprintOn;
        _input.SprintOffInput -= OnSprintOff;
        _input.ShootInput -= OnShoot;
    }

    void OnSprintOn()
    {
        _movementSpeed *= _sprintMult;
    }

    void OnSprintOff()
    {
        _movementSpeed /= _sprintMult;
    }

    void OnMove(Vector3 movement)
    {
        //Debug.Log("Move: " + movement);
        _motor.Move(movement * _movementSpeed);
    }

    void OnRotate(Vector3 rotation)
    {
        //Debug.Log("Rotate: " + rotation);
        _motor.Turn(rotation.y * _turnSpeed);
        _motor.Look(rotation.x * _turnSpeed);
    }

    void OnJump()
    {
        //Debug.Log("Jump!");
        _motor.Jump(_jumpStrength);
    }

    void OnShoot()
    {
        Debug.Log("Shoot");
        _gunBurst.Play();
        _gunSound.Play();
    }
}
