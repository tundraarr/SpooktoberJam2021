using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickOTreater : NPC
{
    private QuestTask task;

    void Start()
    {
        task = GetComponent<QuestTask>();
    }

    public override void GetShot()
    {
        if(isKillable)
        {
            task.TaskCompleted();
            GetComponent<Animator>().enabled = false;
            FindObjectOfType<SoundManager>().PlayHitSound();
            gameObject.tag = "Untagged";
        }
    }
}
