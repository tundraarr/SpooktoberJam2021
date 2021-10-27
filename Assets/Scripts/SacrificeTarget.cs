using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacrificeTarget : MonoBehaviour, IShootable
{
    public bool isAttackable;

    // Start is called before the first frame update
    void Start()
    {
        isAttackable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetShot()
    {
        if(isAttackable)
        {
            Debug.Log("Imposter shot!");
        }
    }
}
