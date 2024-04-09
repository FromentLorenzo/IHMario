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
                    
                    StartCoroutine(resetCamera(microscopeInterract));
                    inMicro = true;
                }
                
                if (collider.TryGetComponent(out NPCInterractGlass gameSelectionInterract) && !inMicro)
                {
                    Debug.Log("ON PASSE LA");
                    gameSelectionInterract.Interract();
                    StartCoroutine(resetCameraa(gameSelectionInterract));
                    gameSelectionInterract.enabled = false;
                    inMicro = true;
                }
            }
        }
    }
    IEnumerator resetCamera(NPCInterractMicroscope collider)
    {
        yield return new WaitForSeconds(2f); // Attend 2 secondes
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E)); // Attend jusqu'à ce que la touche E soit pressée
        collider.ResetCamera();
        inMicro = false;
    }
    
    IEnumerator resetCameraa(NPCInterractGlass collider)
    {
        yield return new WaitForSeconds(2f);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E)); // Attend jusqu'à ce que la touche E soit pressée
        collider.ResetCamera();
        inMicro = false;
    }
	
}
