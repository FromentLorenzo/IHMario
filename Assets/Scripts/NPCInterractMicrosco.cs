using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInterractMicroscope : MonoBehaviour
{
    public Transform microscopePosition;
    public GameObject microscope;
    public GameObject microscopeEyepiece;
    private Vector3 initialCameraPosition;
    private Quaternion initialCameraRotation;
    private Transform playerCamera;
    public Canvas canvasToToggle;

    private void Start()
    {
        playerCamera = Camera.main.transform;
        canvasToToggle.enabled = false;
        if (microscopeEyepiece != null)
        {
            microscopeEyepiece.SetActive(false);
        }
    }

    public void Interract()
    {
        initialCameraPosition = playerCamera.position;
        initialCameraRotation = playerCamera.rotation;
        StartCoroutine(MoveCameraTowardsMicroscope());
    }

    private IEnumerator MoveCameraTowardsMicroscope()
    {
        float duration = 1.8f; // Durée du déplacement de la caméra
        Vector3 initialCameraPosition = Camera.main.transform.position;
        Quaternion initialCameraRotation = Camera.main.transform.rotation;

        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            Camera.main.transform.position = Vector3.Lerp(initialCameraPosition, microscopePosition.position, elapsed / duration);
            Camera.main.transform.rotation = Quaternion.Slerp(initialCameraRotation, microscopePosition.rotation, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Assurez-vous que la caméra est exactement à la position et à la rotation du microscope
        Camera.main.transform.position = microscopePosition.position;
        Camera.main.transform.rotation = microscopePosition.rotation;
        if (microscopeEyepiece != null)
        {
			Debug.Log("Microscope desactivated");
            microscope.SetActive(false);
            microscopeEyepiece.SetActive(true);
            canvasToToggle.enabled = true;
            // Désactiver d'autres éléments de la scène ici si nécessaire
        }
    }

    public void ResetCamera()
    {
        canvasToToggle.enabled = false;
        Debug.Log("Reset Camera in other file");
        // Restaurer la position et la rotation initiales de la caméra
			microscope.SetActive(true);
            microscopeEyepiece.SetActive(false);
        playerCamera.position = initialCameraPosition;
        playerCamera.rotation = initialCameraRotation;
    }
}
