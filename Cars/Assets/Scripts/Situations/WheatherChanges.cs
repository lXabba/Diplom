using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatherChanges : MonoBehaviour
{
    private float motorTorque; //Крутящий момент двигателя на оси колеса выражается в ньютон-метрах
    [Range(0, 1)]
    private float steerControl;
    private float brakeTorque;
    public float changeMotorTorque; //Крутящий момент двигателя на оси колеса выражается в ньютон-метрах
    [Range(0, 1)]
    public float changeSteerControl;
    public float chageBrakeTorque;
    void Start()
    {
         
    }

    private void OnTriggerEnter(Collider collision)
    {
        print("here");
        if (collision.gameObject.GetComponent<CarMoving>())
        {
           motorTorque = collision.gameObject.GetComponent<CarMoving>().motorTorque;
           collision.gameObject.GetComponent<CarMoving>().motorTorque = changeMotorTorque;

           steerControl = collision.gameObject.GetComponent<CarMoving>().steerControl;
           collision.gameObject.GetComponent<CarMoving>().steerControl = changeSteerControl;

            brakeTorque = collision.gameObject.GetComponent<CarMoving>().brakeTorque;
            collision.gameObject.GetComponent<CarMoving>().brakeTorque = chageBrakeTorque;
        }
    }

     private void OnTriggerExit(Collider collision)
    {
        
        if (collision.gameObject.GetComponent<CarMoving>())
        {
           collision.gameObject.GetComponent<CarMoving>().motorTorque = motorTorque;
           collision.gameObject.GetComponent<CarMoving>().steerControl = steerControl;
           collision.gameObject.GetComponent<CarMoving>().brakeTorque = brakeTorque;
        }
    }
    
}
