using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotationlens2 : MonoBehaviour
{
    public Transform cameraPlayer;
    public Transform lens;

    void Update()
    {
        Vector3 localPlayer = lens.InverseTransformPoint(cameraPlayer.position);
        transform.position = lens.TransformPoint(new Vector3(localPlayer.x, localPlayer.y, localPlayer.z));

        Vector3 lookatmirror = lens.TransformPoint(new Vector3(-localPlayer.x, -localPlayer.y, -localPlayer.z));
        transform.LookAt(lookatmirror, lens.up);
    }
}
