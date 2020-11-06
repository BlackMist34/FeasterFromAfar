using UnityEngine;

public class RobotSpawner : MonoBehaviour
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

        if (spawnCount > 8)
            RobotManager.Instance.RequestLv5Soldier(gameObject);
        else if (spawnCount > 6 && spawnCount <= 8)
            RobotManager.Instance.RequestLv4Soldier(gameObject);
        else if (spawnCount > 4 && spawnCount <= 6)
            RobotManager.Instance.RequestLv3Soldier(gameObject);
        else if (spawnCount > 2 && spawnCount <= 4)
            RobotManager.Instance.RequestLv2Soldier(gameObject);
        else
            RobotManager.Instance.RequestLv1Soldier(gameObject);
    }

    public int GetSpawnCount()
    {
        return spawnCount;
    }
}
