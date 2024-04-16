using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubSceneLoader : MonoBehaviour
{
    private UIController uiController;
    public Animator crossFade;
    private AudioSource audioSource;

    void Start()
    {
        uiController = FindObjectOfType<UIController>();
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void LoadScene()
    {
        crossFade.SetTrigger("Start");
        StartCoroutine(LoadSceneCoroutine());
    }

    IEnumerator LoadSceneCoroutine()
    {
        yield return new WaitForSeconds(1);
        if (uiController != null)
        {
            SceneManager.LoadScene(uiController.getplanetseleced());
        }
        else
        {
            Debug.LogError("UIController or selected planet is null.");
        }
    }

    public void PlaySoundA(AudioClip audioClip)
    {
        if (audioClip != null && audioSource != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Audio clip or audio source is null.");
        }
    }
}
