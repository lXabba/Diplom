using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public GameObject[] cameras;
    int length;
    int activeCamera;

    void Start()
    {
        length = cameras.Length;
        foreach (var camera in cameras)
        {
            camera.SetActive(false);
        }
        if (length != 0)
        {
            cameras[0].SetActive(true);
        }
        activeCamera = 0;
    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.C))
        {
            activeCamera++;
            if (activeCamera == length)
            {
                activeCamera = 0;
            }
            foreach (var camera in cameras)
            {
                camera.SetActive(false);
            }
            cameras[activeCamera].SetActive(true);

        }
    }
}
