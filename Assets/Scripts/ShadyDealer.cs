using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadyDealer : NPC, IInteractable
{
    public SacrificeTarget associatedTarget;

    public override void Interact()
    {
        talkingToPlayer = true;

        if(!quest.questActive)
        {
            quest.SetQuestActive();
            ShowQuestItems();
            Debug.Log("Shady time");
        }

        if (!dialogueRenderer.HasDialogueLoaded())
        {
            dialogueRenderer.LoadSentences(quest.dialogue[0]);
        }
        dialogueRenderer.RenderText();

        if(quest.questCompleted)
        {
            associatedTarget.isShootable = true;
        }
    }

    private void ShowQuestItems()
    {
        foreach(QuestTask item in quest.tasks)
        {
            item.gameObject.SetActive(true);
        }
    }
}
