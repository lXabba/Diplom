using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
public GameObject animalZone;

    private void OnCollisionEnter(Collision other) {
	if (other.gameObject.GetComponent<CarMoving>()){
        //GetComponentInChildren<Animator>().Stop();
        animalZone.GetComponent<AnimalZone>().alive = false;
	}
    }

} 
