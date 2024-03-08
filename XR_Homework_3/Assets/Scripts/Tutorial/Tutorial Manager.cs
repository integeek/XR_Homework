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
        tutorialMessages.Add(new TutorialMessage("Your first order is to make a sandwich.\nFor that, look the recipe next to the sandwich maker on the table. \nOpen the fridge to find the ingredients and use the knife to cut. \nWhen the sandwich is finish, press the button next to the plate to validate it."));
        tutorialMessages.Add(new TutorialMessage("Your second order is to make a pizza.\nPut in the microwave a piece of cheese, a tomato slice, a mushroom slice, a piece of bacon and a piece of bread.\nDo not hesitate to look at the recipe next to the microwave."));
        tutorialMessages.Add(new TutorialMessage("Your last order is to make a pie in the oven. \nPut in the oven a plate, an entire apple and an egg a broken egg. \nYou can look at the recipe in the wall"));
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
