using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupQuestItem : MonoBehaviour, IInteractable
{
    private QuestTask task;

    void Awake()
    {
        task = GetComponent<QuestTask>();
    }

    public void Interact()
    {
        if (task.CheckIfQuestActive())
        {
            task.TaskCompleted();
            Destroy(gameObject);
        }
    }
}
