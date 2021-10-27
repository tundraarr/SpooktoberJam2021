using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    //public NPC questTrigger;
    public Dialogue dialogue;
    public SacrificeTarget target;

    public void SetQuestActive()
    {
        target.isAttackable = true;
    }
}
