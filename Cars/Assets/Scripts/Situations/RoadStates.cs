using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadStates : MonoBehaviour
{
    public GameObject snowZone;
    public GameObject rainingZone;
    public GameObject iceZone;
    public GameObject sleepingPolicman;
    public GameObject ussualZone;
    public GameObject selectedRoad;



    // Start is called before the first frame update
    void Start()
    {
        OffAll();
        ussualZone.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OffAll(){
        selectedRoad.SetActive(false);
        snowZone.SetActive(false);
        rainingZone.SetActive(false);
        iceZone.SetActive(false);
        sleepingPolicman.SetActive(false);
        ussualZone.SetActive(false);
    }
}
