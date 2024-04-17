using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupControllermusee : MonoBehaviour
{
    public static bool IsUIActive { get; private set; }

    private static bool hasBeenCheck = false;

    public GameObject uiPanel; // R�f�rence au panneau UI que vous voulez afficher ou masquer

    // M�thode appel�e lorsque quelque chose entre dans le collider
    private void OnTriggerEnter(Collider other)
    {
        // V�rifie si l'autre objet a un tag sp�cifique si n�cessaire
        if (other.CompareTag("Player"))
        {
            if(hasBeenCheck == false)
            {
                // Appelle la m�thode ShowUI du script PopupControllermusee
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

    // D�sactive le panneau UI
    public void HideUI()
    {
        if (uiPanel != null)
        {
            uiPanel.SetActive(false);
            IsUIActive = false;
            hasBeenCheck = true;
        }
    }

    // Bascule l'�tat d'affichage du panneau UI
    public void ToggleUI()
    {
        if (uiPanel != null)
        {
            uiPanel.SetActive(!uiPanel.activeSelf);
        }
    }
}