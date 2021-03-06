﻿using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class playerController : MonoBehaviour {

    private Rigidbody Rig;
    
    [SerializeField]
    private float speed = 2.5f;
    [SerializeField]
    private float horSensitivity = 2f;
    [SerializeField]
    private float vertSensitivity = 2f;
    [SerializeField]
    private float jumpforce = 0.1f;
    [SerializeField]
    private float crouchamount = 0.2f;

    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        //calc movem velocity
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 moveHor = transform.right * xMove;
        Vector3 moveVer = transform.forward * zMove;

        Vector3 rVelocity = (moveHor + moveVer).normalized * speed;

        motor.Move(rVelocity);

        //calc roattion

        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, yRot, 0f) * horSensitivity;

        motor.Rotate(_rotation);

        float xRot = Input.GetAxisRaw("Mouse Y");

        //calc Camerarot

        float _cameraRotationX = xRot * vertSensitivity;

        motor.CameraRotate(_cameraRotationX);

        //JUMP

        Vector3 _jumpForce = Vector3.zero;

        Vector3 _crouchamount = Vector3.zero;

        float DisstanceToTheGround = GetComponent<Collider>().bounds.extents.y;

        bool IsGrounded = Physics.Raycast(transform.position, Vector3.down, DisstanceToTheGround + 0.1f);

        if (IsGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _jumpForce = Vector3.up * jumpforce;
        }

        if (IsGrounded && Input.GetKey(KeyCode.C))
        {
            _crouchamount = Vector3.down * crouchamount;
        }
        motor.ApplyJump(_jumpForce);
        motor.ApplyCrouch(_crouchamount);

    }
}
