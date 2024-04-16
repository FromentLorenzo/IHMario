using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surbrillance : MonoBehaviour
{
    public GameObject highlightLight;
    public GameObject selection;

    void OnMouseEnter()
    {
        if (!UIController.IsUIActive)
        {
            highlightLight.SetActive(true);
            selection.SetActive(true);
        }
    }

    void OnMouseExit()
    {
        highlightLight.SetActive(false);
        selection.SetActive(false);
    }
}
