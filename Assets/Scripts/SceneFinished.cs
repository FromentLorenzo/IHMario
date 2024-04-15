using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneFinished : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                FinishScene();
            }
        }

        private void FinishScene()
        {
            Debug.Log("Scene Finished");
            int sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
            EventManager.Instance.SceneFinished(sceneBuildIndex);
        }
    }
