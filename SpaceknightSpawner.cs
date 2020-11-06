using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceknightSpawner : MonoBehaviour
{
    private int spawnCount;

    private void Awake()
    {
        spawnCount = 0;
    }

    private void Start()
    {
        InvokeRepeating("Spawn", 0f, 10f);
    }

    void Spawn()
    {
        spawnCount++;

        if (spawnCount > 12)
            SpaceknightManager.Instance.RequestLv5Soldier(gameObject);
        else if (spawnCount > 9 && spawnCount <= 12)
            SpaceknightManager.Instance.RequestLv4Soldier(gameObject);
        else if (spawnCount > 6 && spawnCount <= 9)
            SpaceknightManager.Instance.RequestLv3Soldier(gameObject);
        else if (spawnCount > 3 && spawnCount <= 6)
            SpaceknightManager.Instance.RequestLv2Soldier(gameObject);
        else
            SpaceknightManager.Instance.RequestLv1Soldier(gameObject);
    }

    public int GetSpawnCount()
    {
        return spawnCount;
    }
}
