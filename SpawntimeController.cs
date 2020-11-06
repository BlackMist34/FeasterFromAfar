using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawntimeController : MonoBehaviour
{
    #region Lists of SpawnGroups
    [SerializeField] private List<GameObject> modernSoldiers;
    [SerializeField] private List<GameObject> galaxySoldiers;
    [SerializeField] private List<GameObject> fantasySoldiers;
    #endregion

    #region List of Cages
    [SerializeField] private List<GameObject> modernCages;
    [SerializeField] private List<GameObject> galaxyCages;
    [SerializeField] private List<GameObject> fantasyCages;
    #endregion

    #region Spawn Counts
    private AttackDogSpawner modernSpawnCount;
    private RobotSpawner galaxySpawnCount;
    private MagicalConstructionSpawner fantasySpawnCount;
    #endregion


    public void Awake()
    {
        ActivateModern();
    }

    private void Start()
    {
        modernSpawnCount = modernSoldiers[0].GetComponentInChildren<AttackDogSpawner>();
        galaxySpawnCount = galaxySoldiers[0].GetComponentInChildren<RobotSpawner>();
        fantasySpawnCount = fantasySoldiers[0].GetComponentInChildren<MagicalConstructionSpawner>();
    }

    private void Update()
    {
        if(fantasySpawnCount.GetSpawnCount() <= 5 && modernSpawnCount.GetSpawnCount() >= 24)
        {
            DeactivateModern();
            ActivateGalaxy();
        }
        if(fantasySpawnCount.GetSpawnCount() <= 5 && galaxySpawnCount.GetSpawnCount() >= 24)
        {
            DeactivateGalaxy();
            ActivateFantasy();
        }
        if(fantasySpawnCount.GetSpawnCount() >= 24)
        {
            ActivateModern();
            ActivateGalaxy();
        }
    }

    #region Activations
    private void ActivateModern()
    {
        foreach(GameObject spawnGroup in modernSoldiers)
        {
            spawnGroup.SetActive(true);
        }

        foreach(GameObject cage in modernCages)
        {
            cage.GetComponentInChildren<Animator>().SetBool("isOpening", true);
        }
    }

    private void ActivateGalaxy()
    {
        foreach (GameObject spawnGroup in galaxySoldiers)
        {
            spawnGroup.SetActive(true);
        }

        foreach (GameObject cage in galaxyCages)
        {
            cage.GetComponentInChildren<Animator>().SetBool("isOpening", true);
        }
    }

    private void ActivateFantasy()
    {
        foreach (GameObject spawnGroup in fantasySoldiers)
        {
            spawnGroup.SetActive(true);
        }

        foreach (GameObject cage in fantasyCages)
        {
            cage.GetComponentInChildren<Animator>().SetBool("isOpening", true);
        }
    }
    #endregion

    #region Deactivations
    private void DeactivateModern()
    {
        foreach (GameObject spawnGroup in modernSoldiers)
        {
            spawnGroup.SetActive(false);
        }

        foreach (GameObject cage in modernCages)
        {
            cage.GetComponent<Animator>().SetBool("isOpening", false);
        }
    }

    private void DeactivateGalaxy()
    {
        foreach (GameObject spawnGroup in galaxySoldiers)
        {
            spawnGroup.SetActive(false);
        }

        foreach (GameObject cage in galaxyCages)
        {
            cage.GetComponent<Animator>().SetBool("isOpening", false);
        }
    }
    #endregion
}
