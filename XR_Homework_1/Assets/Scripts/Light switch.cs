using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    private Light light;

    void Start()
    {
        light = GetComponent<Light>();

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            light.color = Color.blue;
        }
    }
}
