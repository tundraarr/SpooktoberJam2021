using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;

        Vector3 center = Camera.main.transform.position;
        Vector3 halfExtents = transform.localScale / 2;

        if (Physics.BoxCast(center, halfExtents, Camera.main.transform.forward, out rayHit, Camera.main.transform.rotation, 10f))
        {
            Transform hitTarget = rayHit.transform;
            Debug.Log(hitTarget);
            if (hitTarget.GetComponent<IShootable>() != null)
            {              
                Debug.Log("Hit target");
                hitTarget.GetComponent<IShootable>().GetShot();
            }
        }
    }
}
