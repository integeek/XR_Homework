using System.Collections;
using UnityEngine;

public class MicrowaveOven : MonoBehaviour
{
    public Transform ingredientSlot; // Emplacement où les ingrédients sont placés
    public GameObject pizzaPrefab; // Préfabriqué de la pizza

    private bool isCooking = false;

    private void Update()
    {
        // Vérifiez si un bouton est enfoncé pour démarrer la cuisson
        if (Input.GetKeyDown(KeyCode.Space) && !isCooking)
        {
            StartCoroutine(CookPizza());
        }
    }

    private IEnumerator CookPizza()
    {
        // Vérifiez s'il y a des ingrédients à l'intérieur du four
        if (IsTomatoAndCheeseInside())
        {
            isCooking = true;

            // Attendre une seconde avant de créer la pizza
            yield return new WaitForSeconds(1f);

            // Instancier la pizza à l'emplacement de l'ingrédient
            Instantiate(pizzaPrefab, ingredientSlot.position, ingredientSlot.rotation);

            isCooking = false;
        }
    }

    private bool IsTomatoAndCheeseInside()
    {
        // Vérifiez s'il y a une tomate et du fromage à l'intérieur du four
        bool hasTomato = false;
        bool hasCheese = false;

        // Recherche les objets dans l'emplacement des ingrédients
        Collider[] colliders = Physics.OverlapSphere(ingredientSlot.position, 0.5f);

        foreach (Collider collider in colliders)
        {
            // Vérifiez s'il y a une tomate
            if (collider.CompareTag("Tomato"))
            {
                hasTomato = true;
            }

            // Vérifiez s'il y a du fromage
            if (collider.CompareTag("Cheese"))
            {
                hasCheese = true;
            }
        }

        // Retournez true si les deux ingrédients sont présents, sinon false
        return hasTomato && hasCheese;
    }
}
