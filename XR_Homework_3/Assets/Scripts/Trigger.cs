using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public ParticleSystem particles; // Référence vers le système de particules

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet qui entre dans le trigger a un composant Rigidbody
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Désactive le rendu de l'objet
            other.gameObject.SetActive(false);
        }
    }
}
