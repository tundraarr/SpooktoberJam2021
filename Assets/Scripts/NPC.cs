using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable, IShootable
{
    [SerializeField] protected DialogueRenderer dialogueRenderer;
    public Quest quest;

    protected PlayerController playerRef;
    protected bool talkingToPlayer;
    [SerializeField]protected bool isKillable;
    protected bool isDead;
    [SerializeField] protected float dialogueDistance;

    private void Awake()
    {
        playerRef = FindObjectOfType<PlayerController>();
        talkingToPlayer = false;
        if(quest != null)
        {
            quest.AssignQuestReference();
            quest.SetTasksLeft();
        }
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

    //To be overridden in child classes
    public virtual void Interact()
    {
        talkingToPlayer = true;

        if (!quest.questActive)
        {
            quest.SetQuestActive();
        }

        if (!dialogueRenderer.HasDialogueLoaded())
        {
            dialogueRenderer.LoadSentences(quest.dialogue[0]);
        }
        dialogueRenderer.RenderText();
    }

    public virtual void GetShot()
    {
        if(isKillable)
        {
            Die();
        }
    }

    public void SetKillable(bool canKill)
    {
        isKillable = canKill;
    }

    private void Die()
    {
        Debug.Log("NPC Dead");
    }
}
