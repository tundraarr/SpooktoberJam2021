using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacrificeTarget : MonoBehaviour, IShootable
{
    public bool isShootable;

    public void GetShot()
    {
        if(isShootable)
        {
            FindObjectOfType<GameManager>().SacrificeCollected();
            FindObjectOfType<SoundManager>().PlaySacrifice();
            Destroy(gameObject);
        }
    }
}
