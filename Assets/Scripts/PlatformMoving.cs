using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour {

    [SerializeField]
    private float rotateSpeedCoeff = 50;

    public Transform[] wheels;

	void Update () {
        var moveSpeed = Game.instance.currentSpeed;
        var deltaTime = Time.deltaTime;
        transform.Translate(Vector3.forward * deltaTime * moveSpeed);
        foreach (var wheel in wheels)
        {
            wheel.Rotate(
                Vector3.down, 
                deltaTime * rotateSpeedCoeff * moveSpeed, 
                Space.Self);
        }
	}
}
