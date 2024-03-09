using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections.Generic;

public class SandwichPlate : MonoBehaviour
{
    public List<string> ordreAttendu = new List<string>() { "bread", "tomatoslice", "cheese", "bread" };
    public List<Transform> alimentsEmpiles = new List<Transform>();
    public Transform pointDeSpawn;
    public GameObject sandwichContainer;

    private int indexProchainAliment = 0;
    private XRGrabInteractable sandwichGrabInteractable;

    private void Start()
    {
        // Récupérer le composant XRGrabInteractable du conteneur du sandwich
        sandwichGrabInteractable = sandwichContainer.GetComponent<XRGrabInteractable>();

        // Désactiver le composant XRGrabInteractable du conteneur du sandwich initialement
        sandwichGrabInteractable.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Aliment"))
        {
            string tagAliment = other.gameObject.tag.ToLower();

            if (indexProchainAliment >= ordreAttendu.Count)
            {
                Debug.Log("Tous les aliments attendus ont déjà été empilés !");
                return;
            }

            if (tagAliment == ordreAttendu[indexProchainAliment])
            {
                alimentsEmpiles.Add(other.transform);
                other.transform.parent = sandwichContainer.transform;
                other.transform.rotation = Quaternion.identity;

                // Désactiver le composant XR Grab Interactable de l'aliment
                XRGrabInteractable grabInteractable = other.GetComponent<XRGrabInteractable>();
                if (grabInteractable != null)
                {
                    grabInteractable.enabled = false;
                }

                Rigidbody rb = other.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = true;
                }

                UpdateAlimentPosition(other.transform);
                indexProchainAliment++;

                if (indexProchainAliment >= ordreAttendu.Count)
                {
                    // Activer le collider du sandwich entier pour permettre de le prendre
                    sandwichGrabInteractable.enabled = true;
                }
            }
            else
            {
                Debug.Log("Cet aliment n'est pas dans le bon ordre !");
            }
        }
    }

    private void UpdateAlimentPosition(Transform aliment)
    {
        float hauteurEmpilement = 0f;
        foreach (Transform a in alimentsEmpiles)
        {
            hauteurEmpilement += a.GetComponent<Renderer>().bounds.size.y;
        }

        Vector3 newPosition = transform.position;
        newPosition.y += hauteurEmpilement;
        aliment.position = newPosition;
    }
}
