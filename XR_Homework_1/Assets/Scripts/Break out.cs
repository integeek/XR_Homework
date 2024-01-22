using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakout : MonoBehaviour
{
    public Transform internalRoom;
    public Transform externalRoom;
    private bool onTheRoom = true;

    void Start()
    {
        SetInternalView();
    }

    void Update()
    {
        if (Input.GetKeyDown("Controller/Trigger"))
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
}
