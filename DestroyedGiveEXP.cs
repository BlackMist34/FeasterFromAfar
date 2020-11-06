using UnityEngine;

public class DestroyedGiveEXP : MonoBehaviour, IDestructible
{
    private CharacterStats stats;

    private void Awake()
    {
        stats = GetComponent<CharacterStats>();
    }

    public void OnDestruction(GameObject attacker)
    {
        if (attacker.CompareTag("Player"))
        {
            attacker.GetComponent<CharacterStats>().ApplyEXP(stats.GetRequiredExp());
        }
    }
}
