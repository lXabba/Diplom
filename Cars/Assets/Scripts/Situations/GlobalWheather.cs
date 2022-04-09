using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalWheather : MonoBehaviour
{
    public GameObject allRoads;
   
   
     public void SnowEveryRoad(){
        foreach (var road in allRoads.GetComponentsInChildren<RoadStates>()){
            road.GetComponent<RoadStates>().OffAll();
            road.GetComponent<RoadStates>().snowZone.SetActive(true);
        }

       
    }

     public void RainEveryRoad(){
        foreach (var road in allRoads.GetComponentsInChildren<RoadStates>()){
            road.GetComponent<RoadStates>().OffAll();
            road.GetComponent<RoadStates>().rainingZone.SetActive(true);
        }
         
    }

     public void IceEveryRoad(){
        foreach (var road in allRoads.GetComponentsInChildren<RoadStates>()){
            road.GetComponent<RoadStates>().OffAll();
            road.GetComponent<RoadStates>().iceZone.SetActive(true);
        }
        
    }

     public void ClearEveryRoad(){
        foreach (var road in allRoads.GetComponentsInChildren<RoadStates>()){
            road.GetComponent<RoadStates>().OffAll();
            road.GetComponent<RoadStates>().ussualZone.SetActive(true);
        }
         
    }
}
