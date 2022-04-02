using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTarget;
    public float moveSpeed;
    public float rotaionSpeed;

    private Quaternion startRotation;
    private Vector3 offset;
    void Awake()
    {
        offset = transform.position - playerTarget.position;
        startRotation = transform.rotation;
    }

   
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, playerTarget.position + playerTarget.rotation * offset, moveSpeed * Time.fixedDeltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, playerTarget.rotation * startRotation, rotaionSpeed * Time.fixedDeltaTime);
    }
}
