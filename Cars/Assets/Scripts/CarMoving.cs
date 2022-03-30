using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMoving : MonoBehaviour
{
    public WheelsPair[] wheelsPairs;

    public int steerAngle; //Угол поворота в градусах
    public float motorTorque; //Крутящий момент двигателя на оси колеса выражается в ньютон-метрах
    public Transform centreOfMass;
    private float horinzontalInput;
    private float verticalInput;

    void Start()
    {
        
        GetComponent<Rigidbody>().centerOfMass = centreOfMass.localPosition;
    }


    void Update()
    {

    }

    void FixedUpdate()
    {
        GetInput();
        Accelerate();
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

}
[System.Serializable]
public class WheelsPair
{
    public WheelCollider driverWheelcolider, passengerWheelcolider;
    public GameObject driverWheel, passengerWheel;
    public bool motor;
    public bool steering;
}

