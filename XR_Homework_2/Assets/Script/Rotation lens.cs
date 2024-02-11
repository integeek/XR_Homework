using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnifyingLens : MonoBehaviour
{
    public Camera magnifyingCamera;
    public Transform playerCamera;


    void Update()
    {
        Quaternion playerRotation = playerCamera.rotation;
        magnifyingCamera.transform.rotation = playerRotation;
    }
}

