using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadRaceTrackScene()
    {
        new WaitForSeconds(1);
        SceneManager.LoadScene("Scenes/SampleScene"); // Load scene at index 1
    }
    public void LoadMenuScene()
    {
        new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenu"); // Load scene at index 0
    }
    public void LoadEndRaceScene()
    {
        new WaitForSeconds(1);
        SceneManager.LoadScene("EndRaceScreen"); // Load scene at index 2
    }
    public void LoadLooseRaceScene()
    {
        new WaitForSeconds(1);
        SceneManager.LoadScene("LooseRaceScreen"); // Load scene at index 3
    }
    public void LoadHubScene()
    {
        new WaitForSeconds(1);
        SceneManager.LoadScene("Hub"); // Load scene at index 5
    }
}
