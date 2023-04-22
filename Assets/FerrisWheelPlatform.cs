using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FerrisWheelPlatform : MonoBehaviour
{
    public GameObject pivotPoint;
    public float rotationSpeed = 10.0f;
    public float rotationInt = 90.0f;
    public bool clockwiseRot = true;

    private float currentAngle = 0.0f;

    private void Update()
    {
        // Calculate the target angle based on the current interval and direction
        float targetAngle = Mathf.Round(currentAngle / rotationInt) * rotationInt;
        if (clockwiseRot)
        {
            targetAngle += rotationInt;
        }
        else
        {
            targetAngle -= rotationInt;
        }

        // Smoothly rotate the platform towards the target angle
        float angle = Mathf.LerpAngle(currentAngle, targetAngle, Time.deltaTime * rotationSpeed);
        transform.RotateAround(pivotPoint.transform.position, Vector3.forward, angle - currentAngle);
        currentAngle = angle;
    }
}

