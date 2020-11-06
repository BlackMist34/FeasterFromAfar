using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicalConstructionSpawner : MonoBehaviour
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
            MagicalConstructionManager.Instance.RequestLv5Soldier(gameObject);
        else if (spawnCount > 9 && spawnCount <= 12)
            MagicalConstructionManager.Instance.RequestLv4Soldier(gameObject);
        else if (spawnCount > 6 && spawnCount <= 9)
            MagicalConstructionManager.Instance.RequestLv3Soldier(gameObject);
        else if (spawnCount > 5 && spawnCount <= 6)
            MagicalConstructionManager.Instance.RequestLv2Soldier(gameObject);
        else
            MagicalConstructionManager.Instance.RequestLv1Soldier(gameObject);
    }

    public int GetSpawnCount()
    {
        return spawnCount;
    }
}
