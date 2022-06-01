using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalZone : MonoBehaviour
{
    public GameObject animalTrigger;

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<CarMoving>()){
            animalTrigger.SetActive(true);
        }    
    }

    private void OnTriggerExit(Collider other) {
        if (other.GetComponent<CarMoving>()){
            animalTrigger.SetActive(false);
        }    
    }
}
