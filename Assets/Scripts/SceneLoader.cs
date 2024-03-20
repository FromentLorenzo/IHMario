using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadRaceTrackScene()
    {
        SceneManager.LoadScene("Scenes/SampleScene"); // Load scene at index 1
    }
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MainMenu"); // Load scene at index 0
    }
}
