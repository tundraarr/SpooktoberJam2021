using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravekeeper : NPC
{
    public override void GetShot()
    {
        if (isKillable)
        {
            FindObjectOfType<GameManager>().SacrificeCollected();
            FindObjectOfType<SoundManager>().PlaySacrifice();
            Destroy(gameObject);
        }
    }
}
