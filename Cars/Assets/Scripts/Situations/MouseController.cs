using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public GameObject selectedGameObject;
    public GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            RaycastHit hit;
            Ray ray;
            ray=Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit,100)){
                selectedGameObject = hit.collider.GetComponentInParent<RoadStates>().gameObject;
                selectedGameObject.GetComponent<RoadStates>().selectedRoad.SetActive(true);
            }
            
            UI.SetActive(true);
            foreach (var button in UI.GetComponentsInChildren<AddSituation>()){
                button.selectedGameObject = selectedGameObject;
            }
        }
    }
}
