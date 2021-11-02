using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTask : MonoBehaviour
{
    private Quest questReference;
    public bool isDone = false;

    public void TaskCompleted()
    {
        isDone = true;
        questReference.UpdateQuestProgress();
    }

    public void SetQuestReference(Quest quest)
    {
        questReference = quest;
    }

    public bool CheckIfQuestActive()
    {
        return questReference.questActive;
    }
}
