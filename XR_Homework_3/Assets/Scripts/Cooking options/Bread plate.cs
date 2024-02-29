using UnityEngine;

public class BreadPlate : MonoBehaviour
{
    public GameObject breadSlicePrefab; // Référence au prefab de la tranche de pain
    public Transform spawnPoint; // Point de spawn de la nouvelle tranche de pain

    void Update()
    {
        // Vérifiez s'il n'y a plus de tranche de pain sur l'assiette
        if (!HasBreadSliceOnPlate())
        {
            // Générez une nouvelle tranche de pain à l'emplacement du spawnPoint
            Instantiate(breadSlicePrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    bool HasBreadSliceOnPlate()
    {
        // Déterminez s'il y a une tranche de pain sur l'assiette
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2f);
        
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("Bread"))
            {
                // Une tranche de pain a été détectée sur l'assiette
                return true;
            }
        }
        
        // Aucune tranche de pain détectée sur l'assiette
        return false;
    }
}
