using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    Transform cameraTransform;
    CharacterController cc;

    float toggleMoveAngle = 10;
    float toggleRotateAngle = 10;

    float moveSpeed = 5;
    float rotateSpeed = 80;

    bool movingForward;

    private void Awake()
    {
        cc = GetComponentInChildren<CharacterController>();
        cameraTransform = GetComponentInChildren<Camera>().transform;
    }
	
	void Update ()
    {
        HandleMovement();
        HandleRotation();
	}

    void HandleMovement()
    {
        movingForward =
            cameraTransform.rotation.eulerAngles.x >= toggleMoveAngle &&
            cameraTransform.rotation.eulerAngles.x < 90;

        if(movingForward)
        {
            Vector3 forward = cameraTransform.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * moveSpeed);
        }

    }

    void HandleRotation()
    {
        var zAngle = cameraTransform.eulerAngles.z;
        zAngle = (zAngle > 180) ? zAngle - 360 : zAngle;

        //Debug.Log(zAngle);

        if (Math.Abs(zAngle) > toggleRotateAngle)
        {
            var delta = Vector3.down * Math.Sign(zAngle) * Time.deltaTime * rotateSpeed;
            Debug.Log(delta);
            transform.eulerAngles += delta;
            //transform.Rotate(Vector3.up * zAngle * Time.deltaTime);
        }
    }
}
