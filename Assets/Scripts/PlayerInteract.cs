using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
	public Transform playerCamera;

    private bool inMicro=false;

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressed");
            
            float interactRange = 3f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                
                if (collider.TryGetComponent(out NPCInterract npcinterract))
                {
                    npcinterract.Interract();
                }

                if (collider.TryGetComponent(out NPCInterractMicroscope microscopeInterract))
                {
                    
                    microscopeInterract.Interract();
                    
                    //StartCoroutine(resetCamera(microscopeInterract));
                    Debug.Log("Microscope");
                    inMicro = true;
                }
                
                if (collider.TryGetComponent(out NPCInterractGlass gameSelectionInterract))
                {
                    Debug.Log("game");
                    gameSelectionInterract.Interract();
                    //StartCoroutine(resetCamera(gameSelectionInterract));
                    Debug.Log("game");
                    inMicro = true;
                }
            }
        }
    }
    IEnumerator resetCamera(NPCInterractMicroscope collider)
    {
        yield return new WaitForSeconds(2f); // Attend 2 secondes
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E)); // Attend jusqu'à ce que la touche E soit pressée
        Debug.Log("Reset Camera");
        collider.ResetCamera();
        inMicro = false;
    }
	
}
