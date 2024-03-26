using UnityEngine;

public class Selection : MonoBehaviour
{
    private UIController uiController;
    private HubCameraController cameraController;
    private lumaController lumaController;

    public Transform lumaInitialPosition;

    public int enteredNumber;

    void Start()
    {
        cameraController = FindObjectOfType<HubCameraController>();
        uiController = FindObjectOfType<UIController>();
        lumaController = FindObjectOfType<lumaController>();
    }

    private void OnMouseDown()
    {
        uiController.ShowUI(enteredNumber);        
        cameraController.MoveAndZoomTowards(transform);
        lumaController.MoveTowards(transform);
    }
    
    public void ResetCameraPosition()
    {
        cameraController.ResetCameraPosition();
        lumaController.MoveToInitialPosition();
    }
}
