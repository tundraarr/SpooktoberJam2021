using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cultist : NPC
{
    public SacrificeTarget associatedTarget;

    public override void Interact()
    {
        talkingToPlayer = true;

        if (!quest.questActive)
        {
            quest.SetQuestActive();
            EnableNPCDeath();
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

    private void EnableNPCDeath()
    {
        foreach (QuestTask item in quest.tasks)
        {
            //Enable NPC death flag
            item.GetComponent<NPC>().SetKillable(true);
        }
    }
}
