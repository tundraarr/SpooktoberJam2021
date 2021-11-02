using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Architect : NPC
{
    public SacrificeTarget associatedTarget;

    public override void Interact()
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

        if(quest.questCompleted)
        {
            associatedTarget.isShootable = true;
        }
    }
}
