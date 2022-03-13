using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().centerOfMass = new Vector3 (0, -transform.localScale.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
