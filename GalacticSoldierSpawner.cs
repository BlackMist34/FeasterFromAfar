using UnityEngine;

public class GalacticSoldierSpawner : MonoBehaviour
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
            GalacticSoldierManager.Instance.RequestLv5Soldier(gameObject);
        else if (spawnCount > 9 && spawnCount <= 12)
            GalacticSoldierManager.Instance.RequestLv4Soldier(gameObject);
        else if (spawnCount > 6 && spawnCount <= 9)
            GalacticSoldierManager.Instance.RequestLv3Soldier(gameObject);
        else if (spawnCount > 3 && spawnCount <= 6)
            GalacticSoldierManager.Instance.RequestLv2Soldier(gameObject);
        else
            GalacticSoldierManager.Instance.RequestLv1Soldier(gameObject);
    }

    public int GetSpawnCount()
    {
        return spawnCount;
    }
}
