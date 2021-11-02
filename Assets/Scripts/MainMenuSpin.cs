using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSpin : MonoBehaviour
{
    // Update is called once per frame
    public float rotateSpeed;

    void Update()
    {
        transform.Rotate(new Vector3(0, rotateSpeed, 0));
    }
}
