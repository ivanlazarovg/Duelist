﻿
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    
    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;

    private Rigidbody Rig;

    private Vector3 jumpForce = Vector3.zero;

    private Vector3 crouchamount = Vector3.zero;

    private Vector3 rotation = Vector3.zero;

    private float cameraRotationX = 0f;

    private float currentCameraRotationX = 0f;


    void Start()
    {
        Rig = GetComponent<Rigidbody>();
        Vector3 boxSize = GetComponent<Collider>().bounds.size;
    }

    //movement vectors
    public void Move(Vector3 rVelocity)
    {
        velocity = rVelocity;
    }

    public void Rotate(Vector3 _rotation)
    {
         rotation = _rotation;
    }

    public void CameraRotate(float _cameraRotation)
    {
        cameraRotationX = _cameraRotation;
    }

    public void ApplyJump(Vector3 _jumpForce)
    {
        jumpForce = _jumpForce;
    }

    public void ApplyCrouch(Vector3 _crouchamount)
    {
        crouchamount = _crouchamount;
    }


    void FixedUpdate()
    {
        PerfMove();
        PerfRot();

    }

    // Movement Function

    void PerfMove()
    {
        if (velocity != Vector3.zero)
        {
            Rig.MovePosition(Rig.position + velocity * Time.fixedDeltaTime);
        }

        if (jumpForce != Vector3.zero)
        {
            Rig.AddForce(jumpForce * Time.fixedDeltaTime, ForceMode.Impulse);
        }

        if(crouchamount != Vector3.zero)
        {
            Rig.MovePosition(transform.position + crouchamount * Time.fixedDeltaTime);
        }
    }

    //rotation function

    void PerfRot()
    {
        Rig.MoveRotation(Rig.rotation * Quaternion.Euler(rotation) );
        if (cam != null)
        {
            currentCameraRotationX -= cameraRotationX;
            currentCameraRotationX = Mathf.Clamp(currentCameraRotationX,- 60, 20);

            cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
        }
    }
}
