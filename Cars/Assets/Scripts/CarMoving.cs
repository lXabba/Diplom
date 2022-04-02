using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMoving : MonoBehaviour
{
    public WheelsPair[] wheelsPairs;

    public int steerAngle; //Угол поворота в градусах
    public float motorTorque; //Крутящий момент двигателя на оси колеса выражается в ньютон-метрах
    [Range(0, 1)]
    public float steerControl;
    public Transform centreOfMass;
    private float horinzontalInput;
    private float verticalInput;
    private bool onGround;
    private float lastYRotaion;
    void Start()
    {
        //lastYRotaion = transform.rotation.eulerAngles.y;
        GetComponent<Rigidbody>().centerOfMass = centreOfMass.localPosition;
    }


    void Update()
    {

    }

    void FixedUpdate()
    {
        GetInput();
        CheckOnGround();
        Accelerate();
        Brake();
        SteerControl();
    }

    private void GetInput()
    {
        horinzontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }
    private void Accelerate()
    { //Ускорение автомобиля
        foreach (var pair in wheelsPairs)
        {
            if (pair.steering)
            {
                pair.driverWheelcolider.steerAngle = steerAngle * horinzontalInput;
                pair.passengerWheelcolider.steerAngle = steerAngle * horinzontalInput;
            }

            if (pair.motor)
            {
                pair.driverWheelcolider.motorTorque = motorTorque * verticalInput;
                pair.passengerWheelcolider.motorTorque = motorTorque * verticalInput;
            }

            VisualizationWheels(pair);
        }

    }

    private void VisualizationWheels(WheelsPair pair)
    {
        Vector3 position;
        Quaternion rotation;

        pair.driverWheelcolider.GetWorldPose(out position, out rotation);
        pair.driverWheel.transform.position = position;
        pair.driverWheel.transform.rotation = rotation;

        pair.passengerWheelcolider.GetWorldPose(out position, out rotation);
        pair.passengerWheel.transform.position = position;
        pair.passengerWheel.transform.rotation = rotation;
    }
    private void SteerControl()
    {
        if (!onGround) return;

        if (Mathf.Abs(transform.rotation.eulerAngles.y - lastYRotaion) < 10f)
        {
            float turnAdjust = (transform.rotation.eulerAngles.y - lastYRotaion) * steerControl;
            Quaternion rotateControl = Quaternion.AngleAxis(turnAdjust, Vector3.up);
            GetComponent<Rigidbody>().velocity = rotateControl * GetComponent<Rigidbody>().velocity;
        }
        lastYRotaion = transform.rotation.eulerAngles.y;
    }
    private void CheckOnGround()
    {
        onGround = true;
        foreach (var pair in wheelsPairs)
        {
            if (!pair.driverWheelcolider.isGrounded || !pair.passengerWheelcolider.isGrounded)
            {
                onGround = false;
            }

        }
    }

    private void Brake()
    {
        foreach (var pair in wheelsPairs)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                pair.driverWheelcolider.brakeTorque = 50000;
                pair.passengerWheelcolider.brakeTorque = 50000;
            }
            else
            {
                pair.driverWheelcolider.brakeTorque = 0;
                pair.passengerWheelcolider.brakeTorque = 0;
            }
        }
    }
}
[System.Serializable]
public class WheelsPair
{
    public WheelCollider driverWheelcolider, passengerWheelcolider;
    public GameObject driverWheel, passengerWheel;
    public bool motor;
    public bool steering;
}

