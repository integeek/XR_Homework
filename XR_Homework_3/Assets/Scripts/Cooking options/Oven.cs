using UnityEngine;

public class Oven : MonoBehaviour
{
    public string tagEggcooked = "Eggcooked";
    public string tagApple = "Apple";
    public string tagPlate = "Plate";

    public GameObject piePrefab;
    public Transform spawnPoint; 

    private bool hasEggcooked = false;
    private bool hasApple = false;
    private bool hasPlate = false;

    public void ButtonPressed()
    {
        TryMakePie();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagApple))
        {
            hasApple = true;
        }
        else if (other.CompareTag(tagEggcooked))
        {
            hasEggcooked = true;
        }
        else if (other.CompareTag(tagPlate))
        {
            hasPlate = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
       if (other.CompareTag(tagApple))
        {
            hasApple = false;
        }
        else if (other.CompareTag(tagEggcooked))
        {
            hasEggcooked = false;
        }
        else if (other.CompareTag(tagPlate))
        {
            hasPlate = false;
        }
    }

    private void TryMakePie()
    {
        if (hasApple && hasEggcooked && hasPlate)
        {
            Instantiate(piePrefab, spawnPoint.position, Quaternion.identity);

            DestroyAllFood();

            hasApple = false;
            hasEggcooked = false;
            hasPlate = false; 
        }
    }

    private void DestroyAllFood()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag(tagApple) || collider.CompareTag(tagEggcooked) || collider.CompareTag(tagPlate))
            {
                Destroy(collider.gameObject);
            }
        }
    }
}
