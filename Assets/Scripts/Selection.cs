using UnityEngine;

public class Selection : MonoBehaviour
{
    private UIController uiController;
    private HubCameraController cameraController;
    private lumaController lumaController;

    public Transform lumaInitialPosition;
    public AudioClip hoverSound;
    private AudioSource audioSource;

    public int enteredNumber;

    public string planetName;

    void Start()
    {
        cameraController = FindObjectOfType<HubCameraController>();
        uiController = FindObjectOfType<UIController>();
        lumaController = FindObjectOfType<lumaController>();
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnMouseDown()
    {
        audioSource.clip = hoverSound;
        audioSource.Play();
        uiController.ShowUI(enteredNumber);
        uiController.UpdateText(planetName);        
        cameraController.MoveAndZoomTowards(transform);
        lumaController.MoveTowards(transform);
    }
    
    public void ResetCameraPosition()
    {
        cameraController.ResetCameraPosition();
        lumaController.MoveToInitialPosition();
    }
}
