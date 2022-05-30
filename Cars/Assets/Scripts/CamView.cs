using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamView : MonoBehaviour
{
    public Transform target;
    public float speed = 5;
    private Vector3 position;

    void Start()
    {
        position = target.InverseTransformPoint(transform.position);
    }

  
    void FixedUpdate()
    {
        var currentPosition = target.TransformPoint(position);
        transform.position = Vector3.Lerp(transform.position, currentPosition, Time.deltaTime*speed);
        
        var currentRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, currentRotation, Time.deltaTime * speed);
        
    }
}
