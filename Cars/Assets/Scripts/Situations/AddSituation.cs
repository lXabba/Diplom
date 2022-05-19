using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSituation : MonoBehaviour
{
    //public GameObject selectedGameObject;
    GameObject root;
    // Start is called before the first frame update
    void Start()
    {
        root = GetComponentInParent<SelectedRoads>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddSnow(){
        foreach (var selectedGameObject in root.GetComponentInParent<SelectedRoads>().lSelectedGameObject){
        selectedGameObject.GetComponent<RoadStates>().OffAll();
        selectedGameObject.GetComponent<RoadStates>().snowZone.SetActive(true);
        }
        root.GetComponentInParent<SelectedRoads>().lSelectedGameObject.Clear();
    }

    public void AddRaining(){
        foreach (var selectedGameObject in root.GetComponentInParent<SelectedRoads>().lSelectedGameObject){
        selectedGameObject.GetComponent<RoadStates>().OffAll();
        selectedGameObject.GetComponent<RoadStates>().rainingZone.SetActive(true);
        }
         root.GetComponentInParent<SelectedRoads>().lSelectedGameObject.Clear();
    }

    public void AddIce(){
        foreach (var selectedGameObject in root.GetComponentInParent<SelectedRoads>().lSelectedGameObject){
        selectedGameObject.GetComponent<RoadStates>().OffAll();
        selectedGameObject.GetComponent<RoadStates>().iceZone.SetActive(true);
        }
        root.GetComponentInParent<SelectedRoads>().lSelectedGameObject.Clear();
    }
    public void AddSleppingPolicman(){
        foreach (var selectedGameObject in root.GetComponentInParent<SelectedRoads>().lSelectedGameObject){
        selectedGameObject.GetComponent<RoadStates>().OffAll();
        selectedGameObject.GetComponent<RoadStates>().sleepingPolicman.SetActive(true);
        selectedGameObject.GetComponent<RoadStates>().ussualZone.SetActive(true);
        }
        root.GetComponentInParent<SelectedRoads>().lSelectedGameObject.Clear();
    }

    public void Clear(){
        foreach (var selectedGameObject in root.GetComponentInParent<SelectedRoads>().lSelectedGameObject){
        selectedGameObject.GetComponent<RoadStates>().OffAll();
        selectedGameObject.GetComponent<RoadStates>().ussualZone.SetActive(true);
        }
        root.GetComponentInParent<SelectedRoads>().lSelectedGameObject.Clear();
    }

    public void AddPits(){
        foreach (var selectedGameObject in root.GetComponentInParent<SelectedRoads>().lSelectedGameObject){
        selectedGameObject.GetComponent<RoadStates>().OffAll();
        selectedGameObject.GetComponent<RoadStates>().AddPits();
        }
        root.GetComponentInParent<SelectedRoads>().lSelectedGameObject.Clear();
    }

   
}
