using System;
using UnityEngine;

public class EventManager : MonoBehaviour
    {
        public static EventManager Instance;

        public delegate void SceneFinishedDelegate(int sceneIndex);
        public event SceneFinishedDelegate OnSceneFinished;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void SceneFinished(int sceneIndex)
        {
            OnSceneFinished?.Invoke(sceneIndex);
        }
    }