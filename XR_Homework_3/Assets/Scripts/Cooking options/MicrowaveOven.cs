using UnityEngine;

public class MicrowaveOven : MonoBehaviour
{
    public string tagTomate = "Tomatoslice";
    public string tagFromage = "Fromage";
    public string tagMushroom = "Mushroomslice";
    public string tagBacon = "Bacon";
    public string tagBread = "Bread";

    public GameObject pizzaPrefab;
    public Transform spawnPoint; // Point de spawn pour la pizza

    private bool hasTomate = false;
    private bool hasFromage = false;
    private bool hasMushroom = false;
    private bool hasBacon = false;
    private bool hasBread = false;


    // Méthode appelée lorsque le bouton est pressé
    public void ButtonPressed()
    {
        TryMakePizza();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagTomate))
        {
            hasTomate = true;
        }
        else if (other.CompareTag(tagFromage))
        {
            hasFromage = true;
        }
        else if (other.CompareTag(tagMushroom))
        {
            hasMushroom = true;
        }
        else if (other.CompareTag(tagBacon))
        {
            hasBacon = true;
        }
        else if (other.CompareTag(tagBread))
        {
            hasBread = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagTomate))
        {
            hasTomate = false;
        }
        else if (other.CompareTag(tagFromage))
        {
            hasFromage = false;
        }
        else if (other.CompareTag(tagMushroom))
        {
            hasMushroom = false;
        }
        else if (other.CompareTag(tagBacon))
        {
            hasBacon = false;
        }
        else if (other.CompareTag(tagBread))
        {
            hasBread = false;
        }
    }

    private void TryMakePizza()
    {
        if (hasTomate && hasFromage && hasMushroom && hasBacon && hasBread)
        {
            // Créer la pizza en utilisant le prefab et la position du point de spawn
            Instantiate(pizzaPrefab, spawnPoint.position, Quaternion.identity);

            // Détruire les aliments présents dans le four à micro-ondes
            DestroyAllFood();

            // Remettre les états des aliments à faux pour la prochaine utilisation
            hasTomate = false;
            hasFromage = false;
            hasMushroom = false; 
            hasBacon = false;
            hasBread = false;
        }
    }

    private void DestroyAllFood()
    {
        // Rechercher tous les aliments dans le four à micro-ondes et les détruire
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag(tagTomate) || collider.CompareTag(tagFromage) || collider.CompareTag(tagMushroom) || collider.CompareTag(tagBacon) || collider.CompareTag(tagBread))
            {
                Destroy(collider.gameObject);
            }
        }
    }
}
