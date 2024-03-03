using UnityEngine;

public class ButtonSandwich : MonoBehaviour
{
    public float fadeDuration = 2f; // Durée de la disparition
    public GameObject assiette; // Référence à l'assiette

    private bool buttonPressed = false;

    private void Update()
    {
        // Vérifiez si le bouton a été pressé
        if (buttonPressed)
        {
            // Commencez à faire disparaître l'assiette
            FadeOut(assiette);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Appelez la fonction pour simuler le pressage du bouton
            OnButtonPressed();
        }
    }

    // Fonction pour faire disparaître un objet progressivement
    private void FadeOut(GameObject obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        Color color = renderer.material.color;
        color.a -= Time.deltaTime / fadeDuration;
        renderer.material.color = color;

        // Si l'opacité est inférieure à zéro, désactivez l'objet
        if (color.a <= 0f)
        {
            obj.SetActive(false);
        }
    }

    // Fonction appelée lorsque le bouton est pressé
    public void OnButtonPressed()
    {
        // Activez le déclencheur pour commencer à faire disparaître l'assiette
        buttonPressed = true;
    }
}
