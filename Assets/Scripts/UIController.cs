using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public static bool IsUIActive { get; private set; }

    public GameObject uiPanel; // Référence au panneau UI que vous voulez afficher ou masquer

    public int planetseleced;

    public TextMeshProUGUI textToUpdate;

    // Active le panneau UI
    public void ShowUI(int p)
    {
        if (uiPanel != null)
        {
            planetseleced=p;
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

    public int getplanetseleced(){
        return planetseleced;
    }

    public void UpdateText(string newText)
    {
        if (textToUpdate != null)
        {
            textToUpdate.text = FormatText(newText);
        }
        else
        {
            Debug.LogWarning("Text UI object is not assigned!");
        }
    }

    private string FormatText(string newText)
    {
        string formattedText = "Voulez-vous visiter\nla planete <color=red>" + newText + "</color> ?";

        return formattedText;
    }
}