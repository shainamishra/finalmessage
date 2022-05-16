using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;

	public GameObject dialogueManager;

	public void TriggerDialogue ()
	{
		 dialogueManager.gameObject.GetComponent<DialogueManager>().StartDialogue(dialogue);
	}

}