using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogueParent;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Button option1Button;
    [SerializeField] private Button option2Button;
    [SerializeField] private float typingSpeed = 0.05f;
    [SerializeField] private float turnSpeed = 2f;
    private List<dialogueString> dialogueList;
    [Header("Player")]
    [SerializeField] private NewBehaviourScript firstPersonController;

    private Transform playerCamera;
    private int currentDialogueIndex= 0;
    private void Start()
    {
        dialogueParent.SetActive(false);
        playerCamera = Camera.main.transform;
    }

    public void DialogueStart(List<dialogueString> textToPrint, Transform NPC)
    {
        dialogueParent.SetActive(true); 
        firstPersonController.enabled= false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        StartCoroutine(TurnCameraTowardsNPC(NPC));
        dialogueList = textToPrint;
        currentDialogueIndex = 0;
        DisableButtons();
        StartCoroutine(PrintDialogue());
    }
    private void DisableButtons()
    {
        option1Button.gameObject.SetActive(false);
        option2Button.gameObject.SetActive(false);
        option1Button.GetComponentInChildren<TMP_Text>().text = "No Option";
        option2Button.GetComponentInChildren<TMP_Text>().text = "No Option";
    }
    
    private Quaternion initialCameraRotation;

private IEnumerator TurnCameraTowardsNPC(Transform NPC)
{
    // Stocke la rotation initiale de la caméra
    initialCameraRotation = playerCamera.rotation;

    Quaternion startRotation = playerCamera.rotation;
    Quaternion targetRotation = Quaternion.LookRotation(NPC.position - playerCamera.position);

    float elapsedTime = 0f;
    while(elapsedTime < 1f)
    {
        playerCamera.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime);
        elapsedTime += Time.deltaTime * turnSpeed;
        yield return null;
    }
    playerCamera.rotation = targetRotation;
}

private void RestoreCameraRotation()
{
    // Restaure la rotation initiale de la caméra
    playerCamera.rotation = initialCameraRotation;
}

    
    private bool optionSelected = false;
    
    private IEnumerator PrintDialogue()
{
    while (currentDialogueIndex < dialogueList.Count)
    {
        dialogueString line = dialogueList[currentDialogueIndex];
        line.startDialogueEvent.Invoke();
        
        // Désactivez les boutons au début de l'affichage de chaque ligne de dialogue
        option1Button.gameObject.SetActive(false);
        option2Button.gameObject.SetActive(false);
        
        if (line.isQuestion)
        {
            yield return StartCoroutine(TypeText(line.text));

            // Activez les boutons une fois que toute la question a été affichée
			option1Button.gameObject.SetActive(true);
        	option2Button.gameObject.SetActive(true);
            option1Button.GetComponentInChildren<TMP_Text>().text = line.answerOption1;
            option2Button.GetComponentInChildren<TMP_Text>().text = line.answerOption2;
            
            option1Button.onClick.AddListener(() => HandleOptionSelected(line.option1IndexJump));
            option2Button.onClick.AddListener(() => HandleOptionSelected(line.option2IndexJump));
            option1Button.interactable = true;
            option2Button.interactable = true;

            // Attendre jusqu'à ce qu'une option soit sélectionnée
            yield return new WaitUntil(() => optionSelected);
        }
        else
        {
            yield return StartCoroutine(TypeText(line.text));
        }
        line.endDialogueEvent.Invoke();
        optionSelected = false;
    }
    DialogueStop();
}

    
    private void HandleOptionSelected(int indexJump)
    {
        optionSelected = true;
        DisableButtons();
        currentDialogueIndex = indexJump;
    }
    
    private IEnumerator TypeText(string text)
    {
        dialogueText.text = "";
        foreach(char letter in text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        if(!dialogueList[currentDialogueIndex].isQuestion)
        {
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        }
        if(dialogueList[currentDialogueIndex].isEnd)
        {
            DialogueStop();
        }
        currentDialogueIndex++;
    }
    private void DialogueStop()
    {
        StopAllCoroutines();
        dialogueText.text = "";
        dialogueParent.SetActive(false);
        firstPersonController.enabled = true;
		RestoreCameraRotation();
    }
    
}
