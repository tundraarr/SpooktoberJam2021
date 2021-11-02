using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyMaker : NPC
{
    public Transform questTrigger;
    public NPC gravekeeper;

    public override void Interact()
    {
        talkingToPlayer = true;

        if (!quest.questActive)
        {
            quest.SetQuestActive();
        }

        if (!dialogueRenderer.HasDialogueLoaded())
        {
            if(questTrigger == null)
            {
                gravekeeper.SetKillable(true);
                dialogueRenderer.LoadSentences(quest.dialogue[1]);
            }
            else
            {
                dialogueRenderer.LoadSentences(quest.dialogue[0]);
            }
        }
        dialogueRenderer.RenderText();
    }
}
