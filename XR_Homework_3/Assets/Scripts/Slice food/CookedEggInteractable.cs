using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CookedEggInteractable : MonoBehaviour
{
    void Start()
    {
        // Ajouter le composant XRGrabInteractable à cet objet
        XRGrabInteractable grabInteractable = gameObject.AddComponent<XRGrabInteractable>();
        // Ajoutez ici d'autres paramètres ou configuration si nécessaire
    }
}
