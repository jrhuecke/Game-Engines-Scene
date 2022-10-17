using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwapper : MonoBehaviour
{
    public GameObject firstPerson;
    public GameObject thirdPerson;
    public GameObject sceneView;
    public GameObject scriptedView;

    void Update()
    {
        //Swaps between cameras on button press 1-4
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            firstPerson.SetActive(true);
            thirdPerson.SetActive(false);
            sceneView.SetActive(false);
            scriptedView.SetActive(false);
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            firstPerson.SetActive(false);
            thirdPerson.SetActive(true);
            sceneView.SetActive(false);
            scriptedView.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            firstPerson.SetActive(false);
            thirdPerson.SetActive(false);
            sceneView.SetActive(true);
            scriptedView.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            firstPerson.SetActive(false);
            thirdPerson.SetActive(false);
            sceneView.SetActive(false);
            scriptedView.SetActive(true);
        }
    }
}
