using UnityEngine;

public class InputController : MonoBehaviour
{
    public TutorialManager tutorialManager;

    void Update()
    {
        // Si la barre d'espace est enfoncée
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Si le bouton OK est actif, déclenche son événement
            if (tutorialManager.okButton.gameObject.activeSelf)
            {
                tutorialManager.OnOkButtonClick();
            }
            // Si le bouton Go est actif, déclenche son événement
            else if (tutorialManager.goButton.gameObject.activeSelf)
            {
                tutorialManager.OnGoButtonClick();
            }
        }
    }
}
