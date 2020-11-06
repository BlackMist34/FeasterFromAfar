using UnityEngine;

public class MagicKnightSpawner : MonoBehaviour
{
    private int spawnCount;

    private void Awake()
    {
        spawnCount = 0;
    }

    private void Start()
    {
        InvokeRepeating("Spawn", 0f, 15f);
    }

    void Spawn()
    {
        spawnCount++;

        if (spawnCount > 12)
            MagicKnightManager.Instance.RequestLv5Soldier(gameObject);
        else if (spawnCount > 9 && spawnCount <= 12)
            MagicKnightManager.Instance.RequestLv4Soldier(gameObject);
        else if (spawnCount > 6 && spawnCount <= 9)
            MagicKnightManager.Instance.RequestLv3Soldier(gameObject);
        else if (spawnCount > 3 && spawnCount <= 6)
            MagicKnightManager.Instance.RequestLv2Soldier(gameObject);
        else
            MagicKnightManager.Instance.RequestLv1Soldier(gameObject);
    }

    public int GetSpawnCount()
    {
        return spawnCount;
    }
}
