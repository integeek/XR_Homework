using UnityEngine;
using System.Collections.Generic;

public class SandwichPlate : MonoBehaviour
{
    public List<string> ordreAttendu = new List<string>() {"bread", "tomato", "cheese", "bread"}; // Liste de l'ordre attendu des aliments dans le sandwich
    public List<Transform> alimentsEmpiles = new List<Transform>(); // Liste des aliments empilés
    public Transform pointDeSpawn; // Point de spawn pour les aliments

    private int indexProchainAliment = 0; // Index de l'aliment attendu dans l'ordre

   private void OnTriggerEnter(Collider other)
{
    // Vérifier si l'objet en collision a la layer "Aliment"
    if (other.gameObject.layer == LayerMask.NameToLayer("Aliment"))
    {
        // Récupérer le tag de l'aliment en minuscules
        string tagAliment = other.gameObject.tag.ToLower();

        // Vérifier si tous les aliments attendus ont déjà été empilés
        if (indexProchainAliment >= ordreAttendu.Count)
        {
            Debug.Log("Tous les aliments attendus ont déjà été empilés !");
            return;
        }

        // Vérifier si l'aliment correspond à l'aliment attendu dans l'ordre en minuscules
        if (tagAliment == ordreAttendu[indexProchainAliment])
        {
            // Ajouter l'aliment à la liste des aliments empilés
            alimentsEmpiles.Add(other.transform);

            // Mettre l'aliment sur l'assiette
            other.transform.parent = transform;

            // Normaliser l'orientation de l'aliment
            other.transform.rotation = Quaternion.identity;

            // Désactiver la gravité et le rigidbody pour éviter les problèmes de physique
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }

            // Mise à jour de la position pour empiler visuellement l'aliment
            UpdateAlimentPosition(other.transform);

            // Incrémenter l'index de l'aliment attendu dans l'ordre
            indexProchainAliment++;
        }
        else
        {
            // L'aliment ne correspond pas à l'aliment attendu dans l'ordre, donc ne pas l'ajouter au sandwich
            Debug.Log("Cet aliment n'est pas dans le bon ordre !");
        }
    }
}


private void UpdateAlimentPosition(Transform aliment)
    {
        // Calculer la hauteur de l'empilement des aliments
        float hauteurEmpilement = 0f;
        foreach (Transform a in alimentsEmpiles)
        {
            hauteurEmpilement += a.GetComponent<Renderer>().bounds.size.y;
        }

        // Placer l'aliment sur l'assiette à une hauteur appropriée
        Vector3 newPosition = transform.position;

        // La position Y de l'aliment est la position Y de l'assiette plus la hauteur de l'empilement
        newPosition.y += hauteurEmpilement;

        // Déplacer l'aliment sur l'assiette pour commencer l'empilement
        aliment.position = newPosition;
    }
}
