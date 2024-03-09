using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlateValidation : MonoBehaviour
{
    public string platTag; 
    public TMP_Text textePlat; 
    public Color couleurBarrage = Color.green; 

    public void ValidatePlate()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2f);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag(platTag))
            {
                gameObject.SetActive(false);
                collider.gameObject.SetActive(false);

                if (textePlat != null)
                {
                    textePlat.color = couleurBarrage;
                }
                return;
            }
        }
    }
}
