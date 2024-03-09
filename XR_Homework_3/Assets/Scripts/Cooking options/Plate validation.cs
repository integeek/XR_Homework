using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlateValidation : MonoBehaviour
{
    public string platTag; // Tag du plat associé à cette assiette
    public TMP_Text textePlat; // Référence au texte associé au plat
    public Color couleurBarrage = Color.green; // Couleur à utiliser pour barrer le texte

    public void ValidatePlate()
    {
        // Vérifier si un plat correspondant est sur l'assiette
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2f);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag(platTag))
            {
                // Faire disparaître l'assiette et le plat associé
                gameObject.SetActive(false);
                collider.gameObject.SetActive(false);

                // Mettre à jour le texte associé au plat (si disponible)
                if (textePlat != null)
                {
                    textePlat.color = couleurBarrage;
                }
                return;
            }
        }
    }
}
