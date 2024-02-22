using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEnter;
    [SerializeField] UnityEvent onTriggerExit;

    public GameObject particlesGameObject; // Référence vers le GameObject contenant le Particle System

    void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke();

        // Activer les particules lorsque le déclencheur est activé
        if (particlesGameObject != null)
        {
            particlesGameObject.SetActive(true);
        }

        // Détruire l'objet détecté
        Destroy(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        onTriggerExit.Invoke();

        // Désactiver les particules lorsque le déclencheur est désactivé
        if (particlesGameObject != null)
        {
            particlesGameObject.SetActive(false);
        }
    }
}
