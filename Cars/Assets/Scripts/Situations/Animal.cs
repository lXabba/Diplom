using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public Transform centereOfMass;

    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = centereOfMass.localPosition;
        StartCoroutine(Jump());
    }
    IEnumerator Jump(){
        for(;;) {
   
      GetComponent<Rigidbody>().velocity =   Vector2.up * 3f;
      yield return new WaitForSeconds(0.5f);
        }
    }
}
