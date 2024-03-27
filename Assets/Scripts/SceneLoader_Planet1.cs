using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader_Planet1 : MonoBehaviour
{
    public string sceneName;
    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
