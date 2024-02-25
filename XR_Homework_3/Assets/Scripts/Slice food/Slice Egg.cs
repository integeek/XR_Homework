using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceEgg : MonoBehaviour
{
    public float breakSpeedThreshold = 1.0f; // Seuil de vitesse pour la casse de l'œuf
    public GameObject cookedEggPrefab; // Préfabriqué de l'œuf cuit

    private void OnCollisionEnter(Collision collision)
    {
        // Vérifier si la collision est avec le sol ou une surface
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Surface"))
        {
            // Calculer la vitesse de l'œuf lors de la collision
            float collisionSpeed = collision.relativeVelocity.magnitude;
            Debug.Log("Vitesse de l'œuf : " + collisionSpeed);
            // Déterminer si l'œuf doit se casser en fonction de sa vitesse
            if (collisionSpeed >= breakSpeedThreshold)
            {
                // Instancier l'œuf cuit à la position de l'œuf cru
                Instantiate(cookedEggPrefab, transform.position, Quaternion.identity);

                // Détruire l'œuf cru
                Destroy(gameObject);
            }
        }
    }
}
