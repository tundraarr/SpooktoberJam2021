using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffin : MonoBehaviour, IShootable
{
    private QuestTask task;
    private bool canShoot;

    void Awake()
    {
        task = GetComponent<QuestTask>();
    }

    public void GetShot()
    {
        if(task.CheckIfQuestActive())
        {
            FindObjectOfType<GameManager>().SacrificeCollected();
            task.TaskCompleted();
            Destroy(gameObject);
        }
    }

    private void SpawnBody()
    {

    }
}
