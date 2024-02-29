using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class PizzaTransformation : MonoBehaviour
{
    public GameObject pizza;

    public void TransformToPizza()
    {
        GameObject[] tomatoes = GameObject.FindGameObjectsWithTag("Tomato");
        GameObject[] cheeses = GameObject.FindGameObjectsWithTag("Cheese");

        if (tomatoes.Length > 0 && cheeses.Length > 0)
        {
            StartCoroutine(TransformCoroutine(tomatoes, cheeses));
        }
    }

    IEnumerator TransformCoroutine(GameObject[] tomatoes, GameObject[] cheeses)
    {
        // Masquer les tomates et le fromage
        foreach (GameObject tomato in tomatoes)
        {
            tomato.SetActive(false);
        }

        foreach (GameObject cheese in cheeses)
        {
            cheese.SetActive(false);
        }

        // Attendre une seconde
        yield return new WaitForSeconds(1f);

        // Afficher la pizza
        pizza.SetActive(true);
    }
}
