using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surbrillance : MonoBehaviour
{
    public GameObject highlightLight;

    void OnMouseEnter()
    {
        if (!UIController.IsUIActive)
        {
            highlightLight.SetActive(true);
        }
    }

    void OnMouseExit()
    {
        highlightLight.SetActive(false);
    }
}
