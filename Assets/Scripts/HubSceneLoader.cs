using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubSceneLoader : MonoBehaviour
{
    private UIController uiController;

    public Animator crossFade;

     void Start()
    {
       uiController = FindObjectOfType<UIController>();
    }

    public void LoadScene()
    {
        crossFade.SetTrigger("Start");
        StartCoroutine(LoadSceneCoroutine());
    }

    IEnumerator LoadSceneCoroutine()
    {
        // Wait for the animation to finish (assuming the crossfade animation takes 1 second)
        yield return new WaitForSeconds(1);
        
        // Check if the UIController and its selected planet value are valid
        if (uiController != null)
        {
            // Load the scene associated with the selected planet
            SceneManager.LoadScene(uiController.getplanetseleced());
        }
        else
        {
            // Log an error if the UIController or the selected planet is invalid
            Debug.LogError("UIController or selected planet is invalid.");
        }
    }
}
