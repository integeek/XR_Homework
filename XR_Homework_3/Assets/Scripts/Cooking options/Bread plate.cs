using UnityEngine;

public class BreadPlate : MonoBehaviour
{
    public GameObject breadSlicePrefab;
    public Transform spawnPoint; 

    void Update()
    {
        if (!HasBreadSliceOnPlate())
        {
            Instantiate(breadSlicePrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    bool HasBreadSliceOnPlate()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2f);
        
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("Bread"))
            {
                return true;
            }
        }
        
        return false;
    }
}
