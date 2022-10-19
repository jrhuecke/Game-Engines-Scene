using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
    
public class CameraSwapper : MonoBehaviour
{
    public GameObject firstPerson;
    public GameObject thirdPerson;
    public GameObject sceneView;
    public GameObject scriptedView;

    private int current;
    private VisualElement frame;
    private Button button;

    private void Start()
    {
        firstPerson.SetActive(false);
        thirdPerson.SetActive(false);
        sceneView.SetActive(true);
        scriptedView.SetActive(false);
        current = 3;
    }

    private void OnEnable()
    {
        //Get the button which is nested in the UI Document
        var uiDocument = GetComponent<UIDocument>();
        var rootVisualElement = uiDocument.rootVisualElement;
        frame = rootVisualElement.Q<VisualElement>("Frame");
        button = frame.Q<Button>("CameraSwapper");
        button.RegisterCallback<ClickEvent>(ev => ChangeCamera());
    }

    private void ChangeCamera()
    {
        current++;
        if (current > 4)
        {
            current = 1;
        }
        switch (current)
        {
            case 1:
                firstPerson.SetActive(true);
                thirdPerson.SetActive(false);
                sceneView.SetActive(false);
                scriptedView.SetActive(false);
                break;
            case 2:
                firstPerson.SetActive(false);
                thirdPerson.SetActive(true);
                sceneView.SetActive(false);
                scriptedView.SetActive(false);
                break;
            case 3:
                firstPerson.SetActive(false);
                thirdPerson.SetActive(false);
                sceneView.SetActive(true);
                scriptedView.SetActive(false);
                break;
            case 4:
                firstPerson.SetActive(false);
                thirdPerson.SetActive(false);
                sceneView.SetActive(false);
                scriptedView.SetActive(true);
                break;
        }
    }
}
