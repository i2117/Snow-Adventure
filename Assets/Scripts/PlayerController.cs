using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static Transform _transform;

    float maxX = 0.5F;
    float angleForMaxCoeff = 45;
    float angleForCrouch = 10;

    float[] verticalPositions = { 0.75F, 1.5F };

    Transform cameraTransform;

    Vector3 initialPosition;

    private void Awake()
    {
        _transform = transform;
        initialPosition = transform.localPosition;
        cameraTransform = GetComponentInChildren<Camera>().transform;
    }

    private void Update()
    {
        if (!Game.instance.isPlaying)
            return;

        SetHorizontal(HorizontalCoeff());
        SetVertical(IsUp());
    }

    float HorizontalCoeff()
    {
        var zAngle = cameraTransform.eulerAngles.z;
        zAngle = (zAngle > 180) ? zAngle - 360 : zAngle;

        var c = -zAngle / angleForMaxCoeff;
        if (Mathf.Abs(c) > 1)
            c = Mathf.Sign(c);

        return c;
    }

    // -1...1
    void SetHorizontal (float coeff)
    {
        var yAngle = cameraTransform.eulerAngles.y;
        var c = yAngle > 90 && yAngle < 270 ? -1 : 1;

        transform.localPosition = new Vector3(
            c * Mathf.Lerp(0, maxX, Mathf.Abs(coeff)) * Mathf.Sign(coeff),
            transform.localPosition.y,
            transform.localPosition.z);
    }

    bool IsUp()
    {
        return !(cameraTransform.eulerAngles.x >= angleForCrouch &&
               cameraTransform.eulerAngles.x < 90);
    }

    void SetVertical (bool isUp)
    {
        transform.localPosition = new Vector3(
            transform.localPosition.x,
            isUp ? verticalPositions[1] : verticalPositions[0],
            transform.localPosition.z);
    }

    public void ReturnToinitialPosition()
    {
        transform.localPosition = initialPosition;
    }
}
