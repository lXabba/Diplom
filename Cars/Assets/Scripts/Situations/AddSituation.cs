using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSituation : MonoBehaviour
{
    public GameObject selectedGameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddSnow(){
        selectedGameObject.GetComponent<RoadStates>().OffAll();
        selectedGameObject.GetComponent<RoadStates>().snowZone.SetActive(true);
    }

    public void AddRaining(){
        selectedGameObject.GetComponent<RoadStates>().OffAll();
        selectedGameObject.GetComponent<RoadStates>().rainingZone.SetActive(true);
    }

    public void AddIce(){
        selectedGameObject.GetComponent<RoadStates>().OffAll();
        selectedGameObject.GetComponent<RoadStates>().iceZone.SetActive(true);
    }
    public void AddSleppingPolicman(){
        selectedGameObject.GetComponent<RoadStates>().OffAll();
        selectedGameObject.GetComponent<RoadStates>().sleepingPolicman.SetActive(true);
    }

    public void Clear(){
        selectedGameObject.GetComponent<RoadStates>().OffAll();
    }
}
