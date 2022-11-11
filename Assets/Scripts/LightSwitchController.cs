using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LightSwitchController : MonoBehaviour
{
    private VisualElement frame;
    private Button button;
    public UIDocument uiDoc;
    public Light lamp;
    public Light ceilingLight;
    private bool lightSwitch;

    private void OnEnable()
    {
        //Get the button which is nested in the UI Document
        var rootVisualElement = uiDoc.rootVisualElement;
        frame = rootVisualElement.Q<VisualElement>("Frame");
        button = frame.Q<Button>("LightSwitch");
        button.RegisterCallback<ClickEvent>(ev => ChangeLighting());
        lightSwitch = true;
    }

    private void ChangeLighting()
    {
        if (lightSwitch)
        {
            lightSwitch = false;
            lamp.intensity = 0f;
            ceilingLight.intensity = 0f;
        }
        else
        {
            lightSwitch = true;
            lamp.intensity = 1f;
            ceilingLight.intensity = 1.2f;
        }
    }
}
