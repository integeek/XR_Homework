using UnityEngine;

public class SaltShaker : MonoBehaviour
{
    public GameObject saltGrainPrefab; // Référence au prefab des grains de sel
    public Transform spawnPoint; // Point de spawn des grains de sel
    public int numberOfGrains = 10; // Nombre de grains de sel à instancier lors d'une secousse
    public float shakeThreshold = 1f; // Seuil de secousse à partir duquel les grains de sel tombent
    public float shakeDetectionThreshold = 0.2f; // Seuil de détection de la secousse
    public float shakeDetectionTime = 0.2f; // Durée sur laquelle la secousse doit être détectée
    public float grainLifeTime = 5f; // Durée de vie des grains de sel avant d'être détruits

    private float shakeTimer = 0f;
    private Vector3 lastAcceleration;
    private bool isShaking = false;

    void Update()
    {
        // Récupérer l'accélération actuelle de l'appareil
        Vector3 currentAcceleration = Input.acceleration;

        // Calculer la variation d'accélération depuis la dernière frame
        Vector3 deltaAcceleration = currentAcceleration - lastAcceleration;

        // Calculer la magnitude de la variation d'accélération
        float deltaAccelerationMagnitude = deltaAcceleration.magnitude;

        // Mettre à jour la dernière accélération
        lastAcceleration = currentAcceleration;

        // Si la variation d'accélération dépasse le seuil de détection de secousse
        if (deltaAccelerationMagnitude > shakeDetectionThreshold)
        {
            // Démarrer le compteur de secousse
            shakeTimer = shakeDetectionTime;
            Debug.Log("Shake detected");
        }

        // Si le compteur de secousse est actif
        if (shakeTimer > 0)
        {
            // Décrémenter le compteur de secousse
            shakeTimer -= Time.deltaTime;

            // Si le compteur de secousse est encore actif après décrémentation
            if (shakeTimer > 0)
            {
                // Activer le drapeau de secousse
                isShaking = true;
            }
            else
            {
                // Sinon, désactiver le drapeau de secousse
                isShaking = false;
            }
        }
        else
        {
            // Sinon, désactiver le drapeau de secousse
            isShaking = false;
        }

        // Si le dispositif est secoué et que la condition de secousse est remplie
        if (isShaking && deltaAccelerationMagnitude > shakeThreshold)
        {
            ShakeSalt();
        }
    }

    void ShakeSalt()
    {
        Debug.Log("Shaking salt");
        for (int i = 0; i < numberOfGrains; i++)
        {
            // Calculer la position de départ des grains autour de l'attachement
            Vector3 spawnPosition = spawnPoint.position + Random.insideUnitSphere * 0.05f; // Variation de 0.05 unités autour de l'attachement

            // Instanciation d'un grain de sel à la position calculée
            GameObject saltGrain = Instantiate(saltGrainPrefab, spawnPosition, Quaternion.identity);
            Rigidbody saltRigidbody = saltGrain.GetComponent<Rigidbody>();

            // Appliquer une légère force initiale pour simuler la dispersion des grains
            saltRigidbody.AddForce(Random.insideUnitSphere * 0.5f, ForceMode.Impulse);

            // Désactiver la rotation sur les axes x et z
            saltRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;

            // Détruire le grain de sel après un certain temps
            Destroy(saltGrain, grainLifeTime);
        }
    }
}
