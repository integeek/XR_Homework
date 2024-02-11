using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotationlens2 : MonoBehaviour
{
    public Transform cameraPlayer;
    public Transform lens;

    void Update()
    {


        /* 
        Vector3 directionToCamera = cameraPlayer.position - lens.position;
        Vector3 mirroredDirection = Vector3.Reflect(directionToCamera, lens.up);
        transform.position = lens.position;
        transform.rotation = Quaternion.LookRotation(mirroredDirection, lens.up);
        */
    }
}
