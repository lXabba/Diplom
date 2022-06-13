using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRoadDepend : MonoBehaviour
{
public WheelsPair[] wheelsPairs;
    public float torqueValue;
    public float motorTorque; 
    public float stiffnessSideway = 1;
    public float stiffnessForward = 1;
    private int gearNum = 1;
    public float brakeTorque = 50000;
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
