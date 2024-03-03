using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class TutorialManager : MonoBehaviour
{
    public List<TutorialMessage> tutorialMessages;
    public TMP_Text messageText; 
    public Button okButton;
    public Button goButton; 

    private int currentIndex = 0;

    void Start()
    {
        tutorialMessages = new List<TutorialMessage>();
        tutorialMessages.Add(new TutorialMessage("Welcome to your new kitchen.\nUse the left joystick to move yourself and the right joystick to move the camera.\nUse the trigger to grab "));
        tutorialMessages.Add(new TutorialMessage("Your first order is to make a sandwich.\nFor that, take a piece of bread and put it on the plate.\nUse the knife to cut a tomato and take a piece of bacon.\nClose it with bread."));
        tutorialMessages.Add(new TutorialMessage("Your second order is to make a pizza.\nPut in the microwave a piece of cheese, an entire tomato and a piece of bread"));
        tutorialMessages.Add(new TutorialMessage("You have also to make fried eggs.\nBut there is no egg in the fridge.\nClick on the button to go get some."));
        ShowCurrentMessage();
    }

    void ShowCurrentMessage()
    {
        if (currentIndex < tutorialMessages.Count)
        {
            messageText.text = tutorialMessages[currentIndex].text;

            // Afficher le bouton "Go" seulement lors du dernier message
            if (currentIndex == tutorialMessages.Count - 1)
            {
                goButton.gameObject.SetActive(true);
            }
            else
            {
                goButton.gameObject.SetActive(false);
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

    public void OnGoButtonClick()
    {
        SceneTransitionManager.singleton.GoToSceneAsync(1); // Remplacez 1 par l'index ou le nom de votre scène de tutoriel
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
