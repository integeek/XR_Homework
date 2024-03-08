using UnityEngine;

public class InputController : MonoBehaviour
{
    public TutorialManager tutorialManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tutorialManager.OnOkButtonClick();
        }
    }
}
