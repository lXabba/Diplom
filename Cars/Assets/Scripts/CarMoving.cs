using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMoving : MonoBehaviour
{
    public WheelsPair[] wheelsPairs;

    public int steerAngle; //Угол поворота в градусах
    public float torqueValue;
    public float motorTorque; //Крутящий момент двигателя на оси колеса выражается в ньютон-метрах
    [Range(0, 1)]
    public float steerControl;
    public Transform centreOfMass;
    public float stiffnessSideway = 1;
    public float stiffnessForward = 1;
    private float horinzontalInput;
    private float verticalInput;
    private bool onGround;
    private float lastYRotaion;

    private int gearNum = 1;
    public float brakeTorque = 50000;
    void Start()
    {
        //lastYRotaion = transform.rotation.eulerAngles.y;
        GetComponent<Rigidbody>().centerOfMass = centreOfMass.localPosition;
        motorTorque = torqueValue;
        stiffnessSideway = 1;
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            motorTorque = torqueValue * 1;
            gearNum = 1;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            motorTorque = torqueValue * 2;
            gearNum = 2;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            motorTorque = torqueValue * 3;
            gearNum = 3;
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            motorTorque = torqueValue * 4;
            gearNum = 4;
        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            motorTorque = torqueValue * 5;
            gearNum = 5;
        }
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
                pair.driverWheelcolider.brakeTorque = brakeTorque;
                pair.passengerWheelcolider.brakeTorque = brakeTorque;
            }
            else
            {
                pair.driverWheelcolider.brakeTorque = 0;
                pair.passengerWheelcolider.brakeTorque = 0;
            }
        }
    }

    public void UpdateValues()
    {
        motorTorque = torqueValue * gearNum;
        foreach (var pair in wheelsPairs)
        {
          
            pair.passengerWheelcolider.brakeTorque = brakeTorque;

            WheelFrictionCurve wfc = pair.driverWheelcolider.sidewaysFriction;
            wfc.stiffness = stiffnessSideway;
            pair.driverWheelcolider.sidewaysFriction = wfc;
            pair.passengerWheelcolider.sidewaysFriction = wfc;

            wfc = pair.driverWheelcolider.forwardFriction;
            wfc.stiffness = stiffnessForward;
            pair.driverWheelcolider.forwardFriction = wfc;
            pair.passengerWheelcolider.forwardFriction = wfc;
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

