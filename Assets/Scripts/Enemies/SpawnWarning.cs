using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWarning : MonoBehaviour
{
    private float spawnInterval = 1f;
    public GameObject enemy;
    private float nextSpawnTime;
    private bool canSpawn=true;
    
        void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }
    private void Update()
    {
        SpawnAnimacao();
        if (!canSpawn)
        {
            Destroy(gameObject);
        }
    }

    void SpawnAnimacao()
    {
        if (nextSpawnTime < Time.time && canSpawn)
        {
            Instantiate(enemy, gameObject.transform.position, Quaternion.identity);
            canSpawn = false;
        }
    }
}
