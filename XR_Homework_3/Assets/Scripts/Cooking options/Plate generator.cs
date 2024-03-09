using UnityEngine;

public class Plategenerator : MonoBehaviour
{
    public GameObject platePrefab; 
    public Transform spawnPoint; 

    void Update()
    {
        if (!HasPlateOnPlate())
        {
            Instantiate(platePrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    bool HasPlateOnPlate()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2f);
        
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("Plate"))
            {
                return true;
            }
        }
        
        return false;
    }
}
