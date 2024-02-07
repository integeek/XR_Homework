using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotationlens : MonoBehaviour
{
    public Transform playerCamera; 

    void LateUpdate()
    {
        transform.position = playerCamera.position;
        transform.rotation = Quaternion.Euler(0f, playerCamera.eulerAngles.y, 0f); 
    }
}
