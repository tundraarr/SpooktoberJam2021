using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narration : MonoBehaviour
{
    public Animator anim;

    public void GameStart()
    {
        FindObjectOfType<GameManager>().StartGame();
    }

    public void EndGameSequence()
    {
        anim.Play("EndStart");
    }

    public void ChangeToEndView()
    {
        FindObjectOfType<GameManager>().GameEnding();
    }
}
