using System.Collections;
using UnityEngine;

public class HubCameraController : MonoBehaviour
{
    public float zoomSpeed = 5f; // Vitesse du zoom
    public Vector3 cameraOffset = new Vector3(0, 0, -10); // Offset de la caméra par rapport à l'objet sélectionné
    public float smoothFactor = 0.5f; // Facteur de lissage pour le mouvement de la caméra

    private Camera mainCamera;
    private Vector3 originalCameraPosition; // Position originale de la caméra
    private Quaternion originalCameraRotation; // Rotation originale de la caméra

    void Start()
    {
        mainCamera = Camera.main;
        originalCameraPosition = mainCamera.transform.position;
        originalCameraRotation = mainCamera.transform.rotation;
    }

    public void MoveAndZoomTowards(Transform targetTransform)
    {
        StartCoroutine(MoveAndZoomCamera(targetTransform));
    }

    IEnumerator MoveAndZoomCamera(Transform targetTransform)
    {
        Vector3 startPosition = mainCamera.transform.position;
        Quaternion startRotation = mainCamera.transform.rotation;

        Vector3 targetPosition = targetTransform.position + cameraOffset;
        Quaternion targetRotation = Quaternion.LookRotation(targetTransform.position - targetPosition);

        float step = 0.0f;
        while(step < 1.0f)
        {
            step += zoomSpeed * Time.deltaTime;
            mainCamera.transform.position = Vector3.Lerp(startPosition, targetPosition, step);
            mainCamera.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, step);

            yield return null;
        }
    }

    public void ResetCameraPosition()
    {
        StartCoroutine(ResetCamera());
    }

    IEnumerator ResetCamera()
    {
        Vector3 startPosition = mainCamera.transform.position;
        Quaternion startRotation = mainCamera.transform.rotation;

        float step = 0.0f;
        while(step < 1.0f)
        {
            step += zoomSpeed * Time.deltaTime;
            mainCamera.transform.position = Vector3.Lerp(startPosition, originalCameraPosition, step);
            mainCamera.transform.rotation = Quaternion.Slerp(startRotation, originalCameraRotation, step);

            yield return null;
        }
    }
}
