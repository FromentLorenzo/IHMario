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
    void Start()
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

    // Update is called once per frame
    public void Interract()
    {
        Debug.Log("Interract");
        initialCameraPosition = playerCamera.position;
        initialCameraRotation = playerCamera.rotation;
        StartCoroutine(MoveCameraTowardsGlass());
    }
    
    
    private IEnumerator MoveCameraTowardsGlass()
    {
        float duration = 1.8f; // Durée du déplacement de la caméra
        Vector3 initialCameraPosition = Camera.main.transform.position;
        Quaternion initialCameraRotation = Camera.main.transform.rotation;

        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            Camera.main.transform.position = Vector3.Lerp(initialCameraPosition, cameraPosition.position, elapsed / duration);
            Camera.main.transform.rotation = Quaternion.Slerp(initialCameraRotation, cameraPosition.rotation, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        Debug.Log("Glass");
        cube1.SetActive(true);
        cube2.SetActive(true);
        cube3.SetActive(true);
        // Assurez-vous que la caméra est exactement à la position et à la rotation du microscope
        Camera.main.transform.position = cameraPosition.position;
        Camera.main.transform.rotation = cameraPosition.rotation;
        
        canvasToToggle.enabled = true;
        
    }
    public void cubeSelected(GameObject  cubeSelected)
    {
        if (cubeSelected == cube1)
        {
            smoke1.Play();
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
            Debug.LogWarning("Impossible de convertir la couleur hexadécimale en RVB. Utilisation de la couleur blanche par défaut.");
            return Color.white;
        }
    }
    
    private void ChangeMaterialColor(Material material, Color color)
    {
        material.color = color;
    }
    
   
}
