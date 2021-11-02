using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour, IShootable
{
    private QuestTask task;

    void Awake()
    {
        task = GetComponent<QuestTask>();
    }

    public void GetShot()
    {
        if(task.CheckIfQuestActive())
        {
            task.TaskCompleted();
            Destroy(gameObject);
        }
    }
}
