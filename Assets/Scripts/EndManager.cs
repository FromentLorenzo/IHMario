using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
    {
        private HashSet<int> scenesCompleted = new HashSet<int>();

        private void Start()
        {
            EventManager.Instance.OnSceneFinished += OnSceneFinished;
        }

        private void OnDisable()
        {
            EventManager.Instance.OnSceneFinished -= OnSceneFinished;
        }

        private void OnSceneFinished(int sceneIndex)
        {
            Debug.Log("On Scene Finished");
            if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                scenesCompleted.Add(sceneIndex);
                Debug.Log("Scene " + sceneIndex + " completed.");
            }
            else
            {
                Debug.LogError("Invalid scene index: " + sceneIndex);
            }

            if (AllScenesCompleted())
            {
                ShowEndScreen();
            }
        }

        private bool AllScenesCompleted()
        {
            return scenesCompleted.Count == 3;
        }

        private void ShowEndScreen()
        {
            Debug.Log("All scenes completed. Showing end screen.");
            scenesCompleted.Clear();
            SceneManager.LoadScene("endScene");
        }
    }
