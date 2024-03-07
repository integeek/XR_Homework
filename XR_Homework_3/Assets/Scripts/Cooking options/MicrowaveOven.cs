using UnityEngine;

public class MicrowaveOven : MonoBehaviour
{
    public string tagTomate = "Tomate";
    public string tagFromage = "Fromage";
    public GameObject pizzaPrefab;
    public Transform spawnPoint; // Point de spawn pour la pizza

    private bool hasTomate = false;
    private bool hasFromage = false;

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
    }

    private void TryMakePizza()
    {
        if (hasTomate && hasFromage)
        {
            // Créer la pizza en utilisant le prefab et la position du point de spawn
            Instantiate(pizzaPrefab, spawnPoint.position, Quaternion.identity);

            // Détruire les aliments présents dans le four à micro-ondes
            DestroyAllFood();

            // Remettre les états des aliments à faux pour la prochaine utilisation
            hasTomate = false;
            hasFromage = false;
        }
    }

    private void DestroyAllFood()
    {
        // Rechercher tous les aliments dans le four à micro-ondes et les détruire
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag(tagTomate) || collider.CompareTag(tagFromage))
            {
                Destroy(collider.gameObject);
            }
        }
    }
}
