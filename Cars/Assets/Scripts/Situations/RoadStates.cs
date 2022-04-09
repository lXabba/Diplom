using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadStates : MonoBehaviour
{
    public GameObject snowZone;
    public GameObject selectedRoad;
    // Start is called before the first frame update
    void Start()
    {
        selectedRoad.SetActive(false);
        snowZone.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
