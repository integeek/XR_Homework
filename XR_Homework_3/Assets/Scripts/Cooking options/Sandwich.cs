using UnityEngine;

public class Sandwich : MonoBehaviour
{
    // Les couches des aliments et de l'assiette
    public LayerMask foodLayer;
    public LayerMask plateLayer;

    // Le transform parent des aliments empilés
    public Transform stackHolder;

    // Distance maximale pour empiler les aliments
    public float maxStackDistance = 1;

    // Le coefficient de frottement entre les aliments pour les coller ensemble
    public float frictionCoefficient = 0.5f;

    // Fonction appelée lorsqu'un aliment entre en collision avec un autre
    private void OnCollisionEnter(Collision collision)
    {
        // Vérifier si l'objet en collision est un aliment
        if (foodLayer == (foodLayer | (1 << collision.gameObject.layer)))
        {
            // Récupérer le Rigidbody de l'aliment
            Rigidbody foodRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (foodRigidbody != null)
            {
                // Récupérer la distance entre l'aliment et le transform parent des aliments empilés
                float distanceToStack = Vector3.Distance(collision.transform.position, stackHolder.position);

                // Si la distance est inférieure à la distance maximale de pile
                if (distanceToStack <= maxStackDistance)
                {
                    // Coller l'aliment avec les autres
                    foodRigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    foodRigidbody.drag = frictionCoefficient;
                    foodRigidbody.angularDrag = frictionCoefficient;

                    // Définir le transform parent de l'aliment sur celui des aliments empilés
                    collision.transform.SetParent(stackHolder);
                }
            }
        }
    }

    // Fonction appelée lorsqu'un aliment quitte la collision avec un autre
    private void OnCollisionExit(Collision collision)
    {
        // Vérifier si l'objet en collision est un aliment
        if (foodLayer == (foodLayer | (1 << collision.gameObject.layer)))
        {
            // Réinitialiser les contraintes et le transform parent de l'aliment
            Rigidbody foodRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (foodRigidbody != null)
            {
                foodRigidbody.constraints = RigidbodyConstraints.None;
                collision.transform.SetParent(null);
            }
        }
    }
}
