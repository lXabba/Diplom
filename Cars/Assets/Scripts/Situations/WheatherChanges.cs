using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatherChanges : MonoBehaviour
{
    private float motorTorque; //Крутящий момент двигателя на оси колеса выражается в ньютон-метрах
    [Range(0, 1)]
    private float steerControl;
    private float brakeTorque;
    private float stiffness;
    //public float changeMotorTorque; //Крутящий момент двигателя на оси колеса выражается в ньютон-метрах
    [Range(0, 1)]
    public float changeSteerControl;
    public float chageBrakeTorque;
    public float changeStiffnessSideway;
    public float changeStiffnessForward;

    void Start()
    {


    }

    private void OnTriggerEnter(Collider collision)
    {
        print("here");
        if (collision.gameObject.GetComponent<CarMoving>())
        {
            motorTorque = collision.gameObject.GetComponent<CarMoving>().torqueValue;
            // collision.gameObject.GetComponent<CarMoving>().torqueValue = changeMotorTorque;
            stiffness = collision.gameObject.GetComponent<CarMoving>().stiffnessSideway;
            collision.gameObject.GetComponent<CarMoving>().stiffnessSideway = changeStiffnessSideway;
            collision.gameObject.GetComponent<CarMoving>().stiffnessForward = changeStiffnessForward;

            steerControl = collision.gameObject.GetComponent<CarMoving>().steerControl;
            collision.gameObject.GetComponent<CarMoving>().steerControl = changeSteerControl;

            brakeTorque = collision.gameObject.GetComponent<CarMoving>().brakeTorque;
            collision.gameObject.GetComponent<CarMoving>().brakeTorque = chageBrakeTorque;


            collision.gameObject.GetComponent<CarMoving>().UpdateValues();
        }
    }

    private void OnTriggerExit(Collider collision)
    {

        if (collision.gameObject.GetComponent<CarMoving>())
        {
            collision.gameObject.GetComponent<CarMoving>().torqueValue = motorTorque;
            collision.gameObject.GetComponent<CarMoving>().steerControl = steerControl;
            collision.gameObject.GetComponent<CarMoving>().brakeTorque = brakeTorque;
            collision.gameObject.GetComponent<CarMoving>().stiffnessForward = stiffness;
            collision.gameObject.GetComponent<CarMoving>().stiffnessSideway = stiffness;

            print(stiffness);
            collision.gameObject.GetComponent<CarMoving>().UpdateValues();
        }
    }

   

   

}
