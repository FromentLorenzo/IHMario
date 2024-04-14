using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public float rotationSpeed = 50f; // Vitesse de rotation en degrés par seconde

    void Update()
    {
        // Rotation autour de l'axe Y
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}