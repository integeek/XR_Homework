using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightSwitch : MonoBehaviour
{
    public Light pointLight;
    public InputActionReference action;


    void Start()
    {
        pointLight = GetComponent<Light>();
    }

    void Update()
    {
        action.action.Enable();
        action.action.performed += (ctx) =>
        {
            if (pointLight.color == Color.white)
            {
                pointLight.color = Color.blue;
            }
            else 
            {
                pointLight.color = Color.white;
            }
        };
    }
}
