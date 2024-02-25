using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SliceMushroom : MonoBehaviour
{
public GameObject objectToSlice; 
    public GameObject slicePrefab; 
/*
    private void Update()
    {
        // Détecter si la barre d'espace est enfoncée
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Slice();
        }
    }
*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Knife")) 
        {
            Slice();
        }
    }

  private void Slice()
    {
        if (objectToSlice != null)
        {
            Vector3 objectPosition = objectToSlice.transform.position;

            float offset = 0.05f; 
            GameObject leftSlice = Instantiate(slicePrefab, objectPosition + Vector3.left * offset, Quaternion.identity);
            GameObject rightSlice = Instantiate(slicePrefab, objectPosition + Vector3.right * offset, Quaternion.identity);

            leftSlice.AddComponent<Rigidbody>().useGravity = true;
            rightSlice.AddComponent<Rigidbody>().useGravity = true;

            leftSlice.AddComponent<XRGrabInteractable>();
            rightSlice.AddComponent<XRGrabInteractable>();

            Destroy(objectToSlice);
    }
    }
}
