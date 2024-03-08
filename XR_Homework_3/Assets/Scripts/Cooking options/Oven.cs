using UnityEngine;

public class Oven : MonoBehaviour
{
    public string tagEggcooked = "Eggcooked";
    public string tagApple = "Apple";
    public string tagPlate = "Plate";

    public GameObject piePrefab;
    public Transform spawnPoint; // Point de spawn pour la pizza

    private bool hasEggcooked = false;
    private bool hasApple = false;
    private bool hasPlate = false;

    // Méthode appelée lorsque le bouton est pressé
    public void ButtonPressed()
    {
        TryMakePie();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagApple))
        {
            hasApple = true;
        }
        else if (other.CompareTag(tagEggcooked))
        {
            hasEggcooked = true;
        }
        else if (other.CompareTag(tagPlate))
        {
            hasPlate = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
       if (other.CompareTag(tagApple))
        {
            hasApple = false;
        }
        else if (other.CompareTag(tagEggcooked))
        {
            hasEggcooked = false;
        }
        else if (other.CompareTag(tagPlate))
        {
            hasPlate = false;
        }
    }

    private void TryMakePie()
    {
        if (hasApple && hasEggcooked && hasPlate)
        {
            // Créer la pizza en utilisant le prefab et la position du point de spawn
            Instantiate(piePrefab, spawnPoint.position, Quaternion.identity);

            // Détruire les aliments présents dans le four à micro-ondes
            DestroyAllFood();

            // Remettre les états des aliments à faux pour la prochaine utilisation
            hasApple = false;
            hasEggcooked = false;
            hasPlate = false; 
        }
    }

    private void DestroyAllFood()
    {
        // Rechercher tous les aliments dans le four à micro-ondes et les détruire
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag(tagApple) || collider.CompareTag(tagEggcooked) || collider.CompareTag(tagPlate))
            {
                Destroy(collider.gameObject);
            }
        }
    }
}
