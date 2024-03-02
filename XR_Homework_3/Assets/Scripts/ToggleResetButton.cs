using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleResetScreen : MonoBehaviour
{
    public InputActionReference action;
    public GameObject resetScreen; // Référence à votre écran de réinitialisation
    private bool screenActive = false; // Variable pour suivre l'état de l'écran de réinitialisation

    void Start()
    {
        action.action.Enable();
        action.action.performed += ToggleScreenActivation;
    }

    private void ToggleScreenActivation(InputAction.CallbackContext ctx)
    {
        // Inverser l'état de l'écran de réinitialisation
        screenActive = !screenActive;
        // Activer ou désactiver l'écran de réinitialisation en fonction de son état
        resetScreen.SetActive(screenActive);
    }
}
