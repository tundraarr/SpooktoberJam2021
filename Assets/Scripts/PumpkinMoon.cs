using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinMoon : MonoBehaviour
{
    public GameObject candyPrefab;
    public float rateOfSpawn;
    public int maxCandy;
    public BoxCollider col;
    private Queue<GameObject> candyPool = new Queue<GameObject>();
    private float cooldown;

    public void StartRain()
    {
        StartCoroutine(RainCandy());
    }

    public IEnumerator RainCandy()
    {
        while(true)
        {
            if(cooldown <= 0)
            {
                if(candyPool.Count < maxCandy)
                {
                    candyPool.Enqueue(SpawnCandy());
                }
                else
                {
                    Destroy(candyPool.Dequeue());
                    candyPool.Enqueue(SpawnCandy());
                }
                cooldown = rateOfSpawn;
            }
            else
            {
                cooldown -= Time.deltaTime;
            }
            yield return null;
        }
    }

    private GameObject SpawnCandy()
    {
        Vector3 spawnLocation = new Vector3(Random.Range(col.bounds.min.x, col.bounds.max.x), transform.position.y, Random.Range(col.bounds.min.z, col.bounds.max.z));
        GameObject instance = Instantiate(candyPrefab, spawnLocation, transform.rotation);
        return instance;
    }
}
