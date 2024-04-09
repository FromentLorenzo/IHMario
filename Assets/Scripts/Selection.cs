using UnityEngine;

public class Selection : MonoBehaviour
{
    private UIController uiController;
    private HubCameraController cameraController;
    private lumaController lumaController;

    public Transform lumaInitialPosition;

    public int enteredNumber;

    public string planetName;

    void Start()
    {
        cameraController = FindObjectOfType<HubCameraController>();
        uiController = FindObjectOfType<UIController>();
        lumaController = FindObjectOfType<lumaController>();
    }

    private void OnMouseDown()
    {
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
