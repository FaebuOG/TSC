using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("TestPlayer"))
        {
            var gamepad = Gamepad.current;
            if (gamepad.buttonSouth.wasPressedThisFrame)
            {
                Debug.Log("Triggerd Dialogue");
                TriggerDialogue();
            }

            
        }
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
