using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalTrigger : MonoBehaviour
{
    public GameObject animalZone;

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<CarMoving>()){
            animalZone.SetActive(true);
        }    
    }

    private void OnTriggerExit(Collider other) {
        if (other.GetComponent<CarMoving>()){
            animalZone.SetActive(false);
        }    
    }
} 
