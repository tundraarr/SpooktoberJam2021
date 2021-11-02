using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public List<Dialogue> dialogue;
    public QuestTask[] tasks;

    private int tasksLeft;
    public bool questCompleted;
    public bool questActive;

    public void SetQuestActive()
    {
        questActive = true;
    }

    public void SetTasksLeft()
    {
        if(tasks.Length > 0)
        {
            tasksLeft = tasks.Length;
        }
    }

    public void AssignQuestReference()
    {
        if(tasks.Length > 0)
        {
            foreach(QuestTask task in tasks)
            {
                task.SetQuestReference(this);
            }
        }
    }

    public void UpdateQuestProgress()
    {
        tasksLeft--;
        if(tasksLeft == 0)
        {
            QuestCompleted();
        }
    }

    public void QuestCompleted()
    {
        questCompleted = true;
        dialogue.RemoveAt(0);
    }
}
