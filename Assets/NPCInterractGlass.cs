using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInterractGlass : MonoBehaviour
{
    public Transform cameraPosition;
    public ParticleSystem explosion;
    public ParticleSystem smoke3;
    public ParticleSystem smoke1;
    private Vector3 initialCameraPosition;
    private Quaternion initialCameraRotation;
    private Transform playerCamera;
    public Canvas canvasToToggle;
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    public GameObject fiole3;
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
            //changer couleur material
        }
        if (cubeSelected == cube3)
        {
            explosion.Play();
            fiole3.SetActive(false);
            smoke3.Play();
        }
    }
}
