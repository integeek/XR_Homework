using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text messageText; // Référence au texte pour afficher les messages

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Fonction pour afficher un message à l'écran
    public void DisplayMessage(string message)
    {
        messageText.text = message;
    }
}
