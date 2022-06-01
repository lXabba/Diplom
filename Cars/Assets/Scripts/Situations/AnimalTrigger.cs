using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalTrigger : MonoBehaviour
{
    public GameObject WayContainer;
    public GameObject animalPrefab;
    public GameObject animalBody;
    public float animalSpeed;
    public List<Transform> lWayPoints;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var wayPoint in WayContainer.GetComponentsInChildren<Transform>())
        {
            if (wayPoint.gameObject.tag == "WayPoint")
            {
                lWayPoints.Add(wayPoint);
            }
        }

        animalPrefab.transform.position = new Vector3(lWayPoints[0].position.x, lWayPoints[0].position.y, lWayPoints[0].position.z);

       
    }

    
    void Update()
    {
        //animalPrefab.transform.rotation = Quaternion.identity;
        
     
      
        if (Vector3.Distance(animalPrefab.transform.position, lWayPoints[i].position)<1) {
            i++;
            if (i==lWayPoints.Count) i=0;
            //animalPrefab.transform.LookAt(lWayPoints[i].position);
            animalPrefab.transform.rotation = Quaternion.LookRotation(animalPrefab.transform.position - lWayPoints[i].position);

        }
       
     animalPrefab.transform.position = Vector3.MoveTowards(animalPrefab.transform.position, new Vector3( lWayPoints[i].position.x, 0.5f ,lWayPoints[i].position.z), animalSpeed * Time.deltaTime);
        //
      
       
    }

    private void OnEnable() {
        i=0;
        animalPrefab.transform.position = new Vector3(lWayPoints[0].position.x, lWayPoints[0].position.y, lWayPoints[0].position.z);
    }

    

    
    
}
