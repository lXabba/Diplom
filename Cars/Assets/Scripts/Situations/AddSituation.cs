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
        selectedGameObject.GetComponent<RoadStates>().snowZone.SetActive(true);
        selectedGameObject.GetComponent<RoadStates>().selectedRoad.SetActive(false);
    }
}
