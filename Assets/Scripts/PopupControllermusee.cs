using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupControllermusee : MonoBehaviour
{
    public static bool IsUIActive { get; private set; }

    private static bool hasBeenCheck = false;

    public GameObject uiPanel; // Référence au panneau UI que vous voulez afficher ou masquer

    // Méthode appelée lorsque quelque chose entre dans le collider
    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'autre objet a un tag spécifique si nécessaire
        if (other.CompareTag("Player"))
        {
            if(hasBeenCheck == false)
            {
                // Appelle la méthode ShowUI du script PopupControllermusee
                this.ShowUI();



            }
            
        }
    }

    // Active le panneau UI
    public void ShowUI()
    {
        if (uiPanel != null)
        {
            uiPanel.SetActive(true);
            IsUIActive = true;
        }
    }

    // Désactive le panneau UI
    public void HideUI()
    {
        if (uiPanel != null)
        {
            uiPanel.SetActive(false);
            IsUIActive = false;
            hasBeenCheck = true;
        }
    }

    // Bascule l'état d'affichage du panneau UI
    public void ToggleUI()
    {
        if (uiPanel != null)
        {
            uiPanel.SetActive(!uiPanel.activeSelf);
        }
    }
}