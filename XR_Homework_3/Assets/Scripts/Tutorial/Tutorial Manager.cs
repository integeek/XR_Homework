using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class TutorialManager : MonoBehaviour
{
    public List<TutorialMessage> tutorialMessages;
    public TMP_Text messageText; 
    public GameObject okButton; // Référence au bouton OK
    public GameObject[] assiettes; // Références aux assiettes

    private int currentIndex = 0;
    private bool allAssiettesDisappeared = false;

    void Start()
    {
        tutorialMessages = new List<TutorialMessage>();
        tutorialMessages.Add(new TutorialMessage("Welcome to your new kitchen.\nUse the left joystick to move yourself and the right joystick to move the camera.\nUse the trigger to grab"));
        tutorialMessages.Add(new TutorialMessage("You have to realize 3 orders : a sandwich, a pizza and a pie. \nThe recipes for each order are next to the material. \nWhen you have the dish, place it on the plate provided for this purpose and press the button to validate it. \nFor the sandwich, just press the button next to the sandwich maker. "));
        tutorialMessages.Add(new TutorialMessage("You can cut with the knife, throw food in the trash and obviously open the fridge, the oven and the microwave. \nBread and plates are generated infinitely but this is not the case for food. \nGood luck in carrying out the 3 orders"));
        tutorialMessages.Add(new TutorialMessage("Congratulations ! You have successfully completed the game."));

        ShowCurrentMessage();
    }

    void Update()
    {
        // Vérifier si toutes les assiettes ont disparu
        if (!allAssiettesDisappeared && AllAssiettesDisappeared())
        {
            allAssiettesDisappeared = true;

            // Passer automatiquement au dernier message
            currentIndex = tutorialMessages.Count - 1;
            ShowCurrentMessage();
        }
    }

    void ShowCurrentMessage()
    {
        if (currentIndex < tutorialMessages.Count)
        {
            messageText.text = tutorialMessages[currentIndex].text;

            // Vérifier si nous sommes à l'avant-dernier message et désactiver le bouton OK
            if (currentIndex == tutorialMessages.Count - 2)
            {
                okButton.SetActive(false);
            }
        }
        else
        {
            // Si tous les messages ont été affichés, désactiver le Canvas ou faire autre chose
            gameObject.SetActive(false);
        }
    }

    public void OnOkButtonClick()
    {
        currentIndex++;
        ShowCurrentMessage();
    }

    bool AllAssiettesDisappeared()
    {
        foreach (GameObject assiette in assiettes)
        {
            if (assiette.activeSelf)
            {
                return false;
            }
        }
        return true;
    }
}

[System.Serializable]
public class TutorialMessage
{
    public string text;

    public TutorialMessage(string messageText)
    {
        text = messageText;
    }
}
