using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAmeraControl : MonoBehaviour
{
    [Header("Camera Control")]

    [SerializeField] private Transform focalPoint;
    [SerializeField] private float rotationSpeed;

    [Header("Set Dynamically")]
    [SerializeField] private Quaternion initRotation;
    [SerializeField] private Vector3 initPosition;

    public void Awake()
    {
        initRotation = focalPoint.rotation;
        initPosition = focalPoint.position;
    }

    public void RotateCamera(float direction) {
        Vector3 rotation = direction * rotationSpeed * Vector3.up * Time.deltaTime;

        focalPoint.transform.Rotate(rotation);
    }

    public void RotateCamera(
        ) {
        Vector3 rotation = rotationSpeed * Vector3.up * Time.deltaTime;

        focalPoint.transform.Rotate(rotation);
    }

    public void ResetCameraRotation() {
        focalPoint.rotation = initRotation;
    }

    public void MoveFocalPointToPos(Vector3 newPos) {
        focalPoint.transform.position = newPos;
    }
}
