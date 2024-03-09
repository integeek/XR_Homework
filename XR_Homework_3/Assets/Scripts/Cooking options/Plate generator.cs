using UnityEngine;

public class Plategenerator : MonoBehaviour
{
    public GameObject platePrefab; 
    public Transform spawnPoint; 

    void Update()
    {
        // Vérifiez s'il n'y a plus de tranche de pain sur l'assiette
        if (!HasPlateOnPlate())
        {
            // Générez une nouvelle tranche de pain à l'emplacement du spawnPoint
            Instantiate(platePrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    bool HasPlateOnPlate()
    {
        // Déterminez s'il y a une tranche de pain sur l'assiette
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2f);
        
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("Plate"))
            {
                // Une tranche de pain a été détectée sur l'assiette
                return true;
            }
        }
        
        // Aucune tranche de pain détectée sur l'assiette
        return false;
    }
}
