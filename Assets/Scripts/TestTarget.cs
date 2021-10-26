using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTarget : MonoBehaviour, IShootable
{
    public void GetShot()
    {
        Debug.Log("Get shot!!!");
    }
}
