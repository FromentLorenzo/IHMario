using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class SelectionScript : MonoBehaviour
{
    public Material highlightMaterial;
    public Material selectionMaterial;
    public NPCInterractGlass npcInterractGlass;
    private Material originalMaterial;
    private Transform highlight;
    private Transform selection;
    private RaycastHit raycastHit;
    
    // Update is called once per frame
    void Update()
    {
        if (highlight != null)
        {
            highlight.GetComponent<MeshRenderer>().material = originalMaterial;
            highlight = null;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit))
        {
            Debug.Log("raycastHit.transform.name");
            highlight= raycastHit.transform;
            if (highlight.CompareTag("Selectable") && highlight != selection)
            {
                if(highlight.GetComponent<MeshRenderer>().material !=highlightMaterial)
                {
                    originalMaterial = highlight.GetComponent<MeshRenderer>().material;
                    highlight.GetComponent<MeshRenderer>().material = highlightMaterial;
                    
                }
            }
            else
            {
                highlight = null;
            }
        }

        if (Input.GetKey(KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("aaaa");
            if (selection != null)
            {
                Debug.Log("bbbbb");
                selection.GetComponent<MeshRenderer>().material = originalMaterial;
                selection = null;
            }

            if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit))
            {
                Debug.Log("cccccc");
                selection= raycastHit.transform;
                if (selection.CompareTag("Selectable"))
                {
                    Debug.Log("dddd");
                    selection.GetComponent<MeshRenderer>().material= selectionMaterial;
                    npcInterractGlass.cubeSelected(selection.gameObject); // Appel de cubeSelected avec l'objet sélectionné

                    
                }
                else
                {
                    selection = null;
                }
            }
        }
        
    }
}
