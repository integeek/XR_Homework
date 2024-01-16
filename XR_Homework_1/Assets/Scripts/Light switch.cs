using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light light;
{
    void Start()
    {
        light = GetComponent<Light>();

        if (Input.getKeyDown("tab"))
        {
            light.color = blue;
        }
    }
}
