using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class TutorialManager : MonoBehaviour
{
    public List<TutorialMessage> tutorialMessages;
    public TMP_Text messageText; 
    //public Button okButton;

    private int currentIndex = 0;

    void Start()
    {
        tutorialMessages = new List<TutorialMessage>();
        tutorialMessages.Add(new TutorialMessage("Welcome to your new kitchen.\nUse the left joystick to move yourself and the right joystick to move the camera.\nUse the trigger to grab and the Y button to reset the kitchen "));
        tutorialMessages.Add(new TutorialMessage("You have to realize 3 orders : a sandwich, a pizza and a pie. \nThe recipes for each order are next to the material. \nWhen you have the dish, place it on the plate provided for this purpose and press the button to validate it."));
        tutorialMessages.Add(new TutorialMessage("You can cut with the knife, throw food in the trash and obviously open the fridge, the oven and the microwave. \nBread and plates are generated infinitely but this is not the case for food. \nGood luck in carrying out the 3 orders"));
        ShowCurrentMessage();
    }

    void ShowCurrentMessage()
{
    if (currentIndex < tutorialMessages.Count)
    {
        messageText.text = tutorialMessages[currentIndex].text;
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
