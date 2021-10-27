using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueRenderer dialogueRenderer;
    public Quest quest;

    private PlayerController playerRef;
    private bool talkingToPlayer;
    [SerializeField] private float dialogueDistance;

    private void Awake()
    {
        playerRef = FindObjectOfType<PlayerController>();
        talkingToPlayer = false;
    }

    private void Update()
    {
        if(talkingToPlayer)
        {
            if(Vector3.Distance(transform.position, playerRef.transform.position) > dialogueDistance)
            {
                talkingToPlayer = false;
                dialogueRenderer.ClearDialogue();
            }
        }
    }

    public void Interact()
    {
        talkingToPlayer = true;
        quest.SetQuestActive();
        if (!dialogueRenderer.HasDialogueLoaded())
        {
            dialogueRenderer.LoadSentences(quest.dialogue);
        }
        dialogueRenderer.RenderText();
    }
}
