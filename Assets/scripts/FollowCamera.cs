using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offsetPosition;
    public float smoothSpeed = 0.05F;
    public Vector3 lookAtOffset;

    private void FixedUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Missing target reference!", this);
            return;
        }

        Vector3 desiredPosition = target.TransformPoint(offsetPosition);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(target.position + lookAtOffset);
    }
}
