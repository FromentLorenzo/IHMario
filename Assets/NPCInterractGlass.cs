using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCInterractGlass : MonoBehaviour
{
    public Transform cameraPosition;
    public ParticleSystem explosion;
    public Material fiole2Liquid;
    public ParticleSystem smoke3;
    public ParticleSystem smoke1;
    public GameObject canvasGameObject;
    private Vector3 initialCameraPosition;
    private Quaternion initialCameraRotation;
    private Transform playerCamera;
    public Canvas canvasToToggle;
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    public GameObject fiole3;
    private TMP_Text canvasText;
    // Start is called before the first frame update
    public void Start()
    {
        playerCamera = Camera.main.transform;
        canvasToToggle.enabled = false;
        cube1.SetActive(false);
        cube2.SetActive(false);
        cube3.SetActive(false);
        smoke1.Stop();
        smoke3.Stop();
        explosion.Stop();
        ChangeMaterialColor(fiole2Liquid, HexToColor("#D3D71A"));
        canvasText = canvasGameObject.GetComponent<TMP_Text>();
    }

    // Called when interaction with the glass occurs
    public void Interract()
    {
        // Store the initial camera position and rotation
        initialCameraPosition = playerCamera.position;
        initialCameraRotation = playerCamera.rotation;
        StartCoroutine(MoveCameraTowardsGlass());
    }

    // Coroutine to move the camera towards the glass
    private IEnumerator MoveCameraTowardsGlass()
    {
        float duration = 1.8f; // Duration of camera movement
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            // Move the camera towards the glass
            Camera.main.transform.position = Vector3.Lerp(initialCameraPosition, cameraPosition.position, elapsed / duration);
            Camera.main.transform.rotation = Quaternion.Slerp(initialCameraRotation, cameraPosition.rotation, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the camera is exactly at the position and rotation of the glass
        Camera.main.transform.position = cameraPosition.position;
        Camera.main.transform.rotation = cameraPosition.rotation;
        Debug.Log("On repasse ici");
        cube1.SetActive(true);
        cube2.SetActive(true);
        cube3.SetActive(true);

        // Enable necessary components after reaching the glass position
        canvasToToggle.enabled = true;
    }
    public void cubeSelected(GameObject  cubeSelected)
    {
        if (cubeSelected == cube1)
        {
            smoke1.Play();
            canvasText.text = "Peach, c'était pas celui là ! On va s'étouffer avec la fumée !";
        }
        if (cubeSelected == cube2)
        {
            ChangeMaterialColor(fiole2Liquid, HexToColor("#BE3058"));
            canvasText.text = "Oh tu as finalement réussi ! Je te remercierai jamais assez pour ton aide. Tu es un véritable génie !";
        }
        if (cubeSelected == cube3)
        {
            explosion.Play();
            fiole3.SetActive(false);
            smoke3.Play();
            canvasText.text = "MA FIOLE!! Peach tu as fait exploser ma fiole ! Tu es un danger public !";
        }
    }
    
    private Color HexToColor(string hex)
    {
        Color color = Color.white;
        if (ColorUtility.TryParseHtmlString(hex, out color))
        {
            return color;
        }
        else
        {
            return Color.white;
        }
    }
    
    private void ChangeMaterialColor(Material material, Color color)
    {
        material.color = color;
    }
    
    public void ResetCamera()
    {
        Debug.Log("Reset Camera glass");
        // Restore the initial position and rotation of the camera
        Camera.main.transform.position = initialCameraPosition;
        Camera.main.transform.rotation = initialCameraRotation;
        canvasToToggle.enabled = false;
        cube1.SetActive(false);
        cube2.SetActive(false);
        cube3.SetActive(false);
    }
    
   
}
