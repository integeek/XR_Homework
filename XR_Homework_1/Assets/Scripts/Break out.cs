using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Breakout : MonoBehaviour
{
    public Transform internalRoom;
    public Transform externalRoom;
    public InputActionReference action;
    private bool onTheRoom = true;

    void Start()
    {
        SetInternalView();
        action.action.Enable();
        action.action.performed += OnActionPerformed;
    }

    void OnActionPerformed(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValueAsButton())
        {
            ToggleView();
        }
    }

    void ToggleView()
    {
        if (onTheRoom)
        {
            SetExternalView();
        }
        else
        {
            SetInternalView();
        }
    }

    void SetInternalView()
    {
        transform.position = internalRoom.position;
        transform.rotation = internalRoom.rotation;
        onTheRoom = true;
    }

    void SetExternalView()
    {
        transform.position = externalRoom.position;
        transform.rotation = externalRoom.rotation;
        onTheRoom = false;
    }

    void OnDisable()
    {
        if (action != null && action.action != null)
        {
            action.action.Disable();
        }
    }
}

