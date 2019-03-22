using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Target")]
    public Transform target;

    [Header("Camera Settings")]
    public Vector3 offset;

    private float counter;


    [Header("Camera FX")]
    public CameraShaker.Properties shakerProperties;

    private void Start()
    {
        transform.position = offset;
    }

    private void LateUpdate()
    {
        transform.position = target.position + offset;
        transform.LookAt(target.position);
    }

    public void StandardCameraShake()
    {
        FindObjectOfType<CameraShaker>().StartShake(shakerProperties);
    }

    public void ShakeCamera(CameraShaker.Properties shakeProperties)
    {
        FindObjectOfType<CameraShaker>().StartShake(shakeProperties);
    }
}
