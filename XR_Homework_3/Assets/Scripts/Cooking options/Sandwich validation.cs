using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SandwichValidation : MonoBehaviour
{
    public string platTag;
    public TMP_Text textePlat;
    public Color couleurBarrage = Color.green;

    public void ValidateSandwich()
    {
        // Vérifier si l'objet a le tag spécifié
        if (gameObject.CompareTag(platTag))
        {
            // Désactiver l'objet
            gameObject.SetActive(false);

            // Changer la couleur du texte de la validation si disponible
            if (textePlat != null)
            {
                textePlat.color = couleurBarrage;
            }
        }
    }
}
