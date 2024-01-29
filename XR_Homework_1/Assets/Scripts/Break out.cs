using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Breakout : MonoBehaviour
{
    public InputActionReference action;
    void Start()
    {

    }

    void Update()
    {
        action.action.Enable();
        action.action.performed += (ctx) =>
        {
            if (transform.position == new Vector3(0, 0, 0))
            {
                transform.Translate(new Vector3(-15f, 10f, -16f));
            }
            else if (transform.position == new Vector3(-15f, 10f, -16f))
            {
                transform.Translate(new Vector3(15f, -10f, 16f));
            }
        };
    }
}